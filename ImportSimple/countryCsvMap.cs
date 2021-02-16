using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNames_Andy
{
    public class countryCsvMap : ClassMap<country>
    {
        public countryCsvMap()
        {
            Map(m => m.IsoCode).Index(0);
            Map(m => m.PostalCode).Index(1);
            Map(m => m.PlaceName).Index(2);
            Map(m => m.AdminName1).Index(3).Default(null);
            Map(m => m.AdminCode1).Index(4).Default(null);
            Map(m => m.AdminName2).Index(5).Default(null);
            Map(m => m.AdminCode2).Index(6).Default(null);
            Map(m => m.AdminName3).Index(7).Default(null);
            Map(m => m.AdminCode3).Index(8).Default(null);
            Map(m => m.Latitude).Index(9);
            Map(m => m.Longitude).Index(10);
            Map(m => m.Accuracy).Index(11);
        }
    }
}
