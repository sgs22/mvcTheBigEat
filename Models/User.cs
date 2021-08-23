using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcTheBigEat.Models
{
    public class User 
    {
        // Simple user model for assigning user to booking.
        // needs validation for user input 
        [Display(Name = "Unique Identifier")]
        public int ID { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        // ForeignKey
        // used to display all bookings a user has made [user > details] (can be found in admin user panel)
        public ICollection<Booking> Bookings { get; set; }

    
    }
}
