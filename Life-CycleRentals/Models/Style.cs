using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Life_CycleRentals.Models
{
    public class Style
    {
        public byte Id { get; set; }

       [Required]
       [StringLength(255)]
       public string Name { get; set; }

    }
}