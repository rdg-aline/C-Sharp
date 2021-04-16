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

            List<Country> countries = reader.ReadAllCountries();



            #region Insert in the List:  List<T>.Insert()
            Country ilhaDasRosas = new Country("IlhaDasRosas", "IR", "Where you wish",22000);
            // int index = 1; inormando o indice diretamente ou
            int index = countries.FindIndex(x=>x.Population <= 1386395000);
            countries.Insert(index,ilhaDasRosas);
            #endregion



            foreach (Country country in countries)
            {
                // Console.WriteLine($" The {country.Name} which code is {country.Code},belong to {country.Region} has population of : {country.Population}");
                  Console.WriteLine($" {country.Name} has population of : {country.Population}");
             

            }



        }
    }
}
