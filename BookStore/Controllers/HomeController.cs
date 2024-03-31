using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreContext db = new BookStoreContext();
        public ActionResult Index()
        {
            var stationeries = db.Stationeries.OrderByDescending(s => s.Id).Take(3);
            return View(stationeries.ToList());
        }
        public ActionResult Search()
        {

            var stationeries = db.Stationeries.Include(s => s.Category).OrderByDescending(s => s.Id);
            return View(stationeries.ToList());
            /*
            var stationeries = db.Stationeries.OrderByDescending(s => s.Id);
            return View(stationeries.ToList());
            */
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}