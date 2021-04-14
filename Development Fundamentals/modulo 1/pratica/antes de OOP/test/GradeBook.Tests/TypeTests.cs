using System;
using Xunit;

namespace GradeBook.Tests
{

    public class TypeTests
    {
        /* Task:
              invocar um metodo que instacia a classe livro
              testar se :
                          cada livro retornado do objeto é
                          o mesmo objeto ou um objeto diferente
       */

        #region 1-Teste: 2 variaveis retornam diferentes objetos
        [Fact]
        public void GetDiffObjectTest()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");


            //assert
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }
        #endregion

        #region 2-Teste:  2 variaveis podem referenciar o mesmo objeto
        [Fact]
      
        public void TwoVarCanReferToSameObjectTest()
        {
            //arrange
            var book1 = GetBook("Book 1");
            var book2 = book1;


            //assert
            Assert.Same(book1,book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        #endregion

        #region 3-Teste: Alterar nome do livro por referencia
        [Fact]
        public void  SetNameByReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        #endregion


        #region 4-Teste: C# passando parâmetro por valor x referência 
        [Fact]
        public void PassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetNameRef(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);
           
        }


        [Fact]
        public void PassByValue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);
        
        }
        #endregion

        #region Exemplo: passando parâmetro por valor
        /*
            class PassingValByVal
            {
                static void SquareIt(int x)
                // The parameter x is passed by value.
                // Changes to x will not affect the original value of x.
                {
                    x *= x;
                    System.Console.WriteLine("The value inside the method: {0}", x);
                }
                static void Main()
                {
                    int n = 5;
                    System.Console.WriteLine("The value before calling the method: {0}", n);

                    SquareIt(n);  // Passing the variable by value.
                    System.Console.WriteLine("The value after calling the method: {0}", n);

                }
            }*/
        /* Output:
            The value before calling the method: 5
            The value inside the method: 25
            The value after calling the method: 5
        */
        #endregion


        #region 5-Teste:  Verificando mensagem da exceção 
        [Fact]
        public void TesteDeExcecao()
        {
            var book = new Book("New book");
            var ex = Assert.Throws<ArgumentException>(() => book.AddGrade(105));

           Assert.Equal("mensagem de erro maior que cem grade", ex.Message);

        }
        #endregion

        #region Methods
        Book GetBook(string name)
        {
            return new Book(name);
        }
        
        private void SetName(Book book,string name)
        {
            book.Name = name;
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
           // book.Name = name; 
        }

        private void GetBookSetNameRef(ref Book book, string name)
        {
            book = new Book(name);
        }

        #endregion
    }
}
