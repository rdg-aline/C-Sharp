using System;

namespace Interactve1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Challenge 1 
            Console.WriteLine("Hello World!");
            #endregion


            #region Challenge 2
            string venue1 = "C's Blues";
            int bands1 = 4;

            Console.WriteLine($"{venue1} will have {bands1} performing tonight!");
            #endregion


            #region Challenge 3

            Console.WriteLine("What is the name of your band");
            string name = Console.ReadLine();

            Console.WriteLine("How many bands do you have");
            int numberOfMembers = 0;

            //metodo de conversão que não lança exceção

            if (!int.TryParse(Console.ReadLine(), out numberOfMembers))
            {
                Console.WriteLine("input is not valid"); //caso a conversão falhe entra aqui
                Environment.Exit(0); // se der tudo certo sai do programa
            }


            Console.WriteLine($"{name} has {numberOfMembers} members");

            #endregion


            #region Challenge 3.1
            /*
             Task:        
                    Create an if condition that will only print our existing console announcement when TryParse returns true.
                    Use int.TryParse to set bands to the value of bandArgument.
             */

            string venue = args[0];
            string bandArgument = args[1];
            int bands = 0;

            if (int.TryParse(bandArgument, out bands))
            {
                Console.WriteLine(venue + " will have " + bands + " bands performing tonight!");

                if (bands == 0)
                {
                    Console.WriteLine("There will be no performances tonight.");
                }
                else if (bands == 1)
                {
                    Console.WriteLine("It's going to be a fantastic show tonight!");
                }
                else
                {
                    Console.WriteLine("There will be plenty of thrilling performances to see tonight!");
                }
            }
            else
            {
                Console.WriteLine("We were unable to determine the number of bands performing tonight, try again.");
            }

            #endregion

        }

    }

}
