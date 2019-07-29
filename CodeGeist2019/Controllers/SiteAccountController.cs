using CodeGeist2019.Models;
using CodeGeist2019.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeGeist2019.Controllers
{
    public class SiteAccountController : Controller
    {
        private ApplicationDbContext _context;
        public SiteAccountController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: SiteAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            UserViewModel uv = new UserViewModel();
            return View("New", uv);
        }

        [HttpPost]
        public ActionResult Save(UserViewModel uvm)
        {
            var id = User.Identity.GetUserId();
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));

            if (uvm.Designer == true)
            {
                UserManager.AddToRole(id, "Designer");
            }

            if (uvm.Translator == true)
            {
                UserManager.AddToRole(id, "Translator");
            }


            Account account = new Account
            {
                Name = uvm.NewUser.Name,
                Age = uvm.NewUser.Age,
                Gender = uvm.NewUser.Gender,
                BioGraphy = uvm.NewUser.BioGraphy,
                //etc...

            };


            _context.Account.Add(account);
            _context.SaveChanges();
            return View("../Home/Index");
        }
    }
}