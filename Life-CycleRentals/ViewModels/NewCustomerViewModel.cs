using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Life_CycleRentals.Models;

namespace Life_CycleRentals.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }

    }
}