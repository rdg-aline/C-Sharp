using Dependency_Injection_DI_;
using System;
using Xunit;

namespace TestSaudacao
{
    public class UnitTest1
    {
        [Fact]
        public void ValidTest()
        {
            //Arrange
            var saudacao = new Saudacao();
            var service = new GetSaudacao(saudacao);
          

            //Act
            var actual = service.BemVindo("dev team!!");

            //Assert
            Assert.Equal("Bom dia, dev team!!", actual);
        }


        //[Fact]
        //public void InvalidTest()
        //{
        //    Arrange
        //   

        //    Act

        //    Assert



        //}
    }
}
