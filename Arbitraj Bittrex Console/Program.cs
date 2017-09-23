using System;
using System.Threading;

namespace Arbitraj_Bittrex_Console
{
    class Program
    {
        public static double total, total2, total3, valuex1;
        public static double ask, bid1, bid2;

        static void Main(string[] args)
        {
            try
            {
                TimerCallback timeCB = new TimerCallback(Out);
                Timer time = new Timer(timeCB, null, 0, 15000);
                Console.WriteLine("Arbitraj Bittrex запущен...");
                Console.ReadLine();
            }
            catch { Console.WriteLine("Не верный ввод данных!"); Console.ReadLine(); }
        }

        public static void Out(object state)
        {
            total = 0.0005;

            BTC_ETH_X.LTC();
            BTC_LTC_X.ETH();

            if (BTC_ETH_X.profit > BTC_LTC_X.profit)
            {
                Console.WriteLine("pokupaem eth-ltc");
            }
            else
            {
                Console.WriteLine("pokupaem ltc-eth");
            }
        }
    }
}
