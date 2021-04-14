using System;
using System.Collections.Generic;

namespace GradeBook
{

    #region Delegate
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    #endregion

    public class Book : NamedObject // book : herda tudo de NamedObject
    {
        #region Constructors
        public Book(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        #endregion
       

        #region Methods
        public void AddGrade(double grade)
        {

             if (grade >= 0 && grade <= 100)
               {
                   grades.Add(grade);
                   if (GradeAdded != null)
                   {
                       GradeAdded(this, new EventArgs());
                   }
               }
               else if (grade > 100)
               {
                throw new ArgumentException($"mensagem de erro maior que cem {nameof(grade)}");
               }
            else
            {
                //Console.WriteLine("Invalid value");
                //exception Argument :  entrada invalida ex nota 105
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
                                   
        }




        // retorno um objeto do tipo Statistics
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;



            #region Uso do While
            var index = 0;
            while(index < grades.Count)
            {
                result.Low = Math.Min(grades[index], result.Low);
                result.High = Math.Max(grades[index], result.High);
                result.Average += grades[index];
                index++;
            };
            result.Average /= grades.Count;

            return result;
            #endregion

            #region Uso do foreach
            /*
            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);
                result.Average += grade;
            }
            result.Average /= grades.Count;

            return result;*/
            #endregion

        }
        #endregion




        #region Properties
        //  obter e definir valores, ocultando a implementaçao (restringe acesso ao variavel name)
    /*    public string Name
        {
            get
            {
                return  name;
            }
            set 
            {
                if(!String.IsNullOrEmpty(value))
                //if(value != null)   
                { 
                    name = value;  
                }    
                else 
                {
                   //Console.WriteLine("Nome não pode ser vazio");
                  //  throw new ArgumentException($"Nome não pode ser vazio {nameof(name)}");        
                }
            }

        }
    */
        #endregion

       


        #region Variaveis

        #region Const
        // posso declarar em qualquer lugar
        public const string CATEGORY  = "Science";
        #endregion

        #region Delegate
        public event GradeAddedDelegate GradeAdded;
        #endregion

        private List<double> grades;
        private string name;
       #endregion
     
    }
}


