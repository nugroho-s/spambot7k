using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace spambot7k
{
    class Program
    {
        // DLL libraries used to manage hotkeys
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        const int MYACTION_HOTKEY_ID = 1;

        private static volatile bool stop = false;

        static void Main(string[] args)
        {
            Console.WriteLine("Tekan F2 untuk mulai spam");
            bot.WaitF2();
            Console.WriteLine("Memulai spam");
            Thread waiter = new Thread(waitstop);
            waiter.Start();
            int spam = 1;
            while (!stop)
            {
                Thread.Sleep(200);
                bot.DoClick();
                bot.send(spam.ToString());
                Thread.Sleep(200);
                spam++;
            }
            waiter.Join();
            return;
        }

        static void waitstop()
        {
            Console.WriteLine("Tekan F2 lagi untuk menghentikan spam");
            bot.WaitF2();
            stop = true;
        }
    }
}
