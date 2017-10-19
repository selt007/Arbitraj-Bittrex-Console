using System;
using System.Reflection;

namespace Arbitraj_Bittrex_Console
{
    public partial class AppJson
    {
        public AppJson() : base()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("Newtonsoft.Json"))
            {
                return Assembly.Load(Properties.Resources.Newtonsoft_Json);
            }
            return null;
        }
    }
    public partial class AppNLog
    {
        public AppNLog() : base()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("NLog"))
            {
                return Assembly.Load(Properties.Resources.NLog);
            }
            return null;
        }
    }
    public partial class AppCfg
    {
        public AppCfg() : base()
        {
            AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        }
        Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            if (args.Name.Contains("NLog.config"))
            {
                return Assembly.Load(Properties.Resources.NLog);
            }
            return null;
        }
    }
}
