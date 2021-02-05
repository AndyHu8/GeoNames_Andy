using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNames_Andy
{
    public class country
    {
        //country code      : iso country code, 2 characters
        //postal code       : varchar(20)
        //place name        : varchar(180)
        //admin name1       : 1. order subdivision(state) varchar(100)
        //admin code1       : 1. order subdivision(state) varchar(20)
        //admin name2       : 2. order subdivision(county/province) varchar(100)
        //admin code2       : 2. order subdivision(county/province) varchar(20)
        //admin name3       : 3. order subdivision(community) varchar(100)
        //admin code3       : 3. order subdivision(community) varchar(20)
        //latitude          : estimated latitude(wgs84)
        //longitude         : estimated longitude(wgs84)
        //accuracy          : accuracy of lat/lng from 1=estimated, 4=geonameid, 6=centroid of addresses or shape

        public string IsoCode { get; set; }
        public string PostalCode { get; set; }
        public string PlaceName { get; set; }
        public string AdminName1 { get; set; }
        public string AdminCode1 { get; set; }
        public string AdminName2 { get; set; }
        public string AdminCode2 { get; set; }
        public string AdminName3 { get; set; }
        public string AdminCode3 { get; set; }
        public float Latitude { get; set; }
        public float Longitude { get; set; }
        public int Accuracy { get; set; }











    }
}
