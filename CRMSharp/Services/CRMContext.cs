using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CRMSharp.Models;

namespace CRMSharp.Services
{
    public partial class CRMContext : DbContext
    {

        public CRMContext(DbContextOptions<CRMContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address).HasColumnName("address");

                entity.Property(e => e.City)
                    .HasMaxLength(15)
                    .HasColumnName("city");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(100)
                    .HasColumnName("companyname");

                entity.Property(e => e.Country)
                    .HasMaxLength(15)
                    .HasColumnName("country");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(100)
                    .HasColumnName("firstname");

                entity.Property(e => e.LastName)
                    .HasMaxLength(100)
                    .HasColumnName("lastname");

                entity.Property(e => e.Phone)
                    .HasMaxLength(15)
                    .HasColumnName("phone");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(15)
                    .HasColumnName("zipcode");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Clientid).HasColumnName("clientid");

                entity.Property(e => e.Designation)
                    .HasMaxLength(100)
                    .HasColumnName("designation");

                entity.Property(e => e.Nbdays).HasColumnName("nbdays");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Totalexcludetaxe)
                    .HasColumnName("totalexcludetaxe")
                    .HasComputedColumnSql("((nbdays)::double precision * unitprice)", true);

                entity.Property(e => e.Totalwithtaxe)
                    .HasColumnName("totalwithtaxe")
                    .HasComputedColumnSql("(((nbdays)::double precision * unitprice) * (1.2)::double precision)", true);

                entity.Property(e => e.Typepresta)
                    .HasMaxLength(100)
                    .HasColumnName("typepresta");

                entity.Property(e => e.Unitprice).HasColumnName("unitprice");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Clientid)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_clientid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
