using devtips_backend.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace devtips_backend.Infrastructure.Contexts
{
    public class AppDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("InMemoryDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var guestRoleId = Guid.NewGuid();
            var adminRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData
                (
                new Role { Id = guestRoleId, Type = Enums.RoleType.Guest },
                new Role { Id = adminRoleId, Type = Enums.RoleType.Admin }
                );

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Posts)
            //    .WithOne(u => u.User)
            //    .HasForeignKey(u => u.UserId);

            //modelBuilder.Entity<Post>()
            //    .HasOne(p => p.User)
            //    .WithMany(p => p.Posts)
            //    .HasForeignKey(p => p.UserId);

            //base.OnModelCreating(modelBuilder);
        }
    }
}
