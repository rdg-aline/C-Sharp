using System;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
           
          // the way of array is initialized is the order which will be followed
          string [] daysOfWeek =
            {
                "Monday",
                "Tuesday",
                "wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday"
            };

            #region Enumerating an Array
            /// List all day of week in order
            foreach (string day in daysOfWeek)
            {
                Console.WriteLine(day);
            }
            #endregion
            


            #region Looking  up Array Items

            Console.WriteLine("Which day do you want to display?");
            Console.WriteLine("Monday = 1,etc");
            int iDay = int.Parse(Console.ReadLine());

            //string chosenDay = daysOfWeek[iDay];

            string chosenDay = daysOfWeek[iDay-1]; //One-base-index

            Console.WriteLine($"That day is {chosenDay}");


            #endregion




            #region Replace array item
            
            daysOfWeek[2] = "Aline";

            Console.WriteLine("\nBefore:");
            foreach (string day in daysOfWeek)
                Console.WriteLine(day);

            Console.WriteLine("\nAfter:");
            foreach (string day in daysOfWeek)
                Console.WriteLine(day);
            #endregion

        }

    }
}
