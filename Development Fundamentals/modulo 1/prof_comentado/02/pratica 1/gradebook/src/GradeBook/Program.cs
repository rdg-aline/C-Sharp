using System;

namespace GradeBook

{
    class Program
    {
        // dentro do parênteses:  tipo do parâmetro  + nome do parâmetro
            // no exemplo temos:  array de string    + args 
        static void Main(string[] args)
          if (args.Length > 0)
             {
                Console.WriteLine($"Hello, {args[0]}!");
             }
          else 
            {
                Console.WriteLine("Hello!");
            }

    }
}
