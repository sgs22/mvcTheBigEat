using Microsoft.EntityFrameworkCore;
using mvcTheBigEat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvcTheBigEat.Data
{
    public class TheBigEatContext: DbContext
    {
        public TheBigEatContext(DbContextOptions<TheBigEatContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().ToTable("Course");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
