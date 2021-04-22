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

            //fill the Country collection calling ReadAllCountries method
            Dictionary<string, List<Country>> countries = reader.ReadAllCountries();
            
            // Display title of app.
            Console.WriteLine("Country list");
            Console.WriteLine("------------------------\n");

            // Ask the user to choose an option.
            while (true)
            {
               Console.WriteLine("Choose an option from the following list:" +
               "\n 1 - Check the country per code " +
               "\n 2 - List all countries'name and codes" +
               "\n 3 - Display countries per region" +
               "\n 4 - Exit application \n ");
                

                var userOption = Console.ReadLine();
                if (userOption == "1")
                {

                    /*Console.WriteLine("Which country code do you want to look up? ");
                    string userInput = Console.ReadLine().ToUpper();

                  

                    bool gotCountry = countries.TryGetValue(userInput, out Country  country);

                    if (!gotCountry)
                        Console.WriteLine($"Sorry, there is no country with code, {userInput}");
                    else
                        Console.WriteLine($"{country.Name}, which code is {country.Code}, has population {PopulationFormatter.FormatPopulation(country.Population)} and belong to {country.Region} ");

                    */
                    Console.WriteLine("option1");
                }
                else if (userOption == "2")
                {
                   foreach (var dicCountry in countries)//access the dicionary per key
                    {
                       foreach(var country in dicCountry.Value) // access the list in dicionary
                         Console.WriteLine($"Code: {country.Code} - Name: {country.Name}");
                    }

                }
                else if (userOption == "3")
                {
                    //Display all the regions
                    foreach (string region in countries.Keys)
                        Console.WriteLine(region);

                    Console.Write("\n Which of the above regions do you want?");
                    string chosenRegion = Console.ReadLine();
               

                    Console.WriteLine(chosenRegion);
                    if (countries.ContainsKey(chosenRegion))
                    {
                        // display 10 highest population countries in the selected region
                        foreach (Country country in countries[chosenRegion].Take(10))
                            Console.WriteLine($"{PopulationFormatter.FormatPopulation(country.Population).PadLeft(5)}: {country.Name}");
                    }
                    else
                        Console.WriteLine("That is not a valid region");

                }
                else if (userOption == "4")
                {
                    Console.WriteLine("See you next time");
                    break;
                }
                else
                    Console.WriteLine("This is not a valid option, please choose from 1 to 4");
            }
        }
    }
}
