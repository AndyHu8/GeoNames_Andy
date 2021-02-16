using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNames_Andy
{
    public class countryAdCsvMap : ClassMap<countryAd>
    {
        public countryAdCsvMap()
        {
            Map(x => x.geonameid).Index(0);
            Map(x => x.name).Index(1);
            Map(x => x.asciiname).Index(2);
            Map(x => x.alternatenames).Index(3);
            Map(x => x.latitude).Index(4);
            Map(x => x.longitude).Index(5);
            Map(x => x.featureclass).Index(6);
            Map(x => x.featurecode).Index(7);
            Map(x => x.countrycode).Index(8);
            Map(x => x.cc2).Index(9);
            Map(x => x.admin1code).Index(10).Default(null);
            Map(x => x.admin2code).Index(11).Default(null);
            Map(x => x.admin3code).Index(12).Default(null);
            Map(x => x.admin4code).Index(13).Default(null);
            Map(x => x.population).Index(14);
            Map(x => x.elevation).Index(15);
            Map(x => x.dem).Index(16);
            Map(x => x.timezone).Index(17);
            Map(x => x.moddate).Index(18);
        }
    }
}
