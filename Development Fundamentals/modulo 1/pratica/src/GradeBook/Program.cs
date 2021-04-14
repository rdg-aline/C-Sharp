using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
         static void Main(string[] args)
        {
            var book = new Book(" Livro de notas");
            book.GradeAdded += OnGradeAdded; //evento

            /* book.AddGrade(89.1);
              book.AddGrade(90.5);
              book.AddGrade(77.5);*/


           //refatoração para método da entrada das notas do usuario
           EnterGrades(book);

            #region Const
            Console.WriteLine($"Variavel tipo const: {Book.CATEGORY}");
            #endregion

            var stats = book.GetStatistics();


            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
        }

        #region Métodos

        
        private static void EnterGrades(Book book)
        {
            #region Ask user grades + exceptions 
            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException) // tipo esperado diferente ex. espera int , recebe double
                {
                    Console.WriteLine("formato invalido, insira apenas numeros de  0- 100");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            #endregion
        }


        #region Metodo do Evento
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Event: A grade was added by delegate");
        }
        #endregion


        #endregion

    }
}
