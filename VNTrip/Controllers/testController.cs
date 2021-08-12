using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNTrip.Models;

namespace VNTrip.Controllers
{
    public class testController : Controller
    {
        // GET: test
        Model1 db = new Model1();
        public ActionResult Index()
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Index", "loginAdmin");
            }
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(Customer tk)
        {
            string email = Request["Email"];
            string password = Request["PassWord"];
            tk = db.Customers.Where(m => m.Email == email && m.Password == password).SingleOrDefault();
            if (tk != null && tk.Status == "Active")
            {
                Session["user"] = tk;
                Session["Name"] = tk.Name;
                Session["ID"] = tk.ID;
                return RedirectToAction("Index", "Home");
            }
            else if (tk != null && tk.Status == "Lock")
            {
                ViewBag.error = "Tài khoản của bạn đã bị khóa!";
            }
            else
                ViewBag.error = "Email hoặc Password sai!";
            return this.Index();
        }
    }
}