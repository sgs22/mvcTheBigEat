using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcTheBigEat.Models
{
    public class User 
    {
        
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

        public ICollection<Booking> Bookings { get; set; }

    
    }
}
