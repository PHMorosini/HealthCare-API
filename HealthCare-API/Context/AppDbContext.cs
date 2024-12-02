using HealthCare_API.Content.Cliente.Entity;
using Microsoft.EntityFrameworkCore;

namespace HealthCare_API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Content.Cliente.Entity.Cliente> Clientes { get; set; }
        public DbSet<ProblemaSaude> ProblemasSaude { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .HasMany(c => c.ProblemasDeSaude)
                .WithMany(p => p.Clientes)
                .UsingEntity<Dictionary<string, object>>(
                    "ClienteProblemaSaude",
                    j => j.HasOne<ProblemaSaude>().WithMany().HasForeignKey("ProblemaSaudeId"),
                    j => j.HasOne<Cliente>().WithMany().HasForeignKey("ClienteId")
                );
        }
    }

}