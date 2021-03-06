﻿using Arbitraj_Bittrex_Console.Classes_API_GetMarketHis;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Arbitraj_Bittrex_Console
{
    class BTC_ETH_X
    {
        public static double profitLTC, profitrevLTC, profitETH;
        public static DateTime dateNow = DateTime.Now, date = dateNow.AddHours(-4), 
            timeS, date15 = date.AddSeconds(-15);
        public static string orderT,suck;
        public static double prise;
        public static DateTime[] timeArr1, timeArr2, timeArr3;
        public static string[] orderArr1, orderArr2, orderArr3;
        public static double[] priseArr1, priseArr2, priseArr3;

        public static void LTC()
        {
            string gm; double ask; double valuex1; double zamanuxa = 0.00000010;
            double bid1; double total2; double bid2;
            double total3; double total = Program.total;
            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-ltc").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }

            var Result1 = JsonConvert.DeserializeObject<RootObject1>(gm);
            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-eth").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }

            var Result2 = JsonConvert.DeserializeObject<RootObject2>(gm);
            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=eth-ltc").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Result3 = JsonConvert.DeserializeObject<RootObject3>(gm);

            //
            ask = Result1.result.Bid;
            valuex1 = ((total / ask) * 0.9975);
            bid1 = Result3.result.Bid;
            total2 = ((valuex1 * bid1) * 0.9975);//нет обьёмов!!!
            bid2 = Result2.result.Ask;
            total3 = ((total2 * (bid2 - zamanuxa)) * 0.9975);

            profitLTC = (total3 - total) * 1000;
            profitLTC = Math.Round(profitLTC, 5);
        }

        public static void revLTC()
        {
            string gm; double ask; double valuex1; double zamanuxa = 0.00000010;
            double bid1; double total2; double bid2;
            double total3; double total = Program.total;
            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-ltc").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Result1 = JsonConvert.DeserializeObject<RootObject1>(gm);
            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-eth").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Result2 = JsonConvert.DeserializeObject<RootObject2>(gm);
            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=eth-ltc").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Result3 = JsonConvert.DeserializeObject<RootObject3>(gm);

            //
            ask = Result2.result.Bid;
            valuex1 = ((total / ask) * 0.9975);
            bid1 = Result3.result.Ask;
            total2 = ((valuex1 / bid1) * 0.9975);
            bid2 = Result1.result.Bid;
            total3 = ((total2 * (bid2 + zamanuxa)) * 0.9975);

            profitrevLTC = (total3 - total) * 1000;
            profitrevLTC = Math.Round(profitrevLTC, 5);
        }

        public static void ETH()
        {
            string gm; double ask; double valuex1; /*double zamanuxa = 0.00000010;*/
            double bid1; double total2; double bid2;
            double total3; double total = 1.11495448;//ETH

            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-neo").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch
            { throw; }
            var Result1 = JsonConvert.DeserializeObject<RootObject1>(gm);

            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=btc-eth").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Result2 = JsonConvert.DeserializeObject<RootObject2>(gm);

            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getticker?market=eth-neo").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Result3 = JsonConvert.DeserializeObject<RootObject3>(gm);

            //
            ask = Result3.result.Bid;
            valuex1 = ((total / ask) * 0.9975);
            bid1 = Result1.result.Ask;
            total2 = ((valuex1 * bid1) * 0.9975);
            bid2 = Result2.result.Bid;
            total3 = ((total2 / bid2) * 0.9975);

            profitETH = (total3 - total) * 1000;
            profitETH = Math.Round(profitETH, 5);

            //
            //ETH-X
            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getmarkethistory?market=ETH-NEO").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch
            { throw; }
            var Settings1 = JsonConvert.DeserializeObject<Order1>(gm);

            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getmarkethistory?market=BTC-NEO").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Settings2 = JsonConvert.DeserializeObject<Order2>(gm);

            try
            {
                using (StreamReader get = new StreamReader(WebRequest.Create(@"https://bittrex.com/api/v1.1/public/getmarkethistory?market=BTC-ETH").GetResponse().GetResponseStream()))
                    gm = get.ReadToEnd();
            }
            catch { throw; }
            var Settings3 = JsonConvert.DeserializeObject<Order3>(gm);

            //Массив из джи-сона
            Settings1[] set1 = Settings1.result.ToArray();
            Settings2[] set2 = Settings2.result.ToArray();
            Settings3[] set3 = Settings3.result.ToArray();

            foreach (var Set in set1)
            {
                for (int i = 0; i < set1.Length; i++)
                {
                    //прогон переменных из джисона
                    timeS = set1[i].TimeStamp;
                    orderT = set1[i].OrderType;
                    prise = set1[i].Price;
                    
                    //условия
                    if ((timeS >= date15) && (timeS <= date))
                    {
                        if (orderT == "SELL")
                        {
                            if (prise <= ask)
                            {
                                //добавление в новый массив переменных
                                //для дальнейшей работы
                                for (int j = 0; j < set1.Length; j++)
                                {
                                    //исключения тут
                                    timeArr1[j] = timeS;
                                    orderArr1[j] = orderT;
                                    priseArr1[j] = prise;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var Set in set2)
            {
                for (int i = 0; i < set2.Length; i++)
                {
                    timeS = set2[i].TimeStamp;
                    orderT = set2[i].OrderType;
                    prise = set2[i].Price;

                    if ((timeS >= date15) && (timeS <= date))
                    {
                        if (orderT == "SELL")
                        {
                            if (prise <= ask)
                            {
                                for (int j = 0; j < set2.Length; j++)
                                {
                                    timeArr2[j] = timeS;
                                    orderArr2[j] = orderT;
                                    priseArr2[j] = prise;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var Set in set3)
            {
                for (int i = 0; i < set3.Length; i++)
                {
                    timeS = set3[i].TimeStamp;
                    orderT = set3[i].OrderType;
                    prise = set3[i].Price;

                    if ((timeS >= date15) && (timeS <= date))
                    {
                        if (orderT == "SELL")
                        {
                            if (prise <= ask)
                            {
                                for (int j = 0; j < set3.Length; j++)
                                {
                                    timeArr3[j] = timeS;
                                    orderArr3[j] = orderT;
                                    priseArr3[j] = prise;
                                }
                            }
                        }
                    }
                }
            }

            //
            //BTC-X

        }
    }
}
