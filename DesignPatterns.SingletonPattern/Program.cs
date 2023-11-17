using DesignPatterns.SingletonPattern;




Console.WriteLine(DateTime.Now.ToLongTimeString());

var countries = await CountryProvider.Instance.GetCountries();


foreach (var country in countries)
{
    Console.WriteLine(country.Name);
}


var countries1 = await CountryProvider.Instance.GetCountries();

Console.WriteLine(DateTime.Now.ToLongTimeString());


















Console.ReadLine();