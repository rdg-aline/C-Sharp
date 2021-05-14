using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Container
{
    public class Jaguar : ICar
    {
        private int Km = 22;

        public int Run()
        {
            return ++Km;
        }
    }
}
