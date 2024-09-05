using LoanApp_API.Models;
using Microsoft.EntityFrameworkCore;

namespace LoanApp_API.Data
{
    public class LoanDbContext : DbContext
    {
        public LoanDbContext(DbContextOptions<LoanDbContext> options) : base(options)
        {
        }
        public DbSet<LoanApp> LoanApps { get; set; }
        public DbSet<Document> Documents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Document>()
                .HasOne(X => X.LoanApp)
                .WithMany(x => x.Documents)
                .HasForeignKey(u => u.LoanAppId);

            modelBuilder.Entity<LoanApp>()
                .Property(x => x.LoanAmount)
                .HasColumnType("decimal");

        }
    }
}
