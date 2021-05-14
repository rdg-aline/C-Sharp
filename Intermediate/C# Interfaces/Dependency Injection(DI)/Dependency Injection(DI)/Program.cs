using System;

namespace Dependency_Injection_DI_
{
    class Program
    {
        static void Main()
        {

            // var service = new GetSaudacao();
            // var result = service.BemVindo("dev team")
            var saudacao = new Saudacao();
            var service = new GetSaudacao(saudacao);
            var result = service.BemVindo("dev team!!");
            Console.WriteLine(result);
        }
    }
}

