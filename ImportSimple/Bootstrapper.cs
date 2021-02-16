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
using Dapper;
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
            string file = "C:\\Users\\hua\\Desktop\\Andy 02.2021\\allCountries.txt";
            List<country> allCountries = ImportFile(file);
            Insert(allCountries);
        }

        public static List<country> ImportFile(string file)
        {
            var config = new CsvConfiguration(CultureInfo.InvariantCulture) //allgemeine Regelung
            {
                Delimiter = "\t", //Tab als Trennung
                HasHeaderRecord = false, //Enthält keinen Header
                Encoding = Encoding.UTF8,
                TrimOptions = TrimOptions.InsideQuotes, //Trennt Leerzeichen innerhalb von ""
                Quote = '"', //Quotes sind "
                Mode = CsvMode.Escape,
                MissingFieldFound = null, //Wenn gefunden, soll keine Exception kommen
                HeaderValidated = null
            };

            using (var streamReader = new StreamReader(file))
            using (var reader = new CsvReader(streamReader, config))
            {
                var csvContext = new CsvContext(reader);

                csvContext.RegisterClassMap<countryCsvMap>();

                return reader.GetRecords<country>().ToList();
            }
        }

        public static void Insert(IEnumerable<country> countries)
        {
            //Dapper
            var sql = @"INSERT INTO Andy.Places0 (IsoCode, PostalCode, PlaceName, AdminName1, AdminCode1, AdminName2, AdminCode2, AdminName3, AdminCode3, Latitude, Longitude, Accuracy)
                        VALUES(@IsoCode, @PostalCode, @PlaceName, @AdminName1, @AdminCode1, @AdminName2, @AdminCode2, @AdminName3, @AdminCode3, @Latitude, @Longitude, @Accuracy)";

            using (var connection = new SqlConnection(Helper.CnnString("Andy.PlacesDB")))
            {
                foreach (var country in countries)
                {
                    connection.Execute(sql, new country
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
                    });
                }
            } 
        }

        public static List<country> DummyData()
        {
            List<country> dummydata = new List<country>();

            country country1 = new country()
            {
                IsoCode = "DZ",
                PostalCode = "01000",
                PlaceName = "Ouled Ali",
                AdminName1 = "Adrar",
                AdminCode1 = "01",
                AdminName2 = null,
                AdminCode2 = null,
                AdminName3 = null,
                AdminCode3 = null,
                Latitude = 52.5252f,
                Longitude = 11.3952f,
                Accuracy = 4
            };

            country country2 = new country()
            {
                IsoCode = "AB",
                PostalCode = "01200",
                PlaceName = "Ouled Ali ndej",
                AdminName1 = "Adrarweq",
                AdminCode1 = "02",
                AdminName2 = null,
                AdminCode2 = "00",
                AdminName3 = "Altmarkkreis Salzwedel",
                AdminCode3 = "00000",
                Latitude = 52.5252f,
                Longitude = 11.3952f,
                Accuracy = 8
            };
            dummydata.Add(country1);
            dummydata.Add(country2);
            return dummydata;
        }
    }
}
