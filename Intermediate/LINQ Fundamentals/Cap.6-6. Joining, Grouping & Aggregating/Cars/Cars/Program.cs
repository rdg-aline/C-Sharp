using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    class Program
    {
        static void Main(string[] args)
        {
            var cars = ProcessCars("fuel.csv");
            var manufacturers = ProcessManufacturers("manufacturers.csv");


            #region GroupJoin
            /*
            //*** query sintax**
            var query =
                from manufacturer in manufacturers
                join car in cars on manufacturer.Name equals car.Manufacturer
                 into carGroup
                orderby manufacturer.Name
                select new
                {
                    Manufacturer = manufacturer,
                    Cars = carGroup
                };



            //***method sintax****

            var query2 = manufacturers.GroupJoin(
                cars, m => m.Name, c => c.Name,
                (m, g) => new
                {
                    Manufacturer = m,
                    Cars = g
                })
               .OrderBy(m => m.Manufacturer.Name);




            foreach (var group in query2)
            {
                Console.WriteLine($"{group.Manufacturer.Name} : {group.Manufacturer.Headquarters}");
                foreach (var car in group.Cars)
                {
                    Console.WriteLine($"{car.Name}; { car.Combined}");

                }
            }
        */
            #endregion


            #region Group / GroupBy
            /*
            var query =
                from car in cars
                group car by car.Manufacturer into carGroup
                select new
                {
                    Name = carGroup.Key,
                    Max = carGroup.Max(c => c.Combined),
                    Min = carGroup.Min(c => c.Combined),
                    Avg = carGroup.Average(c => c.Combined)
                } into result
                orderby result.Max descending
                select result;


            var query2 =
                cars.GroupBy(c => c.Manufacturer)
                    .Select(g =>
                    {
                        var results = g.Aggregate(new CarStatistics(),
                                            (acc, c) => acc.Accumulate(c),
                                            acc => acc.Compute());
                        return new
                        {
                            Name = g.Key,
                            Avg = results.Average,
                            Min = results.Min,
                            Max = results.Max
                        };
                    })
                    .OrderByDescending(r => r.Max);

            foreach (var result in query2)
            {
                Console.WriteLine($"{result.Name}");
                Console.WriteLine($"\t Max: {result.Max}");
                Console.WriteLine($"\t Min: {result.Min}");
                Console.WriteLine($"\t Avg: {result.Avg}");
            }
         */
            #endregion


            #region Join
            /*
                        //query sintax
                        var query =
                           from car in cars
                           join manufacturer in manufacturers
                               on new { car.Manufacturer, car.Year }
                                  equals  // key shall have same name, so: Manufacturer = manufacturer.Name
                                  new { Manufacturer = manufacturer.Name, manufacturer.Year }
                           orderby car.Combined descending, car.Name ascending
                           select new
                           {
                               manufacturer.Headquarters,
                               car.Name,
                               car.Combined
                           };


                        //method sintax
                        var query2 =
                            cars.Join(manufacturers,
                                         c => c.Manufacturer,
                                         m => m.Name,
                                        (c, m) => new
                                        {
                                            m.Headquarters,
                                            c.Name,
                                            c.Combined
                                        })
                            .OrderByDescending(c => c.Combined)
                            .ThenBy(c => c.Name);




                        foreach (var item in query2.Take(10))
                        {
                            Console.WriteLine($"{item.Headquarters}  - {item.Name} : {item.Combined}");
                        }

                        */

            #endregion


            #region  Aggregate 

            var query =
             from car in cars
             group car by car.Manufacturer into carGroup
             select new
             {
                 Name = carGroup.Key,
                 Max = carGroup.Max(c => c.Combined),
                 Min = carGroup.Min(c => c.Combined),
                 Avg = carGroup.Average(c => c.Combined)
             } into result
             orderby result.Max descending
             select result;


            var query2 =
                cars.GroupBy(c => c.Manufacturer)
                    .Select(g =>
                    {
                        var results = g.Aggregate(new CarStatistics(),
                                            (acc, c) => acc.Accumulate(c),
                                            acc => acc.Compute());
                        return new
                        {
                            Name = g.Key,
                            Avg = results.Average,
                            Min = results.Min,
                            Max = results.Max
                        };
                    })
                    .OrderByDescending(r => r.Max);

            foreach (var result in query2)
            {
                Console.WriteLine($"{result.Name}");
                Console.WriteLine($"\t Max: {result.Max}");
                Console.WriteLine($"\t Min: {result.Min}");
                Console.WriteLine($"\t Avg: {result.Avg}");
            }


            #endregion

        }

        private static List<Car> ProcessCars(string path)
        {
            var query =

                File.ReadAllLines(path)
                    .Skip(1)
                    .Where(l => l.Length > 1)
                    .ToCar();

            return query.ToList();
        }

        private static List<Manufacturer> ProcessManufacturers(string path)
        {
            var query =
                   File.ReadAllLines(path)
                       .Where(l => l.Length > 1)
                       .Select(l =>
                       {
                           var columns = l.Split(',');
                           return new Manufacturer
                           {
                               Name = columns[0],
                               Headquarters = columns[1],
                               Year = int.Parse(columns[2])
                           };
                       });
            return query.ToList();
        }
    }
}
