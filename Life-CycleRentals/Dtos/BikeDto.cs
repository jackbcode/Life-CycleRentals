using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Life_CycleRentals.Dtos
{
    public class BikeDto
    {
        public int Id { get; set; }

       

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        

        [Url]
        public string Picture { get; set; }



        [Required]
        public byte StyleId { get; set; }

        public StyleDto Style { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime YearBuilt { get; set; }

        [Range(1, 10)]
        public byte NumberInStock { get; set; }

    }
}