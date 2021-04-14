using System;

namespace Band
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write the name of your band?");
            var nameBand = Console.ReadLine();

            Console.WriteLine("Write the number of musician in your band?");
            var musician = int.Parse(Console.ReadLine());
             Band band = new Band(nameBand,musician);

            #region Methods
            band.Announce();
            #endregion

            // Console.Write($"the band named {nameBand} has{musician} members");
        }
    }
}
