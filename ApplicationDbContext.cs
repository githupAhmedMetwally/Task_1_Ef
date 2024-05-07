using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Task_1Ef
{
    internal class ApplicationDbContext : DbContext
    {
        public DbSet<TaaskEntity> MyProperty { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=.\DotNet;Initial Catalog=Task-1;
                  Integrated Security=True;TrustServerCertificate=True");
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TaaskEntity>()
                .ToTable("NewTask");

           modelBuilder.Entity<TaaskEntity>()
                       .Property(p => p.Date)  
                    .HasColumnName("Deadline");
        }
    }
    
}
