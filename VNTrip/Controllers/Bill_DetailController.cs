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
    public class Bill_DetailController : Controller
    {
        private Model1 db = new Model1();

        // GET: Bill_Detail
        public ActionResult Index()
        {
            var bill_Detail = db.Bill_Detail.Include(b => b.Bill).Include(b => b.LoaiPhongK).Include(b => b.LoaiPhongNN).Include(b => b.VeMayBay);
            return View(bill_Detail.ToList());
        }

        // GET: Bill_Detail/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Detail bill_Detail = db.Bill_Detail.Find(id);
            if (bill_Detail == null)
            {
                return HttpNotFound();
            }
            return View(bill_Detail);
        }

        // GET: Bill_Detail/Create
        public ActionResult Create()
        {
            ViewBag.ID_Bill = new SelectList(db.Bills, "ID", "Email");
            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name");
            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name");
            ViewBag.ID_VeMayBay = new SelectList(db.VeMayBays, "ID", "Name");
            return View();
        }

        // POST: Bill_Detail/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ID_Bill,ID_LoaiPhongKS,ID_VeMayBay,ID_LoaiPhongNN,Quantity,created_at,updated_at")] Bill_Detail bill_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Bill_Detail.Add(bill_Detail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_Bill = new SelectList(db.Bills, "ID", "Email", bill_Detail.ID_Bill);
            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name", bill_Detail.ID_LoaiPhongKS);
            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name", bill_Detail.ID_LoaiPhongNN);
            ViewBag.ID_VeMayBay = new SelectList(db.VeMayBays, "ID", "Name", bill_Detail.ID_VeMayBay);
            return View(bill_Detail);
        }

        // GET: Bill_Detail/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Detail bill_Detail = db.Bill_Detail.Find(id);
            if (bill_Detail == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_Bill = new SelectList(db.Bills, "ID", "Email", bill_Detail.ID_Bill);
            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name", bill_Detail.ID_LoaiPhongKS);
            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name", bill_Detail.ID_LoaiPhongNN);
            ViewBag.ID_VeMayBay = new SelectList(db.VeMayBays, "ID", "Name", bill_Detail.ID_VeMayBay);
            return View(bill_Detail);
        }

        // POST: Bill_Detail/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ID_Bill,ID_LoaiPhongKS,ID_VeMayBay,ID_LoaiPhongNN,Quantity,created_at,updated_at")] Bill_Detail bill_Detail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bill_Detail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_Bill = new SelectList(db.Bills, "ID", "Email", bill_Detail.ID_Bill);
            ViewBag.ID_LoaiPhongKS = new SelectList(db.LoaiPhongKS, "ID", "Name", bill_Detail.ID_LoaiPhongKS);
            ViewBag.ID_LoaiPhongNN = new SelectList(db.LoaiPhongNNs, "ID", "Name", bill_Detail.ID_LoaiPhongNN);
            ViewBag.ID_VeMayBay = new SelectList(db.VeMayBays, "ID", "Name", bill_Detail.ID_VeMayBay);
            return View(bill_Detail);
        }

        // GET: Bill_Detail/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bill_Detail bill_Detail = db.Bill_Detail.Find(id);
            if (bill_Detail == null)
            {
                return HttpNotFound();
            }
            return View(bill_Detail);
        }

        // POST: Bill_Detail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bill_Detail bill_Detail = db.Bill_Detail.Find(id);
            db.Bill_Detail.Remove(bill_Detail);
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
