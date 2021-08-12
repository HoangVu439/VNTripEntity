using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VNTrip.Models;

namespace VNTrip.Controllers
{
    public class loginAdminController : Controller
    {
        // GET: loginAdmin
        Model1 db = new Model1();
        public ActionResult Index()
        {
            if (Session["admin"] != null)
            {
                return RedirectToAction("Index", "test");
            }
            else
                return View();
        }
        [HttpPost]
        public ActionResult Index(Admin tk)
        {

            string email = Request["Email"];
            string password = Request["Password"];
            tk = db.Admins.Where(m => m.Email == email && m.Password == password).SingleOrDefault();
            if (tk != null)
            {
                Session["admin"] = tk;
                return RedirectToAction("Index", "test");
            }
            else
                /*return RedirectToAction("Xuly", "loginAdmin");*/
                ViewBag.error = "Email hoặc Password sai!";
            var dn = from a in db.Admins
                     where a.Email.Equals(email) && a.Password.Equals(password)
                     select a;
            ViewBag.dn = dn;
            return this.Index();
        }
        public ActionResult login()
        {
            Session["admin"] = null;
            return View();

        }
    }
}