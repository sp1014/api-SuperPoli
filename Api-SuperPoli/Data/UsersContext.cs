using Api_SuperPoli.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Api_SuperPoli.Data
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions<UsersContext> options)
            : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<TypeDoc> TypeDocs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<ProductFile> ProductFiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductFile>()
                .HasKey(pf => new { pf.ProductId, pf.FileId });

            modelBuilder.Entity<ProductFile>()
                .HasOne(pf => pf.Product)
                .WithMany(p => p.ProductFile)
                .HasForeignKey(pf => pf.ProductId);

            modelBuilder.Entity<ProductFile>()
                .HasOne(pf => pf.File)
                .WithMany(f => f.ProductFiles)
                .HasForeignKey(pf => pf.FileId);
        }

    }

}
