using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Life_CycleRentals.Models;
using Life_CycleRentals.Dtos;
using System.Data.Entity;


namespace Life_CycleRentals.Controllers.Api
{
    public class BikesController : ApiController
    {

        private ApplicationDbContext _context;

        public BikesController()
        {
            _context = new ApplicationDbContext();
        }


        //GET Bikes/List

        public IEnumerable<BikeDto> GetBikes(string query = null)
        {
            var bikesQuery = _context.Bikes
               .Include(m => m.Style)
               .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                bikesQuery = bikesQuery.Where(m => m.Name.Contains(query));

            return bikesQuery
               .ToList()
               .Select(Mapper.Map<Bike, BikeDto>); 
        }

        //Get Bikes/List/1
        public IHttpActionResult GetBike(int id)
        {
            var bike = _context.Bikes.SingleOrDefault(c => c.Id == id);

            if (bike == null)
                return NotFound();

            return Ok(Mapper.Map<Bike, BikeDto>(bike));
        }


        //POST Add Bike
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public IHttpActionResult CreateBike(BikeDto bikeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            

            var bike = Mapper.Map<BikeDto, Bike>(bikeDto);

            bike.NumberAvailable = bike.NumberInStock;

            _context.Bikes.Add(bike);

            _context.SaveChanges();

            bikeDto.Id = bike.Id;
            return Created(new Uri(Request.RequestUri + "/" + bike.Id), bikeDto);
        }

        //PUT Edit Bike
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public IHttpActionResult UpdateBike(int id, BikeDto bikeDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bikeInDb = _context.Bikes.SingleOrDefault(c => c.Id == id);


            if (bikeInDb == null)
                return NotFound();

            Mapper.Map(bikeDto, bikeInDb);

            _context.SaveChanges();

            return Ok();

        }

        // Delete Bike
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public IHttpActionResult DeleteBike(int id)
        {
           var bikeInDb = _context.Bikes.SingleOrDefault(c => c.Id == id);

            if (bikeInDb == null)
                return NotFound();

           _context.Bikes.Remove(bikeInDb);
           _context.SaveChanges();

           return Ok();
        }





     }
}
