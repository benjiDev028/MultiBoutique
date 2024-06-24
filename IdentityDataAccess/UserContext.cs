using IdentityDataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityDataAccess
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext>options)
        : base(options)
        { }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email);
            
            base.OnModelCreating(modelBuilder);
        }


    }
}
