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
    public class KhuvucsController : Controller
    {
        private Model1 db = new Model1();

        // GET: Khuvucs
        public ActionResult Index()
        {
            return View(db.Khuvucs.ToList());
        }

        // GET: Khuvucs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khuvuc khuvuc = db.Khuvucs.Find(id);
            if (khuvuc == null)
            {
                return HttpNotFound();
            }
            return View(khuvuc);
        }

        // GET: Khuvucs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Khuvucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Description,Image")] Khuvuc khuvuc)
        {
            if (ModelState.IsValid)
            {
                db.Khuvucs.Add(khuvuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khuvuc);
        }

        // GET: Khuvucs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khuvuc khuvuc = db.Khuvucs.Find(id);
            if (khuvuc == null)
            {
                return HttpNotFound();
            }
            return View(khuvuc);
        }

        // POST: Khuvucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Description,Image")] Khuvuc khuvuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khuvuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khuvuc);
        }

        // GET: Khuvucs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Khuvuc khuvuc = db.Khuvucs.Find(id);
            if (khuvuc == null)
            {
                return HttpNotFound();
            }
            return View(khuvuc);
        }

        // POST: Khuvucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Khuvuc khuvuc = db.Khuvucs.Find(id);
            db.Khuvucs.Remove(khuvuc);
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
