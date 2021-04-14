using System;
using Xunit;

namespace GradeBook.Tests
{
     public class BookTests
    {
        //Fact é para identificar os testes
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // act
            var result = book.GetStatistics();

            // assert
            Assert.Equal(85.6, result.Average, 1);            
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1); //(esperado,atual,numero de casas decimais)
           



            /* Simple test

            var x = 2;
            var y = 5;
            var actual  = x * y;
            var expected = 7;

            Assert.Equal(expected,actual);
            
             */

              
        }
    }
}
