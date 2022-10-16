using Microsoft.EntityFrameworkCore;
using Movie.Models;

namespace Movie.Data
{
    public class FIlmeContext : DbContext
    {
        public FIlmeContext(DbContextOptions<FIlmeContext> opt) : base (opt)
        {

        }
        public DbSet<Filme> Filmes { get; set; }


    }
}
