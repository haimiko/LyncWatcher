using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Lync.Model;
using Microsoft.Lync.Model.Conversation;
using System.IO.Ports;
using Microsoft.Win32;
using System.Threading;
using System.Net;

namespace TaskTrayApplication
{
    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        bool timedOut = false;
        public DialogResult Result = DialogResult.Yes;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="timeout">Timeout in millisec</param>
        public AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption + " - " + timeout / 1000 + " sec to auto accept";
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
              Result = MessageBox.Show(text, _caption, MessageBoxButtons.YesNoCancel,MessageBoxIcon.Information, MessageBoxDefaultButton.Button1,MessageBoxOptions.ServiceNotification);
            if (timedOut)
                Result = DialogResult.Yes;

            //Result = MessageBox.Show(text, caption + " - " + timeout / 1000 + "sec to auto accept", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        public  void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }

        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow(null, _caption);
            if (mbWnd != IntPtr.Zero)
            {
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                timedOut = true;
            }
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}
