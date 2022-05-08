using Microsoft.EntityFrameworkCore;
using NextSoft.Models;

namespace NextSoft.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Condominio> Condominio { get; set; }
        public DbSet<Familia> Familia { get; set; }
        public DbSet<Morador> Morador { get; set; }
    }
}
