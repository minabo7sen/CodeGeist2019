using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CodeGeist2019.Models;
using Microsoft.AspNet.Identity;

namespace CodeGeist2019.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Books
        public ActionResult BooksList()
        {
             /*var GenreLst = new List<string>();
            var GenreQry = from d in db.Book orderby d.Title select d.Title;
            GenreLst.AddRange(GenreQry.Distinct());
            ViewBag.BookTag = new SelectList(GenreLst);
            var Booky = from m in db.Book select m;


            if (!String.IsNullOrEmpty("BookTag"))
            {
                Booky = Booky.Where(x => x.Category == "BookTag");
            }
            */
            return View("BooksList", db.Book.ToList());
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Include(b => b.File)
                                .Include(b => b.Author).SingleOrDefault(b=> b.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var email = User.Identity.GetUserName();
            var Acc = db.Account.SingleOrDefault(a => a.Email == email);

            if(book.Price == 0)
            {
                return View(book);
            }
            if (!Acc.BoughtBooks.Any(b => b.ID == id))
            {
                return View("PurchaseBook", book);
            }
            return View(book);
            
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Book book, BookFile bookFile, HttpPostedFileBase file)
        {

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName).ToLower();
                var FileName = file.FileName;
                file.SaveAs(HttpContext.Server.MapPath("~/Books/") + FileName);

                bookFile.FilePath = FileName;
                book.File = bookFile;

                db.BookFiles.Add(bookFile);
                db.SaveChanges();
                book.File = db.BookFiles.SingleOrDefault(f => f.FilePath == FileName);
            }
            var email = User.Identity.GetUserName();
            var Acc = db.Account.SingleOrDefault(a => a.Email == email);
            book.Author = Acc;

            db.Book.Add(book);
            db.SaveChanges();
            return RedirectToAction("BooksList","Books");


            //return View("Create",book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BooksList");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Book.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Book.Find(id);
            db.Book.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult ConfirmPurchase(int id)
        {
            var purchasedBook = db.Book.SingleOrDefault(b => b.ID == id);
            var email = User.Identity.GetUserName();
            var Acc = db.Account.SingleOrDefault(a => a.Email == email);

            Acc.BoughtBooks.Add(purchasedBook);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
       
        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
