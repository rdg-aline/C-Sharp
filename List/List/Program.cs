using System;
using System.Collections.Generic;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new List<string> { "<name>", "Ana", "Felipe" };
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }

            Console.WriteLine("Lista atualizada Nomes adicionados e removidos");
            names.Add("Maria");
            names.Add("Bill");
            names.Remove("Ana");
         
            foreach (var name in names)
            {
                Console.WriteLine($"Hello {name.ToUpper()}!");
            }


            Console.WriteLine($"My name is {names[0]}."); // retorna o nome com indice 0
            Console.WriteLine($"I've added {names[2]} and {names[3]} to the list.");





            // names.Clear();
            //Console.WriteLine("Todos os itens removidos da lista");

            nameExist(names);
        }
        /// <summary>
        /// The IndexOf method searches for an item and returns the index of the item.
        /// <br>If the item isn't in the list, IndexOf returns -1</br>
        /// </summary>
        /// <param name="name"></param>
        /// <param name="names"></param>
        public static void nameExist(List<string> names)
        {
            var index = names.IndexOf("Aline");
            if (index != -1)
                Console.WriteLine($"The name {names[index]} is at index {index}");

            var notFound = names.IndexOf("Not Found");
            Console.WriteLine($"When an item is not found, IndexOf returns {notFound}");

        }
    }
}
