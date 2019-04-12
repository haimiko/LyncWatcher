using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace TaskTrayApplication
{
    class avr
    {

        static public string avrupdate(string fileName, string comPort)
        {
            string currdir = Directory.GetCurrentDirectory();
            // These files must be part of the installation.
            // They come from the Arduino installation directory arduino/hardware/tools/avr/bin
            if (!File.Exists(currdir + @"\\avr\avrdude.exe"))
            {
                throw new Exception("avrdude tool not installed");
            }
            if (!File.Exists(currdir + @"\\avr\avrdude.conf"))
            {
                throw new Exception("avrdude config file not installed");
            }
            if (!File.Exists(currdir + @"\\avr\libusb0.dll"))
            {
                throw new Exception("avrdude usb dll not installed");
            }

            // THis file is the new image to be uploaded to the Arduino board...
            if (!File.Exists(fileName))
            {
                throw new Exception("file "+fileName +" not found");
            }

  /*          string avrport;
            if (numericUpDown_Port.Value <= 9)
                avrport = "COM" + numericUpDown_Port.Value.ToString();
            else
                avrport = "\\\\.\\COM" + numericUpDown_Port.Value.ToString();
                */
            fileName = fileName.Replace("\\", "/");
            Process avrprog = new Process();
            StreamReader avrstdout, avrstderr;
            StreamWriter avrstdin;
            ProcessStartInfo psI = new ProcessStartInfo("cmd");


            psI.UseShellExecute = false;
            psI.RedirectStandardInput = true;
            psI.RedirectStandardOutput = true;
            psI.RedirectStandardError = true;
            psI.CreateNoWindow = true;
            avrprog.StartInfo = psI;
            avrprog.Start();
            avrstdin = avrprog.StandardInput;
            avrstdout = avrprog.StandardOutput;
            avrstderr = avrprog.StandardError;
            avrstdin.AutoFlush = true;
            //avr\avrdude -Cavr/avrdude.conf -patmega328p -carduino -PCOM4 -b57600 -D -Uflash:w:firmware/LyncLed.ino.hex:i
            Directory.SetCurrentDirectory(currdir);
            avrstdin.WriteLine(@"avr\avrdude -Cavr/avrdude.conf -patmega328p -carduino -P"+comPort+" -b57600 -D -Uflash:w:"+fileName+":i");
            avrstdin.Close();
            string output = avrstdout.ReadToEnd();
             output += avrstderr.ReadToEnd();
            return output;
        }
    }
}
