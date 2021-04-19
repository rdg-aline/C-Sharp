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

            Dictionary<string, Country> countries = reader.ReadAllCountries();


            // Display title of app.
            Console.WriteLine("Country list");
            Console.WriteLine("------------------------\n");

            // Ask the user to choose an option.
            while (true)
            {
               Console.WriteLine("Choose an option from the following list:" +
               "\n 1 - Check the country per code " +
               "\n 2 - List all countries'name and codes" +
               "\n 3 - Exit application \n ");
                

                var userOption = Console.ReadLine();
                if (userOption == "1")
                {

                    Console.WriteLine("Which country code do you want to look up? ");
                    string userInput = Console.ReadLine().ToUpper();

                    bool gotCountry = countries.TryGetValue(userInput, out Country country);
                    if (!gotCountry)
                        Console.WriteLine($"Sorry, there is no country with code, {userInput}");
                    else
                        Console.WriteLine($"{country.Name}, which code is {country.Code}, has population {PopulationFormatter.FormatPopulation(country.Population)} and belong to {country.Region} ");


                    Console.WriteLine();
                }
                else if (userOption == "2")
                {
                    foreach (Country nextCountry in countries.Values)
                        Console.WriteLine($"Code: {nextCountry.Code} - Name: {nextCountry.Name}");
                    Console.WriteLine();
                }
                else if (userOption == "3")
                {
                    Console.WriteLine("See you next time");
                    break;
                }
                else
                    Console.WriteLine("This is not a valid option, please choose from 1 to 3");
            }
        }
    }
}
