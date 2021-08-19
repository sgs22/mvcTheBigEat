using mvcTheBigEat.Models;
using System;
using System.Linq;

namespace mvcTheBigEat.Data
{
    public static class DbInitializer
    {
        public static void Initialize(TheBigEatContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var users = new User[]
            {
            new User{FirstName="John",LastName="Alexander",Email="JohnA@gmail.com"},
            new User{FirstName="Sharon",LastName="Smith",Email="SharonS@gmail.com"},
            new User{FirstName="David",LastName="Baller",Email="Baller@gmail.com"},

            };
            foreach (User u in users)
            {
                context.Users.Add(u);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
            new Course{CourseID=1050,Name="Chemistry",Description="", Address ="London Ave", Price=9, TotalSlots=20, AvailableSlots=20},
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();
        }
    }
}