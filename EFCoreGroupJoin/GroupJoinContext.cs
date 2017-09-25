using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace EFCoreGroupJoin
{
    public class GroupJoinContext : DbContext
    {
        public GroupJoinContext(DbContextOptions<GroupJoinContext> options) : base(options)
        {
            
        }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Child> Children { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parent>()
                .ToTable("Parent");

            modelBuilder.Entity<Parent>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Parent>()
                .Property(x => x.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Child>()
                .ToTable("Child");

            modelBuilder.Entity<Child>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Child>()
                .Property(x => x.Name)
                .HasMaxLength(50);

            modelBuilder.Entity<Child>()
                .HasOne(c => c.Parent)
                .WithMany(p => p.Children)
                .HasForeignKey(c => c.ParentId)
                .IsRequired();
        }
    }
}
