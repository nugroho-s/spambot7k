using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace spambot7k
{
    public static class HotKeyManager
    {
        [DllImport("user32.dll")]
        public static extern int GetAsyncKeyState(Int32 i);

        public static void StartLogging()
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
                        if (i == 112)
                            stop = true;
                        break;
                    }
                }
            }
        }
    }
}
