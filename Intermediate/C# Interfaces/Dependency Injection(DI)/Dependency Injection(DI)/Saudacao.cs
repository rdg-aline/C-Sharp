using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection_DI_
{
    public class Saudacao : ISaudacao
    {
        public string BomDia(string nome)
        {
            return $"Bom dia, {nome}";

        }

    }
}
