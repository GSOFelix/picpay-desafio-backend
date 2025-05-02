using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<Users> Users { get; set; }

        public DbSet<Transactions> Transactions { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>()
                .HasIndex(x => x.Document)
                .IsUnique();

            modelBuilder.Entity<Users>()
                .HasIndex(x => x.Email)
                .IsUnique();
        }
    }
}
