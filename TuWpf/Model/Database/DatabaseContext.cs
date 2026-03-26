using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TuWpf.Others;

namespace TuWpf.Model.Database
{
    internal class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var solutionFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            var databaseFile = "Welcome.db";
            var databasePath = Path.Combine(solutionFolder, databaseFile);

            optionsBuilder.UseSqlite($"Data Source={databasePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().Property(x => x.Id).ValueGeneratedOnAdd();

            var user = new User
            {
                Id = 1,
                Names = "Admin",
                Password = "1234",
                Role = UserRolesEnum.ADMIN,
                Expires = DateTime.Now.AddDays(30),
            };

            modelBuilder.Entity<User>().HasData(user);
        }
    }
}
