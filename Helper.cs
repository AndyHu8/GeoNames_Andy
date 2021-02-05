using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNames_Andy
{
    public class Helper
    {
        public static string CnnString(string name) //return Connection String mithilfe vom name="Andy.PlacesDB"
        {
           return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
