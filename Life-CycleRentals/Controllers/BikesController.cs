using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web.Mvc;
using Life_CycleRentals.Migrations;
using Life_CycleRentals.Models;
using Life_CycleRentals.ViewModels;
using System.Data.Entity.Validation;

namespace Life_CycleRentals.Controllers
{
    public class BikesController : Controller
    {

        private ApplicationDbContext _context;

       public BikesController()
       {
          _context = new ApplicationDbContext();
       }

       protected override void Dispose(bool disposing)
       {            _context.Dispose();


       }

        // Get List/ReadOnly List depending on sign in 
        
        public ViewResult Index()
        {
            //var bikes = _context.Bikes.Include(m => m.Style).ToList();
            if (User.IsInRole(RoleName.CanManageBikes))
                return View(/*bikes*/ "List");

            else
                return View("ReadOnlyList");
        }


        public ActionResult Details(int id)
        {
            var bikes = _context.Bikes.Include(m => m.Style).SingleOrDefault(m => m.Id == id);
            if (bikes == null)
            {
                return HttpNotFound();
            }

            return View(bikes);
        }

        //Get New Bike View

        [Authorize(Roles = RoleName.CanManageBikes)]
        public ViewResult New()
        {
            var styles = _context.Styles.ToList();

            var viewModel = new BikeFormViewModel
            {
                Styles = styles
            };

            return View("BikeForm", viewModel);
        }


        [Authorize(Roles = RoleName.CanManageBikes)]
        public ActionResult Edit(int id)
        {

            var Bike = _context.Bikes.SingleOrDefault(c => c.Id == id);

            if (Bike == null)
                return HttpNotFound();

            var viewModel = new BikeFormViewModel(Bike)
            {
               
                Styles = _context.Styles.ToList()

            };

            return View("BikeForm",viewModel);
   
        }

        //POST EDIT/SAVE

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBikes)]
        public ActionResult Save(Bike bike)
        {

            if (bike.Picture == null)
            {
               bike.Picture = "https://upload.wikimedia.org/wikipedia/commons/a/a7/Ordinary_bicycle01.jpg";
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new BikeFormViewModel(bike)

                {

                    Styles = _context.Styles.ToList()

                };

                return View("BikeForm", viewModel);

            }

            if (bike.Id == 0)
            {
                bike.DateAdded = DateTime.Now;
                bike.NumberAvailable = bike.NumberInStock;
                _context.Bikes.Add(bike);
                _context.SaveChanges();
              
            }

            else
            {
                var bikeinDb = _context.Bikes.Single(m => m.Id == bike.Id);

                bikeinDb.Picture = bike.Picture;
                bikeinDb.Name = bike.Name;
                bikeinDb.StyleId = bike.StyleId;
                bikeinDb.YearBuilt = bike.YearBuilt;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Bikes");
        }


    }
}