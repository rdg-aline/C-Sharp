using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Band
{
    class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();
            // catalog.GetOi();

            ISaveable save = catalog;
            save.GetOi();
        }
    }

    public class Catalog : ISaveable
    {
        //public void GetOi() -- Standard interface implementation
        void ISaveable.GetOi() // -- explicit interface implementation
        {
            Console.WriteLine("oi");
        }
    }

    public interface ISaveable
    {
        void GetOi();
    }
}
