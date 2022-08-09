using EF_6_BenchMark.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_6_BenchMark.Infra
{
    public partial class BenchMarkingDBContext : DbContext
    {
        public BenchMarkingDBContext()
        {
        }
        public BenchMarkingDBContext(DbContextOptions<BenchMarkingDBContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=ALIKOLAHDOOZAN;Database=BenchMarkDB;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<BenchMarkTablewith5000Records> BenchMarkTable { get; set; } = null!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BenchMarkTablewith5000Records>(entity =>
            {
                entity.ToTable("BenchMarkTablewith5000Records");
                entity.Property(e => e.ID).HasColumnName("ID");
                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Family)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Age)
                    .IsUnicode(false);
                entity.Property(e => e.Address)
                    .HasMaxLength(300)
                    .IsUnicode(false);
                entity.Property(e => e.PostalCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
