using System.Collections.Generic;

namespace Arbitraj_Bittrex_Console.Classes_API_GetMarketHis
{
    class Order1
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Settings1> result { get; set; }
    }
}
