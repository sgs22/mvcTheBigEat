﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mvcTheBigEat.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        [Display(Name = "Select Course:")]
        public int CourseID { get; set; }
        [Display(Name = "Select Email:")]
        public int UserID { get; set; }
        [Required]
        [Display(Name = "Number of Slots (People):")]
        public int Slots { get; set;  }

        public Course Course { get; set; }
        public User User { get; set; }
    }


}
