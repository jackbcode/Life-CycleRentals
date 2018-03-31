using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Life_CycleRentals.Models;
using System.Data.Entity;
using AutoMapper;
using Life_CycleRentals.Dtos;

namespace Life_CycleRentals.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

      
        //GET Rental/RentalList

        public IEnumerable<Rental> GetRentals(string query = null)
        {
            var rentalsQuery = _context.Rentals
            .Include(c => c.Bike)
            .Include(c => c.Customer);
           
           

            return rentalsQuery
                .ToList();

            
        }

    }
}
