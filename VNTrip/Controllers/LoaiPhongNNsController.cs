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
    public class LoaiPhongNNsController : Controller
    {
        private Model1 db = new Model1();

        // GET: LoaiPhongNNs
        public ActionResult Index()
        {
            var loaiPhongNNs = db.LoaiPhongNNs.Include(l => l.NhaNghi);
            return View(loaiPhongNNs.ToList());
        }

        // GET: LoaiPhongNNs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhongNN loaiPhongNN = db.LoaiPhongNNs.Find(id);
            if (loaiPhongNN == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhongNN);
        }

        // GET: LoaiPhongNNs/Create
        public ActionResult Create()
        {
            ViewBag.ID_NhaNghi = new SelectList(db.NhaNghis, "ID", "Name");
            return View();
        }

        // POST: LoaiPhongNNs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ID_NhaNghi,TenLoaiPhong,Description,Price2h,PriceNight,Image,created_at,updated_at")] LoaiPhongNN loaiPhongNN)
        {
            if (ModelState.IsValid)
            {
                db.LoaiPhongNNs.Add(loaiPhongNN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_NhaNghi = new SelectList(db.NhaNghis, "ID", "Name", loaiPhongNN.ID_NhaNghi);
            return View(loaiPhongNN);
        }

        // GET: LoaiPhongNNs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhongNN loaiPhongNN = db.LoaiPhongNNs.Find(id);
            if (loaiPhongNN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_NhaNghi = new SelectList(db.NhaNghis, "ID", "Name", loaiPhongNN.ID_NhaNghi);
            return View(loaiPhongNN);
        }

        // POST: LoaiPhongNNs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ID_NhaNghi,TenLoaiPhong,Description,Price2h,PriceNight,Image,created_at,updated_at")] LoaiPhongNN loaiPhongNN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiPhongNN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_NhaNghi = new SelectList(db.NhaNghis, "ID", "Name", loaiPhongNN.ID_NhaNghi);
            return View(loaiPhongNN);
        }

        // GET: LoaiPhongNNs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhongNN loaiPhongNN = db.LoaiPhongNNs.Find(id);
            if (loaiPhongNN == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhongNN);
        }

        // POST: LoaiPhongNNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiPhongNN loaiPhongNN = db.LoaiPhongNNs.Find(id);
            db.LoaiPhongNNs.Remove(loaiPhongNN);
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
