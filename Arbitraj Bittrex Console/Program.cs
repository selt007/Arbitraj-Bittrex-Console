using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace Arbitraj_Bittrex_Console
{
    class Program
    {
        public static int x = 200, last = 0;
        public static double SMA = 0, SMAl = 0, SMAh = 0, period = 0, sum = 0, sum1 = 0;
        public static double total, total2, total3, valuex1, profit;
        public static double BTCLTCbid, BTCLTCask, ETHLTCbid, ETHLTCask, BTCETHbid, BTCETHask;

        static void Main(string[] args)
        {
            try
            {
                TimerCallback timeCB = new TimerCallback(Out);
                Timer time = new Timer(timeCB, null, 0, 20000);
                Console.WriteLine("Arbitraj Bittrex запущен...");
                Console.ReadLine();
            }
            catch { Console.WriteLine("Не верный ввод данных!"); Console.ReadLine(); }
        }

        public static void Bot()
        {
            string gm;

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-ltc").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var ResultBTCLTC = JsonConvert.DeserializeObject<roBTCLTC>(gm);

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-eth").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var ResultBTCETH = JsonConvert.DeserializeObject<roBTCETH>(gm);

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=eth-ltc").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var ResultETHLTC = JsonConvert.DeserializeObject<roETHLTC>(gm);

            //
            total = 0.00050000;
            BTCLTCbid = ResultBTCLTC.result.Bid;
            BTCLTCask = ResultBTCLTC.result.Ask;
            valuex1 = ((total / BTCLTCask) * 0.9975);
            ETHLTCbid = ResultETHLTC.result.Bid;
            ETHLTCask = ResultETHLTC.result.Ask;
            total2 = ((valuex1 * ETHLTCbid) * 0.9975);
            BTCETHbid = ResultBTCETH.result.Bid;
            BTCETHask = ResultBTCETH.result.Ask;
            total3 = ((total2 * BTCETHbid) * 0.9975);

            if (total3 > total) { profit = (total3 - total) * 100000;
                Console.WriteLine("Профит: " + profit + " * 10 ^ 6");
            }
            else { Console.ReadLine(); }
        }
        public static void Out(object state)
        {
            Bot();
            //Console.WriteLine("Введите количество сатоши: ");
            //total = Console.Read();
            //Console.WriteLine("-------------------------------------------------------------");
            //Console.ForegroundColor = ConsoleColor.DarkGray;
            //Console.WriteLine("Время сейчас (по Гринвичу): " + DateTime.UtcNow);
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine("Профит: " + profit);
            //Console.ResetColor();
            //Console.WriteLine("-------------------------------------------------------------" + "\n");
        }
    }
}
