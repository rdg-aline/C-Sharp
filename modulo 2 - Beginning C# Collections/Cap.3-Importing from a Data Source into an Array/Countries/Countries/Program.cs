using System;

namespace Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Aline Rodrigues\source\repos\Countries\Pop by Largest Final.csv"; // definir o caminho do arquivo CSV- precisa colocar o @
          
            CsvReader reader = new CsvReader(filePath);

            Country[] countries = reader.ReadFirstNCountries(10);
         
            foreach(Country country in countries)
            {
              Console.WriteLine($" The {country.Name} which code is {country.Code},belong to {country.Region} has population of : {country.Population}");

            }



        }
    }
}
