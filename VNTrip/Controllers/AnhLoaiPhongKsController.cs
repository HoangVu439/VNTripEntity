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
    public class AnhLoaiPhongKsController : Controller
    {
        private Model1 db = new Model1();

        // GET: AnhLoaiPhongKs
        public ActionResult Index()
        {
            var anhLoaiPhongKS = db.AnhLoaiPhongKS.Include(a => a.LoaiPhongK);
            return View(anhLoaiPhongKS.ToList());
        }

        // GET: AnhLoaiPhongKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhLoaiPhongK anhLoaiPhongK = db.AnhLoaiPhongKS.Find(id);
            if (anhLoaiPhongK == null)
            {
                return HttpNotFound();
            }
            return View(anhLoaiPhongK);
        }

        // GET: AnhLoaiPhongKs/Create
        public ActionResult Create()
        {
            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name");
            return View();
        }

        // POST: AnhLoaiPhongKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_LoaiPhongKS,TenLoaiPhong,Image1,Image2,Image3,Image4,Image5")] AnhLoaiPhongK anhLoaiPhongK)
        {
            if (ModelState.IsValid)
            {
                db.AnhLoaiPhongKS.Add(anhLoaiPhongK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name", anhLoaiPhongK.ID_LoaiPhongKS);
            return View(anhLoaiPhongK);
        }

        // GET: AnhLoaiPhongKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhLoaiPhongK anhLoaiPhongK = db.AnhLoaiPhongKS.Find(id);
            if (anhLoaiPhongK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name", anhLoaiPhongK.ID_LoaiPhongKS);
            return View(anhLoaiPhongK);
        }

        // POST: AnhLoaiPhongKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_LoaiPhongKS,TenLoaiPhong,Image1,Image2,Image3,Image4,Image5")] AnhLoaiPhongK anhLoaiPhongK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anhLoaiPhongK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name", anhLoaiPhongK.ID_LoaiPhongKS);
            return View(anhLoaiPhongK);
        }

        // GET: AnhLoaiPhongKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhLoaiPhongK anhLoaiPhongK = db.AnhLoaiPhongKS.Find(id);
            if (anhLoaiPhongK == null)
            {
                return HttpNotFound();
            }
            return View(anhLoaiPhongK);
        }

        // POST: AnhLoaiPhongKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnhLoaiPhongK anhLoaiPhongK = db.AnhLoaiPhongKS.Find(id);
            db.AnhLoaiPhongKS.Remove(anhLoaiPhongK);
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
