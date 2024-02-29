using Microsoft.EntityFrameworkCore;

namespace fuszeresAPI.Models
{
    public class FuszeresAdatbazis:DbContext
    {
        public FuszeresAdatbazis(DbContextOptions<FuszeresAdatbazis> options) : base(options) { }

    }
}
