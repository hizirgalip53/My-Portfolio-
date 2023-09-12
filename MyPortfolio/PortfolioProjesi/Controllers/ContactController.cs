using PortfolioProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjesi.Controllers
{
    public class ContactController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
          
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.description = db.Adresses.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = db.Adresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.mail = db.Adresses.Select(x => x.Mail).FirstOrDefault();
            ViewBag.adresDetail = db.Adresses.Select(x => x.AdressDetail).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
        public PartialViewResult PartialScript()
        {
            return PartialView();
        }
    }
}