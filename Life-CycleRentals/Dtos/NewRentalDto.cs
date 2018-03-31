using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Life_CycleRentals.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> BikeIds {get; set;}

        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }
    }
}