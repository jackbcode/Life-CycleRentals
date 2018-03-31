using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Life_CycleRentals.Dtos;
using Life_CycleRentals.Models;
using System.Data.Entity;

namespace Life_CycleRentals.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        //POST Create new Rental

        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRental)
        {

            var customer = _context.Customers.Single(
               c => c.Id == newRental.CustomerId);


            var bikes = _context.Bikes.Where(
                m => newRental.BikeIds.Contains(m.Id)).ToList();




            foreach (var bike in bikes)
            {

                if (bike.NumberAvailable == 0)
                    return BadRequest("Bike is not available");

                bike.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Bike = bike,
                    DateRented = DateTime.Now
                };


                _context.Rentals.Add(rental);




            }
            _context.SaveChanges();

            return Ok();
        }


       
    }
}    
