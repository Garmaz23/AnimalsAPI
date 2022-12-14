using Microsoft.EntityFrameworkCore;

namespace AnimalAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {  }
        public DbSet<Animal> Animals { get; set; }
    }
}
