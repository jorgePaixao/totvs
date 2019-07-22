using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TotvsPDV.Models
{
    public partial class TotvsPDVContext : DbContext
    {
        public TotvsPDVContext()
        {
        }

        public TotvsPDVContext(DbContextOptions<TotvsPDVContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegistroCaixa> RegistroCaixa { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=DESKTOP-IQECTBL\\SQLEXPRESS;Database=TotvsPDV;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<RegistroCaixa>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");


                entity.Property(e => e.Valor)
                    .HasColumnName("valor")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Dinheiro)
                    .HasColumnName("dinheiro")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Produto)
                    .IsRequired()
                    .HasColumnName("produto")
                    .HasMaxLength(10);

                entity.Property(e => e.Troco)
                    .HasColumnName("troco")
                    .HasColumnType("decimal(18, 0)");
            });
        }
    }
}
