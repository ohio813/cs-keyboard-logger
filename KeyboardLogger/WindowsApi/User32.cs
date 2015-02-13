using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KeyboardLogger.WindowsApi
{
    class User32
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, HookProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(HookType hookType, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, WM wParam, [In]KBDLLHOOKSTRUCT lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, WM wParam, [In]MSLLHOOKSTRUCT lParam);
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);
        [DllImport("user32.dll")]
        public static extern uint MapVirtualKey(uint uCode, MapVK uMapType);
    }
}
