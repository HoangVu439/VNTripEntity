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
    public class NhaNghisController : Controller
    {
        private Model1 db = new Model1();

        // GET: NhaNghis
        public ActionResult Index()
        {
            var nhaNghis = db.NhaNghis.Include(n => n.Khuvuc);
            return View(nhaNghis.ToList());
        }

        // GET: NhaNghis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaNghi nhaNghi = db.NhaNghis.Find(id);
            if (nhaNghi == null)
            {
                return HttpNotFound();
            }
            return View(nhaNghi);
        }

        // GET: NhaNghis/Create
        public ActionResult Create()
        {
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name");
            return View();
        }

        // POST: NhaNghis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ID_Khuvuc,Group_Pro,Description,Address,Phone_Number,Image,created_at,updated_at")] NhaNghi nhaNghi)
        {
            if (ModelState.IsValid)
            {
                db.NhaNghis.Add(nhaNghi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", nhaNghi.ID_Khuvuc);
            return View(nhaNghi);
        }

        // GET: NhaNghis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaNghi nhaNghi = db.NhaNghis.Find(id);
            if (nhaNghi == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", nhaNghi.ID_Khuvuc);
            return View(nhaNghi);
        }

        // POST: NhaNghis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ID_Khuvuc,Group_Pro,Description,Address,Phone_Number,Image,created_at,updated_at")] NhaNghi nhaNghi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nhaNghi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", nhaNghi.ID_Khuvuc);
            return View(nhaNghi);
        }

        // GET: NhaNghis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NhaNghi nhaNghi = db.NhaNghis.Find(id);
            if (nhaNghi == null)
            {
                return HttpNotFound();
            }
            return View(nhaNghi);
        }

        // POST: NhaNghis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NhaNghi nhaNghi = db.NhaNghis.Find(id);
            db.NhaNghis.Remove(nhaNghi);
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
