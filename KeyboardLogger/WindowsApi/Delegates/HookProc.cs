using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KeyboardLogger.WindowsApi
{
    public delegate IntPtr HookProc(int code, IntPtr wParam, IntPtr lParam);
    public delegate IntPtr LowLevelKeyboardProc(int code, WM wParam, [In]KBDLLHOOKSTRUCT lParam);
    public delegate IntPtr LowLevelMouseProc(int code, WM wParam, [In]MSLLHOOKSTRUCT lParam);
}
