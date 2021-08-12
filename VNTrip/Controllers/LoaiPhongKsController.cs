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
    public class LoaiPhongKsController : Controller
    {
        private Model1 db = new Model1();

        // GET: LoaiPhongKs
        public ActionResult Index()
        {
            var loaiPhongKS = db.LoaiPhongKS.Include(l => l.KhachSan);
            return View(loaiPhongKS.ToList());
        }

        // GET: LoaiPhongKs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhongK loaiPhongK = db.LoaiPhongKS.Find(id);
            if (loaiPhongK == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhongK);
        }

        // GET: LoaiPhongKs/Create
        public ActionResult Create()
        {
            ViewBag.ID_KhachSan = new SelectList(db.KhachSans, "ID", "Name");
            return View();
        }

        // POST: LoaiPhongKs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,ID_KhachSan,TenLoaiPhong,SucChua,BuaAn,Description,Utilities,Image,Price,Promotion_Price,created_at,updated_at")] LoaiPhongK loaiPhongK)
        {
            if (ModelState.IsValid)
            {
                db.LoaiPhongKS.Add(loaiPhongK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_KhachSan = new SelectList(db.KhachSans, "ID", "Name", loaiPhongK.ID_KhachSan);
            return View(loaiPhongK);
        }

        // GET: LoaiPhongKs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhongK loaiPhongK = db.LoaiPhongKS.Find(id);
            if (loaiPhongK == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KhachSan = new SelectList(db.KhachSans, "ID", "Name", loaiPhongK.ID_KhachSan);
            return View(loaiPhongK);
        }

        // POST: LoaiPhongKs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,ID_KhachSan,TenLoaiPhong,SucChua,BuaAn,Description,Utilities,Image,Price,Promotion_Price,created_at,updated_at")] LoaiPhongK loaiPhongK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loaiPhongK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KhachSan = new SelectList(db.KhachSans, "ID", "Name", loaiPhongK.ID_KhachSan);
            return View(loaiPhongK);
        }

        // GET: LoaiPhongKs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoaiPhongK loaiPhongK = db.LoaiPhongKS.Find(id);
            if (loaiPhongK == null)
            {
                return HttpNotFound();
            }
            return View(loaiPhongK);
        }

        // POST: LoaiPhongKs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoaiPhongK loaiPhongK = db.LoaiPhongKS.Find(id);
            db.LoaiPhongKS.Remove(loaiPhongK);
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
