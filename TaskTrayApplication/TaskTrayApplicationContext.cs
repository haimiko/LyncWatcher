/**
 *  Author: Haim Lichaa 2016-2017 
 *  Do not redistribute without approval of the author
 */


using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using System.IO.Ports;
using Microsoft.Win32;
using System.Threading;
using System.Net;
using Microsoft.Lync.Model.Conversation.AudioVideo;
using Microsoft.Lync.Model.Extensibility;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections;
using System.Diagnostics;
//
namespace TaskTrayApplication
{
    public class TaskTrayApplicationContext : ApplicationContext
    {
        string FWVERSION = "1.05";
        string currVersion = string.Empty;
        NotifyIcon notifyIcon = new NotifyIcon();
        Configuration configWindow = new Configuration();
        AboutBox1 AboutWindows = new AboutBox1();
        private string firstName = string.Empty;
        LyncClient lync;
        Contact _contact;
        ContactSubscription _contactSubscription ;
        List<ContactInformationType> _ContactInformationList = new List<ContactInformationType>();
        static SerialPort _serialPort;
        private Conversation _Conversation;
        DateTime LastUpdate = DateTime.Now.AddSeconds(-300);
        const string FREE = "3";
        const string BUSY = "1";
        const string DND = "5";
        const string BRB = "9";
        // const string AWAY = "0";
        const string AWAY = "2";
        const string OFFLINE = "0";
        const string MESSAGERECEIVED = "2";
        const string ERROR = "4";
        bool stationLocked = false;
        const string FREESOLID = "7";
        const string BUSYSOLID = "6";
        const string OFFWORK = "y";
        ContactAvailability LASTSTATUS = ContactAvailability.Invalid;
        int lastPhraseIndex = -1;
        DateTime LastResponse= DateTime.Now.AddSeconds(-2);
        protected delegate void SafeWriteToOutputDelegate(string output);
        protected object myLock = new object();
        protected bool _speechRecognitionOn = false;
        Hashtable lastMessage = new Hashtable();
        protected string savedGamesFolder = string.Empty;
        static string path = Application.ExecutablePath;
        int sleepInterval = 2000;
        public TaskTrayApplicationContext()
        {
            initTrayIcon();
            int count = 0;
            while (initLyncSubscription() == false)
            {
                if (count > 1000)
                {
                    Environment.Exit(200);
                }
                Thread.Sleep(sleepInterval);
                count++;

            }
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.AutoReset = true;
            timer.Interval = sleepInterval;
            timer.Start();



            timer.Elapsed += checkStatus;

            Microsoft.Win32.SystemEvents.SessionSwitch += new Microsoft.Win32.SessionSwitchEventHandler(SystemEvents_SessionSwitch);



            if (TaskTrayApplication.Properties.Settings.Default.enableStartup)
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.SetValue("LyncStatusWatcher", "\"" + Application.ExecutablePath + "\"");
                }
            }
            else
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                {
                    key.DeleteValue("LyncStatusWatcher", false);
                }

            }


            ShowMessage(null, null);
            string output = "";
            if (TaskTrayApplication.Properties.Settings.Default.autoFirmware)
            {
                try
                {
                    string version = getFirmwareVersion();
                    if (version == null || version == string.Empty || version.ToLower().Contains("error"))
                    {
                        Thread.Sleep(5000);
                        version = getFirmwareVersion();
                        if (version == null || version == string.Empty || version.ToLower().Contains("error"))
                            version = "1.0.0";
                    }
                    writeEvent("Starting LyncStatusWatcher firmware version: " + version, EventLogEntryType.Information);
                    if (version != FWVERSION)
                    {
                        if (MessageBox.Show("Woohoo! New firmware update available for your Lync Light.  Do you wish to update?\n Your Version: "+ version +"\n New Version: "+FWVERSION, "Firmware Update",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button1) == DialogResult.Yes) {
                            output = avr.avrupdate(Directory.GetCurrentDirectory() + @"\\firmware\\LyncLED.ino.hex", getCommPort());
                            if (output.Contains("flash verified"))
                            {
                                writeEvent("Successfully update firmware to : " + getFirmwareVersion(), EventLogEntryType.Information);
                            }
                            version = getFirmwareVersion();
                            if (version != FWVERSION)
                            {
                                writeEvent("Could not update firmware from : " + version, EventLogEntryType.Warning);
                            }
                        }
                    }
                   
                }
                catch (Exception ex)
                {
                    writeEvent("Could not update firmware: "+ex.Message, EventLogEntryType.Warning);
                }
            }
        }

        void writeEvent(string msg, EventLogEntryType sev)
        {
            string sSource;
            string sLog;

            try
            {

                sSource = ".NET Runtime";
                sLog = "Application";

                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);
                EventLog.WriteEntry(sSource, msg);
                EventLog.WriteEntry(sSource, msg, sev, 9493);
            }
            catch { }
        }

        string getFirmwareVersion()
        {
            string returnMessage = "";
            try
            {
                int intReturnASCII = 0;
                if (_serialPort == null)
                    serialPortInit();
                if (_serialPort.PortName == null)
                {
                    Thread.Sleep(100);
                    serialPortInit();
                    if (_serialPort.PortName == null)
                    {
                        return "error initializing port";
                    }
                }
                _serialPort.Open();
                _serialPort.Write("v");
                Thread.Sleep(1000);
                int count = _serialPort.BytesToRead;
                
                while (count > 0)
                {
                    intReturnASCII = _serialPort.ReadByte();
                    returnMessage = returnMessage + Convert.ToChar(intReturnASCII);
                    count--;
                }
                _serialPort.Close();
            }
            catch { }
            try
            {
                returnMessage = returnMessage.Split(';')[1];
            }
            catch {
                returnMessage = "error getting version";
            }
            TaskTrayApplication.Properties.Settings.Default.currentFirmware = returnMessage.Trim();
            return returnMessage.Trim();
        }

     
        void initTrayIcon()
        {
            MenuItem configMenuItem = new MenuItem("Configuration", new EventHandler(ShowConfig));

            MenuItem aboutMenuItem = new MenuItem("About", new EventHandler(ShowAbout));
            MenuItem exitMenuItem = new MenuItem("Exit", new EventHandler(Exit));



            notifyIcon.Icon = TaskTrayApplication.Resource1.AppIcon;
          //  notifyIcon.DoubleClick += new EventHandler(ShowMessage);
            notifyIcon.ContextMenu = new ContextMenu(new MenuItem[] { configMenuItem,aboutMenuItem, exitMenuItem });
            notifyIcon.DoubleClick += NotifyIcon_DoubleClick;
            notifyIcon.Visible = true;

        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowConfig(null,null);
        }

    


        void  nWriteToOutput (string output)
        {
            string[] args = new string[1] { output };
            var a = args;
        }



        void SystemEvents_SessionSwitch(object sender, Microsoft.Win32.SessionSwitchEventArgs e)
        {
            //check session locked
            if (e.Reason == SessionSwitchReason.SessionLock)
            {
                stationLocked = true;
                //unsubscribe from lync messages when not at desk
                undoLyncSubscription();
                if (TaskTrayApplication.Properties.Settings.Default.enableAway)
                {
                    setLED(AWAY);
                }
                else
                    setLED(OFFLINE);

            }
            else if (e.Reason == SessionSwitchReason.SessionUnlock)
            {
                stationLocked = false;
                initLyncSubscription();
                ShowMessage(null,null);
            }
        }

        public string getCommPort()
        {
            foreach (COMPortInfo comPort in COMPortInfo.GetCOMPortsInfo())
            {
                //Console.WriteLine(string.Format("{0} – {1}", comPort.Name, comPort.Description));
                //MessageBox.Show(comPort.Name +" - "+ comPort.Description());
                if (comPort.Description.Contains("CH340"))
                    return comPort.Name;
            }
            return null ;
        }

        public bool initLyncSubscription()
        {
             try
            {
                serialPortInit();

                _contactSubscription = LyncClient.GetClient().ContactManager.CreateSubscription();
                lync = LyncClient.GetClient();
                //Wait for Lync to sign in
                while (lync.State != ClientState.SignedIn)
                {
                    setLED(ERROR);
                    Thread.Sleep(sleepInterval);
                    lync = LyncClient.GetClient();
                }


               
                _contact = lync.ContactManager.GetContactByUri(lync.Uri);
                firstName = lync.Uri.Split(':')[1].Split('.')[0].ToUpper();

                if (string.IsNullOrEmpty(TaskTrayApplication.Properties.Settings.Default.reponsePrefix))
                    TaskTrayApplication.Properties.Settings.Default.reponsePrefix = firstName;

                _ContactInformationList.Add(ContactInformationType.Availability);
                _contactSubscription.AddContact(_contact);
                _contactSubscription.Subscribe(ContactSubscriptionRefreshRate.High, _ContactInformationList);
                //Register for event raised when selected user contact information
                //is re-published.
                _contact.ContactInformationChanged += ShowMessage;

                //register for new message

                lync.StateChanged += _LyncClient_StateChanged;

            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("running"))
                {
                    //   MessageBox.Show("Error: Skype not running.  Try again after starting skype");
                    //   Environment.Exit(10);
                    return false;
                }
                try
                {
                    if (!TaskTrayApplication.Properties.Settings.Default.disableLyncLED)
                    {
                        _serialPort.Open();
                        _serialPort.Write("4");
                        _serialPort.Close();
                    }
                }
                catch {
                    return false;
                }
            }
            return true;
        }

        public void undoLyncSubscription()
        {
            try
            {
                _contactSubscription = LyncClient.GetClient().ContactManager.CreateSubscription();
                lync = LyncClient.GetClient();
                _contact = lync.ContactManager.GetContactByUri(lync.Uri);
                _ContactInformationList.Add(ContactInformationType.Availability);
                _contactSubscription.AddContact(_contact);
                _contactSubscription.Unsubscribe();

            }
            catch
            {
            }
        }


       
        /// <summary>
        /// Handles the event raised when a user signs in to or out of the Lync client.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _LyncClient_StateChanged(object sender, ClientStateChangedEventArgs e)
        {

            try
            {
                lync = LyncClient.GetClient();
            }
            catch {
                Thread.Sleep(sleepInterval);
                notifyIcon.Visible = false;
                notifyIcon.Icon = null;

                Application.Restart();
            }
            //Wait for Lync to sign in
            while (lync.State != ClientState.SignedIn)
            {
                setLED(ERROR);
                Thread.Sleep(sleepInterval);
                try
                {
                    lync = LyncClient.GetClient();
                }
                catch {

                }
            }
            
                initLyncSubscription();
            ShowMessage(null, null);


        }

        void checkStatus(Object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                //      serialPortInit();

                if (_serialPort != null)
                {
                    if (!TaskTrayApplication.Properties.Settings.Default.disableAutoConnect)
                    {
                        string port = getCommPort();
                        if (port == null)
                        {
                            serialPortInit();
                        }
                        if (_serialPort.PortName == port)
                            ShowMessage(null, null);
                    }
                }else
                {
                    serialPortInit();
                }
                        //   serialPortInit();
                        //   ShowMessage(null, null);
         
                if (lync.State != ClientState.SignedIn)
                {
                   // Application.Restart();
                    initLyncSubscription();
                }
                else
                {
                    ShowMessage(null,null);
                }

            }
            catch (Exception ex)
            {
                //Thread.Sleep(1000);
                //       notifyIcon.BalloonTipText = "Lost connection with Skype.";
                //        notifyIcon.ShowBalloonTip(5);
              //  MessageBox.Show(ex.Message);
                notifyIcon.Visible = false;
                notifyIcon.Icon = null;
               
                Application.Restart();
            }

        }

        void serialPortInit()
        {

            if (TaskTrayApplication.Properties.Settings.Default.disableLyncLED)
                return;

            string portName = null;

            try
            {
                _serialPort = new SerialPort();

                // Allow the user to set the appropriate properties.
                //   _serialPort.PortName = TaskTrayApplication.Properties.Settings.Default.commport;
                portName = getCommPort();
                /*           if (portName == null)
                           {
                            //   MessageBox.Show("LyncWatcher device not found. Will keep trying in the background", "communication ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                             //  Environment.Exit(255);
                           }
                           */
                while (portName == null)
                {
                    portName = getCommPort();
                    Thread.Sleep(sleepInterval*2);
                }
            }
            catch { }
       /*
            if (portName == null)
            {
                // MessageBox.Show("LyncWatcher device not found.", "communication ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(255);
            }
            */
             _serialPort.PortName = portName;

            _serialPort.BaudRate = 9600;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;


        }

   
        void ShowMessage(object sender, EventArgs e)
        {
            TimeSpan span = (DateTime.Now - LastUpdate);
            if (span.Milliseconds > 200)
                LastUpdate = DateTime.Now;
            else
                return;

            try
            {
                // Only show the message if the settings say we can.
                ContactAvailability avail = ContactAvailability.Invalid;

                if (stationLocked)
                    avail = ContactAvailability.Away;
                else
                    avail = (ContactAvailability)_contact.GetContactInformation(ContactInformationType.Availability);
                //   if (TaskTrayApplication.Properties.Settings.Default.ShowMessage)
                //       MessageBox.Show("Currently: "+avail.ToString());

                string status = _contact.GetContactInformation(ContactInformationType.ActivityId).ToString();
                if ((status.ToLower().Contains("call") || status.ToLower().Contains("present") || status.ToLower().Contains("phone") || status.ToLower().Contains("share") || status.ToLower().Contains("conference"))&& stationLocked==false)
                {
                    avail = ContactAvailability.DoNotDisturb;
                }
                if (LASTSTATUS != avail)
                {
                    notifyIcon.Visible = false;
                    notifyIcon.Icon = null;
                    LASTSTATUS = avail;
                }

                switch (avail)
                {
                    case ContactAvailability.Free:
                        if (TaskTrayApplication.Properties.Settings.Default.fade)
                            setLED(FREE);
                        else
                            setLED(FREESOLID);
                        
                        notifyIcon.Icon = TaskTrayApplication.Resource1.AppIcon_g;
                        break;
                    case ContactAvailability.Busy:
                       if (TaskTrayApplication.Properties.Settings.Default.fade)
                            setLED(BUSY);
                        else
                           setLED(BUSYSOLID);
                        notifyIcon.Icon = TaskTrayApplication.Resource1.AppIcon;

                        break;
                    case ContactAvailability.DoNotDisturb:
                        setLED(DND);
                        notifyIcon.Icon = TaskTrayApplication.Resource1.AppIcon;

                        break;
                    case ContactAvailability.Away:
                        if (TaskTrayApplication.Properties.Settings.Default.enableAway)
                            setLED(AWAY);
                        else
                            setLED(OFFLINE);
                        notifyIcon.Icon = TaskTrayApplication.Resource1.AppIcon_o;
                        break;
                    case ContactAvailability.Offline:
                        setLED(OFFLINE);
                        notifyIcon.Icon = TaskTrayApplication.Resource1.AppIcon_o;
                        break;
                    case ContactAvailability.TemporarilyAway:
                        setLED(BRB);
                        notifyIcon.Icon = TaskTrayApplication.Resource1.AppIcon_o;
                        break;

                }
            }
            catch (Exception ex)
            {
                setLED(ERROR);

                //MessageBox.Show("Error connecting to Lync/Skyp:"+ex.Message);
            }

            notifyIcon.Visible = true;

        }

        void setLED(string color)
        {
            if (TaskTrayApplication.Properties.Settings.Default.disableLyncLED)
                return;
            try {
                _serialPort.Open();
                _serialPort.Write(color);
                _serialPort.Close();
            }
            catch (Exception ex) {
                string a = ex.Message;
                string b = a;
            }
        }


        void ShowAbout(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (AboutWindows.Visible)
                AboutWindows.Focus();
            else
                AboutWindows.ShowDialog();
        }


        void ShowConfig(object sender, EventArgs e)
        {
            // If we are already showing the window meerly focus it.
            if (configWindow.Visible)
                configWindow.Focus();
            else
                configWindow.ShowDialog();
            if (TaskTrayApplication.Properties.Settings.Default.unLock)
            {
                notifyIcon.ContextMenu.MenuItems[1].Visible = true;
                notifyIcon.ContextMenu.MenuItems[1].Enabled = true;                
            }

        }

        void Exit(object sender, EventArgs e)
        {
            // We must manually tidy up and remove the icon before we exit.
            // Otherwise it will be left behind until the user mouses over.
            notifyIcon.Visible = false;
            setLED(OFFLINE);

            Application.Exit();
        }
    }

    

}
