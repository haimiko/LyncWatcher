using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO.Ports;

namespace TaskTrayApplication
{
    public partial class Configuration : Form
    {

        List<string> comms = new List<string>();
        int counter = 0;
        bool lyncLEDPrevstate;
        public Configuration()
        {
            InitializeComponent();
            /*
            foreach (string s in SerialPort.GetPortNames())
            {
                lstCommport.Items.Add(s);
            }
             

            lstCommport.SelectedItem = TaskTrayApplication.Properties.Settings.Default.commport;
             * * */

        }


        private void LoadSettings(object sender, EventArgs e)
        {
            chkEnableStartup.Checked = TaskTrayApplication.Properties.Settings.Default.enableStartup;
            chkFade.Checked = TaskTrayApplication.Properties.Settings.Default.fade;
            chkAway.Checked = TaskTrayApplication.Properties.Settings.Default.enableAway;
            chkDisableLyncLED.Checked = TaskTrayApplication.Properties.Settings.Default.disableLyncLED;
            chkFWAutoUpdate.Checked = TaskTrayApplication.Properties.Settings.Default.autoFirmware;
            lblFirmware.Text = "v" + TaskTrayApplication.Properties.Settings.Default.currentFirmware;
            chkDisableAutoConnect.Checked = TaskTrayApplication.Properties.Settings.Default.disableAutoConnect;
            lyncLEDPrevstate = chkDisableLyncLED.Checked;
        }

        private void SaveSettings(object sender, FormClosingEventArgs e)
        {
            // If the user clicked "Save"
            if (this.DialogResult == DialogResult.OK)
            {
                TaskTrayApplication.Properties.Settings.Default.enableStartup = chkEnableStartup.Checked;
                TaskTrayApplication.Properties.Settings.Default.fade = chkFade.Checked;
                TaskTrayApplication.Properties.Settings.Default.enableAway = chkAway.Checked;
                TaskTrayApplication.Properties.Settings.Default.disableLyncLED = chkDisableLyncLED.Checked;
                //      TaskTrayApplication.Properties.Settings.Default.commport = lstCommport.SelectedItem.ToString();
                TaskTrayApplication.Properties.Settings.Default.autoFirmware = chkFWAutoUpdate.Checked;
                TaskTrayApplication.Properties.Settings.Default.disableAutoConnect = chkDisableAutoConnect.Checked;
                TaskTrayApplication.Properties.Settings.Default.Save();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TaskTrayApplication.Properties.Settings.Default.enableStartup = chkEnableStartup.Checked;
            TaskTrayApplication.Properties.Settings.Default.fade = chkFade.Checked;
            TaskTrayApplication.Properties.Settings.Default.enableAway = chkAway.Checked;
            TaskTrayApplication.Properties.Settings.Default.disableLyncLED = chkDisableLyncLED.Checked;
            TaskTrayApplication.Properties.Settings.Default.autoFirmware = chkFWAutoUpdate.Checked;
            TaskTrayApplication.Properties.Settings.Default.disableAutoConnect = chkDisableAutoConnect.Checked;
            //     TaskTrayApplication.Properties.Settings.Default.commport = lstCommport.SelectedItem.ToString();

            TaskTrayApplication.Properties.Settings.Default.Save();

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

            //restart if we just enabled or disabled the LyncLED
            if ((chkDisableLyncLED.Checked && !lyncLEDPrevstate)|| (!chkDisableLyncLED.Checked && lyncLEDPrevstate))
                Application.Restart();

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }



        private void Configuration_Load(object sender, EventArgs e)
        {

        }

        private void chkDisableLyncLED_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}