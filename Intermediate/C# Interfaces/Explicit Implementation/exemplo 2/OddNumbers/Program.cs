using System;
using System.Collections;
using System.Collections.Generic;

namespace OddNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine ("Odd Numbers:");

            var generator = new OddGenerator();
            IEnumerable x = generator;
            x.GetEnumerator();

            //foreach (var odd in generator)
            //{
            //    if (odd > 50)
            //        break;
            //    Console.WriteLine(odd);
            //}


            Console.Read();
        }
    }
}
