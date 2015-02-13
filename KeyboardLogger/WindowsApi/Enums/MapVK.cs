using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyboardLogger.WindowsApi
{
    enum MapVK
    {
        MAPVK_VK_TO_VSC = 0x00,
        MAPVK_VSC_TO_VK = 0x01,
        MAPVK_VK_TO_CHAR = 0x02,
        MAPVK_VSC_TO_VK_EX = 0x03,
        MAPVK_VK_TO_VSC_EX = 0x04
    }
}
