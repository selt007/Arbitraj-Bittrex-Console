using System;
using System.Linq;
using System.Threading;

namespace Arbitraj_Bittrex_Console
{
    class Program
    {
        public static double total;

        static void Main(string[] args)
        {
            try
            {
                TimerCallback timeCB = new TimerCallback(Out);
                Timer time = new Timer(timeCB, null, 0, 15000);
                Console.WriteLine("Arbitraj Bittrex запущен...");
                Console.ReadLine();
            }
            catch { Console.WriteLine("Упс... Какая-то ошибка... :("); Console.ReadLine(); }
        }

        public static void Out(object state)
        {
            total = 0.0005;

            BTC_ETH_X.LTC();
            BTC_ETH_X.revLTC();

            double profitMax;
            double[] arrProf = { BTC_ETH_X.profitLTC, BTC_ETH_X.profitrevLTC };
            profitMax = arrProf.Max();

            if (profitMax == 0) { Console.ReadLine(); }
            else { Console.WriteLine(profitMax); }
        }
    }
}
