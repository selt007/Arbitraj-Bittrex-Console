using System.Collections.Generic;

namespace Arbitraj_Bittrex_Console.Classes_API_GetMarketHis
{
    class Order2
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<Settings2> result { get; set; }
    }
}
