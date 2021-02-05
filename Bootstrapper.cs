using Autofac;
using CsvHelper;
using CsvHelper.Configuration;
using Landaumedia.CommandCenter.Bootstrapping;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoNames_Andy
{
    class Bootstrapper : BootstrapperBase<LocalSettings>
    {
        protected override void OnBuildup(ContainerBuilder builder)
        {
        }

        static void Main()
        {
            //HostFactory.Run(new Bootstrapper());
            IEnumerable<country> liste = new List<country>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture) //allgemeine Regelung
            {
                Delimiter = "\t"
            };

            using (var reader = new StreamReader("C:\\Users\\hua\\Desktop\\Andy 02.2021\\allCountries.txt"))
            using (var csv = new CsvReader(reader, config))
            {
                liste = csv.GetRecords<country>();
            }
            Insert(liste);
            //namespace von Sql-Tabelle
        }

        public static void Insert(IEnumerable<country> countries)
        {
                //Dapper
                using (IDbConnection connect = new SqlConnection(Helper.CnnString("Andy.PlacesDB")))
                {
                    List<country> liste = new List<country>();

                    foreach (var country in countries)
                    {

                        country newCountry = new country
                        {
                            IsoCode = country.IsoCode,
                            PostalCode = country.PostalCode,
                            PlaceName = country.PlaceName,
                            AdminName1 = country.AdminName1,
                            AdminCode1 = country.AdminCode1,
                            AdminName2 = country.AdminName2,
                            AdminCode2 = country.AdminCode2,
                            AdminName3 = country.AdminName3,
                            AdminCode3 = country.AdminCode3,
                            Latitude = country.Latitude,
                            Longitude = country.Longitude,
                            Accuracy = country.Accuracy
                        };
                        liste.Add(newCountry);
                        
                    }
                    connect.("Andy.Places");
                }
        }
    }
}
