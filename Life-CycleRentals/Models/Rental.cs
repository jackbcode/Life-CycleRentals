using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Life_CycleRentals.Models
{
    public class Rental
    {
        public int Id {get; set;}

        [Required]
        public Customer Customer { get; set;}

        [Required]
        public Bike Bike { get; set; }

        public DateTime DateRented { get; set; }

        public DateTime? DateReturned { get; set; }

    }
}