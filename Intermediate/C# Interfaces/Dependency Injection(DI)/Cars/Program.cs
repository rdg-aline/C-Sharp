using System;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new Honda();
            var model = new Model(car);
            var result = model.GetType().Name();
            
               // service.BemVindo("dev team!!");
            Console.WriteLine(result);
        }
    }
}
