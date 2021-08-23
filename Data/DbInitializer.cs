using mvcTheBigEat.Models;
using System;
using System.Linq;

namespace mvcTheBigEat.Data
{
    /*
    *  Database Initializer class that was going to be used to create the database but not required.
    *  backed up database as .dacpac instead.
    */
    public static class DbInitializer
    {
        public static void Initialize(TheBigEatContext context)
        {
            context.Database.EnsureCreated();

            // Look for users.
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
            new Course{CourseID=1050,Name="Soup Making Class",Description="learn to make soup!", Date=DateTime.Today,Address="16 Centre Road, TN2 4UY", Price=9, TotalSlots=20, AvailableSlots=20},
            new Course{CourseID=1040,Name="Sauce from scratch!",Description="learn to make sauce!", Date=DateTime.Today,Address="2 Beta Drive, MW4 7IO", Price=29, TotalSlots=30, AvailableSlots=30},
            new Course{CourseID=1070,Name="Fresh Pasta",Description="learn to make pasta!", Date=DateTime.Today,Address="London Ave, SE2 4RY", Price=52, TotalSlots=28, AvailableSlots=28 }
            };
            foreach (Course c in courses)
            {
                context.Courses.Add(c);
            }
            context.SaveChanges();

            var bookings = new Booking[]
            {
            new Booking{BookingID=123,CourseID=1050,UserID=001,Slots=2,},
            new Booking{BookingID=124,CourseID=1040,UserID=002,Slots=7,},
            new Booking{BookingID=125,CourseID=1040,UserID=003,Slots=8,},
            };
            foreach (Booking b in bookings)
            {
                context.Bookings.Add(b);
            }
            context.SaveChanges();
        }
    }
}