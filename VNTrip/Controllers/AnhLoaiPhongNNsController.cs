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
    public class AnhLoaiPhongNNsController : Controller
    {
        private Model1 db = new Model1();

        // GET: AnhLoaiPhongNNs
        public ActionResult Index()
        {
            var anhLoaiPhongNNs = db.AnhLoaiPhongNNs.Include(a => a.LoaiPhongNN);
            return View(anhLoaiPhongNNs.ToList());
        }

        // GET: AnhLoaiPhongNNs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhLoaiPhongNN anhLoaiPhongNN = db.AnhLoaiPhongNNs.Find(id);
            if (anhLoaiPhongNN == null)
            {
                return HttpNotFound();
            }
            return View(anhLoaiPhongNN);
        }

        // GET: AnhLoaiPhongNNs/Create
        public ActionResult Create()
        {
            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name");
            return View();
        }

        // POST: AnhLoaiPhongNNs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_LoaiPhongNN,TenLoaiPhong,Image1,Image2,Image3,Image4,Image5")] AnhLoaiPhongNN anhLoaiPhongNN)
        {
            if (ModelState.IsValid)
            {
                db.AnhLoaiPhongNNs.Add(anhLoaiPhongNN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name", anhLoaiPhongNN.ID_LoaiPhongNN);
            return View(anhLoaiPhongNN);
        }

        // GET: AnhLoaiPhongNNs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhLoaiPhongNN anhLoaiPhongNN = db.AnhLoaiPhongNNs.Find(id);
            if (anhLoaiPhongNN == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name", anhLoaiPhongNN.ID_LoaiPhongNN);
            return View(anhLoaiPhongNN);
        }

        // POST: AnhLoaiPhongNNs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_LoaiPhongNN,TenLoaiPhong,Image1,Image2,Image3,Image4,Image5")] AnhLoaiPhongNN anhLoaiPhongNN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anhLoaiPhongNN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name", anhLoaiPhongNN.ID_LoaiPhongNN);
            return View(anhLoaiPhongNN);
        }

        // GET: AnhLoaiPhongNNs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhLoaiPhongNN anhLoaiPhongNN = db.AnhLoaiPhongNNs.Find(id);
            if (anhLoaiPhongNN == null)
            {
                return HttpNotFound();
            }
            return View(anhLoaiPhongNN);
        }

        // POST: AnhLoaiPhongNNs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnhLoaiPhongNN anhLoaiPhongNN = db.AnhLoaiPhongNNs.Find(id);
            db.AnhLoaiPhongNNs.Remove(anhLoaiPhongNN);
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
