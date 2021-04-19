using System;
using System.Collections.Generic;
using System.Linq;

namespace Countries
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Users\Aline Rodrigues\source\repos\Countries\Pop by Largest Final.csv"; // definir o caminho do arquivo CSV- precisa colocar o @
          
            CsvReader reader = new CsvReader(filePath);

            List<Country> countries = reader.ReadAllCountries();

            #region Removing countries with commas
             reader.RemoveCommaCountries(countries);
            #endregion


            #region Insert in the List:  List<T>.Insert()
            /*  Country ilhaDasRosas = new Country("IlhaDasRosas", "IR", "Where you wish", 22000);
              // int index = 1; inormando o indice diretamente ou
              int index = countries.FindIndex(x => x.Population <= 1386395000);
              countries.Insert(index, ilhaDasRosas);
            */
            #endregion


            #region Using LINQ
            //sorting in alphabetical order
            foreach (Country country in countries.OrderBy(x=> x.Name))
             Console.WriteLine($" {country.Name} has population of : {country.Population}");

            #endregion


            #region Enumerating For x Foreach

            /*
              #region Display the number of countries which user request 
              // Ask the user to choose number of countries to display
              Console.Write("Enter no. of countries to display> ");
              bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
              if (!inputIsInt || userInput <= 0)
              {
                  Console.WriteLine("You must type a number. Exiting");
                  return;
              }

              int maxToDisplay = Math.Min(userInput, countries.Count);
              ;
              for (int i = 0; i < maxToDisplay; i++)
              {
                  Country country = countries[i];
                  Console.WriteLine($" {country.Name} has population of : {country.Population}");
              }
              #endregion 


              #region Display some countries and give User option to disply more

              Console.Write("Enter no. of countries to display> ");
              bool inputIsInt = int.TryParse(Console.ReadLine(), out int userInput);
              if (!inputIsInt || userInput <= 0)
              {
                  Console.WriteLine("You must type in a +ve integer. Exiting");
                  return;
              }

              int maxToDisplay = userInput;
              for (int i = 0; i < countries.Count; i++)
              {
                  if (i > 0 && (i % maxToDisplay == 0))
                  {
                      Console.WriteLine("Hit return to continue, anything else to quit>");
                      if (Console.ReadLine() != "")
                          break;
                  }

                  Country country = countries[i];
                  Console.WriteLine($"{i + 1}: {PopulationFormatter.FormatPopulation(country.Population).PadLeft(15)}: {country.Name}");
              }

              #endregion
            */
            #endregion
        }
    }
}
