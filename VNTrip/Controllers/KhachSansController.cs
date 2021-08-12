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
    public class KhachSansController : Controller
    {
        private Model1 db = new Model1();

        // GET: KhachSans
        public ActionResult Index()
        {
            var khachSans = db.KhachSans.Include(k => k.Khuvuc);
            return View(khachSans.ToList());
        }

        // GET: KhachSans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachSan khachSan = db.KhachSans.Find(id);
            if (khachSan == null)
            {
                return HttpNotFound();
            }
            return View(khachSan);
        }

        // GET: KhachSans/Create
        public ActionResult Create()
        {
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name");
            return View();
        }

        // POST: KhachSans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ID_Khuvuc,Group_Pro,Address,Phone_Number,Description,Utilities,Thongtin,Checkin,Checkout,Image,created_at,updated_at")] KhachSan khachSan)
        {
            if (ModelState.IsValid)
            {
                db.KhachSans.Add(khachSan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", khachSan.ID_Khuvuc);
            return View(khachSan);
        }

        // GET: KhachSans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachSan khachSan = db.KhachSans.Find(id);
            if (khachSan == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", khachSan.ID_Khuvuc);
            return View(khachSan);
        }

        // POST: KhachSans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ID_Khuvuc,Group_Pro,Address,Phone_Number,Description,Utilities,Thongtin,Checkin,Checkout,Image,created_at,updated_at")] KhachSan khachSan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachSan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", khachSan.ID_Khuvuc);
            return View(khachSan);
        }

        // GET: KhachSans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachSan khachSan = db.KhachSans.Find(id);
            if (khachSan == null)
            {
                return HttpNotFound();
            }
            return View(khachSan);
        }

        // POST: KhachSans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachSan khachSan = db.KhachSans.Find(id);
            db.KhachSans.Remove(khachSan);
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
