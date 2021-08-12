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
    public class VeMayBaysController : Controller
    {
        private Model1 db = new Model1();

        // GET: VeMayBays
        public ActionResult Index()
        {
            var veMayBays = db.VeMayBays.Include(v => v.Khuvuc);
            return View(veMayBays.ToList());
        }

        // GET: VeMayBays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeMayBay veMayBay = db.VeMayBays.Find(id);
            if (veMayBay == null)
            {
                return HttpNotFound();
            }
            return View(veMayBay);
        }

        // GET: VeMayBays/Create
        public ActionResult Create()
        {
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name");
            return View();
        }

        // POST: VeMayBays/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ID_Khuvuc,Group_Pro,Tenhang,Diemdi,Diemden,Ngaydi,Ngayve,Price,Image,Description")] VeMayBay veMayBay)
        {
            if (ModelState.IsValid)
            {
                db.VeMayBays.Add(veMayBay);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", veMayBay.ID_Khuvuc);
            return View(veMayBay);
        }

        // GET: VeMayBays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeMayBay veMayBay = db.VeMayBays.Find(id);
            if (veMayBay == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", veMayBay.ID_Khuvuc);
            return View(veMayBay);
        }

        // POST: VeMayBays/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ID_Khuvuc,Group_Pro,Tenhang,Diemdi,Diemden,Ngaydi,Ngayve,Price,Image,Description")] VeMayBay veMayBay)
        {
            if (ModelState.IsValid)
            {
                db.Entry(veMayBay).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Khuvuc = new SelectList(db.Khuvucs, "ID", "Name", veMayBay.ID_Khuvuc);
            return View(veMayBay);
        }

        // GET: VeMayBays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VeMayBay veMayBay = db.VeMayBays.Find(id);
            if (veMayBay == null)
            {
                return HttpNotFound();
            }
            return View(veMayBay);
        }

        // POST: VeMayBays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VeMayBay veMayBay = db.VeMayBays.Find(id);
            db.VeMayBays.Remove(veMayBay);
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
