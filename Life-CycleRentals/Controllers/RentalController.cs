using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Life_CycleRentals.Controllers
{
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult RentalList()
        {
            return View();
        }
    }
}