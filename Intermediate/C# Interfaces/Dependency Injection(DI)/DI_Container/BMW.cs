using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Container
{
    public class BMW : ICar
    {
        private int Km = 15;

        public int Run()
        {
            return ++Km;
        }
    }
      
}
