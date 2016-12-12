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
            writeanim("Bot spam 7k");
            writeanim("Created by IGN puckingfanda");
            writeanim("======================");
            writeanim("Tekan F12 untuk mulai spam");
            bot.WaitF12();
            Console.WriteLine("Memulai spam");
            bot.SendNotice("brace yourself");
            bot.SendNotice("spammer has come");
            var watch = System.Diagnostics.Stopwatch.StartNew();
            Thread waiter = new Thread(waitstop);
            waiter.Start();
            int spam = 1;
            while (!stop)
            {
                bot.SendSpam(spam.ToString());
                //if (spam == 5000)
                //    break;
                spam++;
            }
            watch.Stop();
            bot.SendNotice("======================");
            spam--;
            bot.SendNotice("total spam = " + spam);
            bot.SendNotice("total waktu = " + watch.Elapsed.ToString());
            bot.SendNotice("created by IGN puckingfanda");
            waiter.Join();
            Console.WriteLine("bot dihentikan");
            return;
        }

        static void waitstop()
        {
            Console.WriteLine("Tekan F12 lagi untuk menghentikan spam");
            bot.WaitF12();
            stop = true;
        }

        static void writeanim(String x)
        {
            foreach(char c in x)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            Console.WriteLine();
        }
    }
}
