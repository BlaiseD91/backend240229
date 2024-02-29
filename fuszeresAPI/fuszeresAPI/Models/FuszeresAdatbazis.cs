using Microsoft.EntityFrameworkCore;

namespace fuszeresAPI.Models
{
    public class FuszeresAdatbazis:DbContext
    {
        public FuszeresAdatbazis(DbContextOptions<FuszeresAdatbazis> options) : base(options) { }
        public DbSet<Fuszer> fuszerek { get; set; }
        public DbSet<Keverek> keverekek { get; set; }
        public DbSet<Komponens> komponensek { get; set; }

        
    }
}
