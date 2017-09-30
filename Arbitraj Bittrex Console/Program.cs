using System;
using System.Linq;
using System.Threading;

namespace Arbitraj_Bittrex_Console
{
    class Program
    {
        public static double total, profitMax;

        static void Main(string[] args)
        {
            try
            {
                TimerCallback timeCB = new TimerCallback(Out);
                Timer time = new Timer(timeCB, null, 0, 15000);
                void GG(object state)
                {
                    if (profitMax <= 0)
                    {
                        Logs.LogBad();
                    }
                    else { Logs.LogGood(); }
                }
                TimerCallback timeCB1 = new TimerCallback(GG);
                Timer time1 = new Timer(timeCB1, null, 0, 15000);
                Console.WriteLine("Arbitraj Bittrex запущен...");
                Console.WriteLine("------------------------------");
                Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Упс... Какая-то ошибка... :(");
                Console.Beep();
                Console.ReadLine();
                Console.OpenStandardError();
            }
        }
        
        public static void Out(object state)
        {
            total = 0.0005;

            BTC_ETH_X.LTC();
            BTC_ETH_X.revLTC();
            
            double[] arrProf = { BTC_ETH_X.profitLTC, BTC_ETH_X.profitrevLTC };
            profitMax = arrProf.Max();
            
            if (profitMax <= 0)
            {
                Console.Clear();
                Console.WriteLine("Arbitraj Bittrex запущен...");
                Console.WriteLine("------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Data now: " + DateTime.Now);
                Console.WriteLine("Normal: " + BTC_ETH_X.profitLTC + " mBTC");
                Console.WriteLine("Revers: " + BTC_ETH_X.profitrevLTC + " mBTC");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("XEPH9 !!!");
                Console.ResetColor();
                Console.WriteLine("------------------------------");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Arbitraj Bittrex запущен...");
                Console.WriteLine("------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Data now: " + DateTime.Now);
                Console.WriteLine("Normal: " + BTC_ETH_X.profitLTC + " mBTC");
                Console.WriteLine("Revers: " + BTC_ETH_X.profitrevLTC + " mBTC");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("PROFIT ---->>> " + profitMax + " mBTC");
                Console.ResetColor();
                Console.WriteLine("------------------------------");
                Console.ReadLine();
            }
        }
    }
}
