using Microsoft.EntityFrameworkCore;

namespace AppLembrarData.Entity.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<Compromisso> Compromissos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Compromisso>(p =>
            {

                p.ToTable("Compromissos");
                p.HasKey(c => c.Id);

            });

        }
    }
}
