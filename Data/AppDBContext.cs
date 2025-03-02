using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using notes_api.Models;
using System.Collections.Generic;

namespace notes_api.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
        public AppDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Note> Note { get; set; }

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Define static roles with hardcoded GUIDs
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = "1", // Static GUID or string ID
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "d2b5b5a5-5b5a-5b5a-5b5a-5b5a5b5a5b5a" // Static GUID
                },
                new IdentityRole
                {
                    Id = "2", // Static GUID or string ID
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "d3b5b5a5-5b5a-5b5a-5b5a-5b5a5b5a5b5a" // Static GUID
                },
            };

            // Seed the roles into the database
            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}