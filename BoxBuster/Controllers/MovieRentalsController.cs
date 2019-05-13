using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BoxBuster.Controllers
{
    public class MovieRentalsController : Controller
    {
        // GET: MovieRentals
        public ActionResult New()
        {
            return View();
        }
    }
}