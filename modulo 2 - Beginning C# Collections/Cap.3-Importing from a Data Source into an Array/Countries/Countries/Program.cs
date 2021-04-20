using System;
using System.Collections.Generic;

namespace Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Aline Rodrigues\source\repos\Countries\Pop by Largest Final.csv"; // definir o caminho do arquivo CSV- precisa colocar o @
          
            CsvReader reader = new CsvReader(filePath);

            //Against using array definition as below: 
            //Country[] countries = reader.ReadFirstNCountries(10);
            // it can run using the array with an interface, like this:
            IList<Country> countries = reader.ReadFirstNCountries(10);
         
            foreach(Country country in countries)
            {
              Console.WriteLine($" The {country.Name} which code is {country.Code},belong to {country.Region} has population of : {country.Population}");

            }



        }
    }
}
