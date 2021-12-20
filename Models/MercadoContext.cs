using Microsoft.EntityFrameworkCore;

namespace   MercadoFinanciero.Models
{
    public class MercadoContext : DbContext
    {
        public MercadoContext(DbContextOptions<MercadoContext> options)
            : base(options)
        {
        }

        public DbSet<MercadoF> MercadoFs { get; set; }
    }
}