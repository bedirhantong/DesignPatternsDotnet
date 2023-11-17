using DesignPatterns.SingletonPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DesignPatterns.SingletonPattern
{
    public class CountryProvider
    {
        private CountryProvider()
        {
            
        }
        private static CountryProvider instance = null;
        private List<Country> Countries { get; set; }
        public static CountryProvider Instance => instance ?? (instance = new CountryProvider());


        public async Task<List<Country>> GetCountries() {

            if (Countries is null)
            {
                // Retrieving data from db
                await Task.Delay(2000);
                Countries =  new List<Country>()
                {
                    new Country(){Name = "Turkey" },
                    new Country(){Name = "Ukraine"}
                };
            }
            return Countries;
        }


        public int CountriesCount => Countries.Count;
    }
}
