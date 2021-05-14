using Ninject;
using System;
using Unity;

namespace DI_Container
{
    class Program
    {
        static void Main()
        {
            //IKernel container = new StandardKernel();
            //container.Bind<ICar>()
            //         .To<BMW>();




            var container = new UnityContainer();
            // container.RegisterType<ICar,BMW>();
            // container.RegisterType<ICar,Honda>();
            container.RegisterType<ICar, Jaguar>();
            var driver = container.Resolve<Model>();
            driver.RunCar();



        }
    }
}
