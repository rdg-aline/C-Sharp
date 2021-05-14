using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_DI_
{
    public class GetSaudacao
    {
        private ISaudacao s;

        public GetSaudacao(ISaudacao injectSaudacao)
        {
            s = injectSaudacao;
        }

       
        public string BemVindo(string nome)
        {
            //var service = new Saudacao ();
            //return service.BomDia(nome);
             return s.BomDia(nome);
        }
    }
}
