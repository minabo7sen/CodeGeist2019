using CodeGeist2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;


namespace CodeGeist2019.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext Db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var books = Db.Book.Include(b => b.Author).ToList();
           
            return View(books);
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