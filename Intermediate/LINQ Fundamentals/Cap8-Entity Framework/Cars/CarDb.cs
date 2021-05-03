using System.Data.Entity;

namespace Cars
{
  
    public class CarDb : DbContext
    {
        // this property represent my table in SQL pq é do tipo DbSet<Car> 
        public DbSet<Car> Cars { get; set; }
    }
}
