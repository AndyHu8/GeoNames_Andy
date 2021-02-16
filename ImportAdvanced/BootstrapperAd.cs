using Autofac;
using Landaumedia.CommandCenter.Bootstrapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNames_Andy
{
    class BootstrapperAd : BootstrapperBase<LocalSettings>
    {
        protected override void OnBuildup(ContainerBuilder builder)
        {
        }

        static void Main()
        {
            //HostFactory.Run(new Bootstrapper());
            string file = "C:\\Users\\hua\\Desktop\\Andy 02.2021\\allCountries.txt";
            List<country> allCountries = ImportFile(file);
            Insert(allCountries);
        }
    }
}
