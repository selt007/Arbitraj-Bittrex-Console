using NLog;

namespace Arbitraj_Bittrex_Console
{
    class Logs
    {
        public static Logger logger = LogManager.GetCurrentClassLogger();

        public static void LogBad()
        {
            logger.Trace("Normal: " + BTC_ETH_X.profitLTC + " mBTC");
            logger.Trace("Revers: " + BTC_ETH_X.profitrevLTC + " mBTC");
            logger.Trace("XEPH9 !!!");
            logger.Trace("------------------------------");
        }
        public static void LogGood()
        {
            logger.Trace("Normal: " + BTC_ETH_X.profitLTC + " mBTC");
            logger.Trace("Revers: " + BTC_ETH_X.profitrevLTC + " mBTC");
            logger.Trace("PROFIT ---->>> " + Program.profitMax + " mBTC");
            logger.Trace("------------------------------");
        }
    }
}
