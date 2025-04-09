using Microsoft.EntityFrameworkCore;
using PracticaExamenCasita.Models;

namespace PracticaExamenCasita.Data
{
    public class CubosContext : DbContext
    {
        public CubosContext(DbContextOptions<CubosContext> options) : base(options)
        {
        }
        public DbSet<Cubos> Cubos { get; set; }
    }
}
