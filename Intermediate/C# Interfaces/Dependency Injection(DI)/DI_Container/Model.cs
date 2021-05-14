using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Container
{
    public class Model
    {

        private ICar _car;

        public Model (ICar car)
        {
            _car = car;
        }

        public void RunCar()
        {
            Console.WriteLine("Running {0} - {1} km ", _car.GetType().Name, _car.Run());
        }
    }
}
