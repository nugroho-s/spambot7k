﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace spambot7k
{
    public static class bot
    {
        //import library
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);

        //VK hotkey
        private static int VK_F12 = 0x7B;

        //Mouse Event
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public static void WaitF12()
        {
            WaitKey(VK_F12);
        }

        public static void WaitKey(int key)
        {
            bool stop = false;
            while (!stop)
            {
                //sleeping for while, this will reduce load on cpu
                Thread.Sleep(10);
                for (Int32 i = 0; i < 255; i++)
                {
                    int keyState = GetAsyncKeyState(i);
                    if (keyState == 1 || keyState == -32767)
                    {
                        if (i == key)
                            stop = true;
                        break;
                    }
                }
            }
        }

        public static void Send(String x)
        {
            SendKeys.SendWait(x);
            Thread.Sleep(100);
            SendKeys.SendWait("{enter}");
        }

        public static void SendSpam(String x)
        {
            DoClick();
            Thread.Sleep(200);
            Send(x);
            Thread.Sleep(200);
        }

        public static void SendNotice(String x)
        {
            DoClick();
            Thread.Sleep(500);
            Send(x);
            Thread.Sleep(500);
        }

        public static void DoClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
        }
    }
}
