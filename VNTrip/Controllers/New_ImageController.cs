using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VNTrip.Models;

namespace VNTrip.Controllers
{
    public class New_ImageController : Controller
    {
        private Model1 db = new Model1();

        // GET: New_Image
        public ActionResult Index()
        {
            var new_Image = db.New_Image.Include(n => n.News);
            return View(new_Image.ToList());
        }

        // GET: New_Image/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Image new_Image = db.New_Image.Find(id);
            if (new_Image == null)
            {
                return HttpNotFound();
            }
            return View(new_Image);
        }

        // GET: New_Image/Create
        public ActionResult Create()
        {
            ViewBag.ID_New = new SelectList(db.News, "ID", "Title");
            return View();
        }

        // POST: New_Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_New,Image")] New_Image new_Image)
        {
            if (ModelState.IsValid)
            {
                db.New_Image.Add(new_Image);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_New = new SelectList(db.News, "ID", "Title", new_Image.ID_New);
            return View(new_Image);
        }

        // GET: New_Image/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Image new_Image = db.New_Image.Find(id);
            if (new_Image == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_New = new SelectList(db.News, "ID", "Title", new_Image.ID_New);
            return View(new_Image);
        }

        // POST: New_Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_New,Image")] New_Image new_Image)
        {
            if (ModelState.IsValid)
            {
                db.Entry(new_Image).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_New = new SelectList(db.News, "ID", "Title", new_Image.ID_New);
            return View(new_Image);
        }

        // GET: New_Image/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            New_Image new_Image = db.New_Image.Find(id);
            if (new_Image == null)
            {
                return HttpNotFound();
            }
            return View(new_Image);
        }

        // POST: New_Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            New_Image new_Image = db.New_Image.Find(id);
            db.New_Image.Remove(new_Image);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
