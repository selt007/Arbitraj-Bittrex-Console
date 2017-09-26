using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Arbitraj_Bittrex_Console
{
    class BTC_ETH_X
    {
        public static double profitLTC, profitrevLTC;

        public static void LTC()
        {
            string gm; double ask; double valuex1;
            double bid1; double total2; double bid2;
            double total3; double total = Program.total;

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-ltc").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var Result1 = JsonConvert.DeserializeObject<RootObject1>(gm);

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-eth").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var Result2 = JsonConvert.DeserializeObject<RootObject2>(gm);

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=eth-ltc").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var Result3 = JsonConvert.DeserializeObject<RootObject3>(gm);

            //
            ask = Result1.result.Ask;
            valuex1 = ((total / ask) * 0.9975);
            bid1 = Result2.result.Bid;
            total2 = ((valuex1 * bid1) * 0.9975);
            bid2 = Result3.result.Bid;
            total3 = ((total2 * bid2) * 0.9975);

            if (total3 > total)
            {
                profitLTC = (total3 - total) * 100000000;
                profitLTC = Math.Round(profitLTC, 0);
                Console.WriteLine("Профит BTC-LTC: " + profitLTC + " сатоши");
            }
            else {  }
        }

        public static void revLTC()
        {
            string gm; double ask; double valuex1;
            double bid1; double total2; double bid2;
            double total3; double total = Program.total;

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-ltc").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var Result1 = JsonConvert.DeserializeObject<RootObject1>(gm);

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-eth").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var Result2 = JsonConvert.DeserializeObject<RootObject2>(gm);

            using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=eth-ltc").GetResponse().GetResponseStream()))
                gm = get.ReadToEnd();
            var Result3 = JsonConvert.DeserializeObject<RootObject3>(gm);

            //
            ask = Result3.result.Ask;
            valuex1 = ((total / ask) * 0.9975);
            bid1 = Result2.result.Ask;
            total2 = ((valuex1 * bid1) * 0.9975);
            bid2 = Result1.result.Bid;
            total3 = ((total2 * bid2) * 0.9975);

            if (total3 > total)
            {
                profitrevLTC = (total3 - total) * 100000000;
                profitrevLTC = Math.Round(profitrevLTC, 0);
                Console.WriteLine("Профит BTC-ETH: " + profitrevLTC + " сатоши");
            }
            else { }
        }

        public static void drugaya_valyuta()
        {

        }
    }
}
