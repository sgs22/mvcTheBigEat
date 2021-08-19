using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mvcTheBigEat.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }
        [Required]
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Display(Name = "Event Location")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }
        [Required]
        [Display(Name = "Total Slots")]
        public int TotalSlots { get; set; }
        [Display(Name = "Slots Available")]
        public int AvailableSlots { get; set; }

        public ICollection<Booking> Bookings { get; set; }


    }
}
