using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Life_CycleRentals.Models;

namespace Life_CycleRentals.ViewModels
{
    public class RandomBikeViewModel
    {
        public Bike Bike { get; set; }
        public List<Customer> Customers { get; set; }
    }
}