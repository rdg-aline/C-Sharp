
using System;
using System.Collections.Generic;

namespace Features
{
    class Program
    {
        static void Main(string[] args)
        {

           IEnumerable<Employee> developers = new Employee[]
          // Employee[] developers = new Employee[]
           {
                new Employee { Id = 1, Name= "Scott" },
                new Employee { Id = 2, Name= "Chris" }
           };

            IEnumerable <Employee> sales = new List<Employee>()
            //List <Employee> sales = new List<Employee>()
            {
                new Employee { Id = 3, Name = "Alex" }
            };

            //foreach statment  behide the scene 
            IEnumerator<Employee> enumerator = developers.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current.Name);
            }

            /*
                foreach (var person in sales)
                {
                    Console.WriteLine(person.Name);
                }
             */
        }
    }
}
