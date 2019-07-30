using CodeGeist2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Web.Security;

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


        

        public ActionResult Designer()
        {
            //var x = Roles.GetUsersInRole("Designer");
            List<Account> DesignersAccounts = new List<Account>();
            var x = Db.Roles.SingleOrDefault(r => r.Name == "Designer");
            foreach(var user in x.Users)
            {
                var u = Db.Users.SingleOrDefault(y => y.Id == user.UserId);
                var account = Db.Account.SingleOrDefault(m => m.Email == u.Email);
                DesignersAccounts.Add(account);
            }
            
            return View(DesignersAccounts);
        }
        public ActionResult Translater()
        {
            List<Account> TranslaterAccounts = new List<Account>();
            var x = Db.Roles.SingleOrDefault(r => r.Name == "Translator");
            foreach (var user in x.Users)
            {
                var u = Db.Users.SingleOrDefault(y => y.Id == user.UserId);
                var account = Db.Account.SingleOrDefault(m => m.Email == u.Email);
                TranslaterAccounts.Add(account);
            }

            return View(TranslaterAccounts);
        }

    }
}