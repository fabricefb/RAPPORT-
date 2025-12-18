using LaDivine.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LaDivine.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Site> Sites { get; set; }
        public DbSet<Employe> Employes { get; set; }
        public DbSet<RapportJournalier> Rapports { get; set; }
        public DbSet<LigneRapport> Lignes { get; set; }
        public DbSet<IndicateurJournalier> Indicateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Site>().HasKey(s => s.Id);
            modelBuilder.Entity<Employe>().HasKey(e => e.Id);
            modelBuilder.Entity<RapportJournalier>().HasKey(r => r.Id);
            modelBuilder.Entity<LigneRapport>().HasKey(l => l.Id);
            modelBuilder.Entity<IndicateurJournalier>().HasKey(i => i.Id);

            modelBuilder.Entity<Employe>()
                .HasOne(e => e.Site)
                .WithMany()
                .HasForeignKey(e => e.SiteId);

            modelBuilder.Entity<RapportJournalier>()
                .HasOne(r => r.Site)
                .WithMany()
                .HasForeignKey(r => r.SiteId);

            modelBuilder.Entity<LigneRapport>()
                .HasOne(l => l.Rapport)
                .WithMany(r => r.Lignes)
                .HasForeignKey(l => l.RapportJournalierId);

            modelBuilder.Entity<IndicateurJournalier>()
                .HasOne(i => i.Rapport)
                .WithMany(r => r.Indicateurs)
                .HasForeignKey(i => i.RapportJournalierId);
        }
    }
}