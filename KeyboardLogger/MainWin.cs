using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using KeyboardLogger.WindowsApi;

namespace KeyboardLogger
{
    public partial class MainWin : Form
    {
        public MainWin()
        {
            InitializeComponent();
            IntPtr p = IntPtr.Zero;
        }
    }
}
