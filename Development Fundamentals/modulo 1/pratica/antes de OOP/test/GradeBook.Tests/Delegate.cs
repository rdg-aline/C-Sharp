using System;
using Xunit;

namespace GradeBook.Tests
{

    #region Definir delegate
    
    public delegate string WritelogDelegate(string logMessage);

    #endregion

    public class Delegate
    {
        #region 1-Test: Invocando 1 método
        
        [Fact]
        public void WriteLogDelegatePointToMethod1()
        {
            //log é uma varivavel do tipo delegate
            WritelogDelegate log;

            //iniciar a variavel com  o metodo
            log = new WritelogDelegate(ReturnMessage1); // ou posso fazer:  log =ReturnMessage 

            var result = log("Olá");
            Console.WriteLine($"Sou um delegate {result}");
            Assert.Equal("Olá", result);
         }





       #region Methods
        //método  e o retorno devem ser do mesmo tipo do delegate
        string ReturnMessage1(string message)
        {
               return message;
        }

        #endregion

       
        #endregion


        #region 2-Test: Invocando mais de 1 método

        int count = 0;
     
        [Fact]
        public void WriteLogDelegatePointToMethod()
        {
            
            WritelogDelegate log = ReturnMessage;
            log += ReturnMessage;
            log += IncrementCount;

            var result = log("oi");
          
           Console.WriteLine($"Neste delegate invoquei dois metodos diferentes, {count}");

           Assert.Equal(3, count);
            /*
                Esperado será count = 3
                WritelogDelegate log = ReturnMessage; --> output  count 1
                log += ReturnMessage;--> output  count 2
                log += IncrementCount;--> output  count 3
             */
        }
        #endregion


        #region Methods
        string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }

        string ReturnMessage(string message)
        {
            count++;
            return message;
        }

        #endregion
    }
}
