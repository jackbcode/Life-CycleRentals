using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Life_CycleRentals.Dtos;
using Life_CycleRentals.Models;

namespace Life_CycleRentals.Controllers
{
    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }



        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

       

       
    }
}