using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeyGrabAndSend
{
    public class KeySend
    {
        #region WinAPI imports
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("User32.Dll", EntryPoint = "PostMessageA")]
        static extern bool PostMessage(IntPtr hWnd, uint msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern byte VkKeyScan(char ch);

        [DllImport("User32.dll")]
        static extern uint SendInput(uint numberOfInputs, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] INPUT[] input, int structSize);
        #endregion

        #region WinAPI consts and structs
        const uint WM_KEYDOWN = 0x100;
        const uint WM_KEYUP = 0x101;

        [StructLayout(LayoutKind.Explicit)]
        struct INPUT
        {
            [FieldOffset(0)]
            public int type;
            /*
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            */
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            /*
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
            */
        }

        [StructLayout(LayoutKind.Sequential)]
        struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        #endregion

        /// <summary>
        /// Send a message to all windows with a process name that matches
        /// </summary>
        /// <param name="WindowName">Process name to search for</param>
        /// <param name="MessageToSend">Message to send to that window</param>
        /// <returns>Operation success / failed</returns>
        public static bool SendToWindow(string WindowName, string MessageToSend)
        {
            // Convert the string to an array of ints, representing the key scan codes
            int[] SpecialMessage = ConvertStringToKeyScan(MessageToSend);

            return SendToWindow(WindowName, SpecialMessage);
        }

        /// <summary>
        /// Send a message to all windows with a process name that matches
        /// </summary>
        /// <param name="WindowName">Process name to search for</param>
        /// <param name="MessageToSend">Message to send to that window</param>
        /// <returns>Operation success / failed</returns>
        public static bool SendToWindow(string WindowName, int[] SpecialMessageToSend)
        {
            bool result = false;

            // Find the window (process)
            Process[] Processes = Process.GetProcessesByName(WindowName);

            // Send to all matching windows
            foreach (Process proc in Processes)
            {
                // Get the window's handle
                IntPtr hWnd = FindWindowEx(proc.MainWindowHandle, IntPtr.Zero, "edit", null);

                // Send the message
                foreach (int Param in SpecialMessageToSend)
                {
                    result = PostMessage(hWnd, WM_KEYDOWN, Param, 0);
                    Thread.Sleep(10);
                    /*
                    if (result)
                    {
                        result = PostMessage(hWnd, WM_KEYUP, Param, 0);
                    }
                    Thread.Sleep(10);*/
                    if (result == false)
                    {
                        break;
                    }
                }

                if (result == false)
                {
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Convert a string to an int array of keyboard scan codes
        /// </summary>
        /// <param name="str">String to convert</param>
        /// <returns>int array of keyboard scan codes</returns>
        private static int[] ConvertStringToKeyScan(string str)
        {
            List<int> KeyScans = new List<int>();
            foreach (char c in str)
            {
                KeyScans.Add(VkKeyScan(c));
            }

            return KeyScans.ToArray();
        }
    }
}
