using PortfolioProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjesi.Controllers
{
    public class RegisterController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            db.Admins.Add(admin);
            db.SaveChanges();
            return RedirectToAction("Index", "Login");
        }
    }
}