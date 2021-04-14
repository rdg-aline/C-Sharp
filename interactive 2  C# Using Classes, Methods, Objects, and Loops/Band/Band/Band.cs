using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Band
{
    public class Band
    {
        string Name;
        int MusiciansQty;

        public List<Musician> Musicians;

        public Band(string name, int musicians)
        {
            Name = name;
            MusiciansQty = musicians;
        }

        public void Announce()
        {
            Console.WriteLine($"Welcome {Name} to the stage....estou no metodo");
        }

        public void AddMusician() 
        {
            var musician = new Musician();
            Console.WriteLine("What is the name of  musician to be added?");
            musician.Name = Console.ReadLine();
            Console.WriteLine("What instrument does?");



        }

    }
}
