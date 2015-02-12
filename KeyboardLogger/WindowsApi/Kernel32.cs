using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace KeyboardLogger.WindowsApi
{
    class Kernel32
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}
