using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Lync.Model;
using System.Diagnostics;

namespace TaskTrayApplication
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Instead of running a form, we run an ApplicationContext.

            if (AnotherInstanceExists())
            {
                return;
            }


            Application.Run(new TaskTrayApplicationContext());
        }

        public static bool AnotherInstanceExists()
        {
            Process currentRunningProcess = Process.GetCurrentProcess();
            Process[] listOfProcs = Process.GetProcessesByName(currentRunningProcess.ProcessName);

            foreach (Process proc in listOfProcs)
            {
                if ((proc.MainModule.FileName == currentRunningProcess.MainModule.FileName) && (proc.Id != currentRunningProcess.Id))
                    return true;
            }
            return false;
        }
    }
}