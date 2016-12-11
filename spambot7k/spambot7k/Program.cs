using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Tekan F2 untuk mulai spam");
            bot.StartLogging();
            Console.WriteLine("Memulai spam");
            bot.DoClick();
            bot.send("coba");
            return;
        }
    }
}
