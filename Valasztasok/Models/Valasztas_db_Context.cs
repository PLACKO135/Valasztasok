using Microsoft.EntityFrameworkCore;

namespace Valasztasok.Models
{
    public class Valasztas_db_Context : DbContext
    {
        public Valasztas_db_Context(DbContextOptions<Valasztas_db_Context> options) :base(options)
        {
            
        }

        public DbSet<Jelolt> Jeloltek {  get; set; }
        public DbSet<Part>Partok  {  get; set; }

    }
}
