using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6_BenchMark.EF_6_Performance.Entity
{
    public partial class StockMarketContext : DbContext
    {


        public StockMarketContext()
        {
        }
        public StockMarketContext(DbContextOptions<StockMarketContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ALIKOLAHDOOZAN;Database=BenchMarkDB;Trusted_Connection=True;",
                 options => options.EnableRetryOnFailure(
                maxRetryCount: 4,
                maxRetryDelay: TimeSpan.FromSeconds(1),
                errorNumbersToAdd: new int[] { }
            ));
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<StockMarket> StockMarket { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockMarket>(entity =>
            {
                entity.ToTable("StockMarket");
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Family)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.StockShare)
                    .IsUnicode(false);
                entity.Property(e => e.State)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
