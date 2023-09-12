using PortfolioProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjesi_Portfolio.Controllers
{
    public class DefaultController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialNavBar()
        {
            return PartialView();
        }
        public PartialViewResult PartialQuickContact()
        {
            var values = db.QuickContacts.ToList();
            return PartialView(values);
        }  
        public PartialViewResult PartialFeature()
        {
            var values = db.Feature1.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialService()
        {
            var values = db.Services.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialSkill()
        {
            var values = db.Skills.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialAward() 
        {
            var values = db.Awards.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialTestimonial()
        {
            var values = db.Testimonials.ToList();
            return PartialView(values);
        }
        public PartialViewResult PartialClients()
        {
            var values = db.Clients.ToList();
            return PartialView(values);
        }

        [HttpGet]
        public PartialViewResult PartialContact()
        {
            ViewBag.description = db.Adresses.Select(x => x.Description).FirstOrDefault();
            ViewBag.phone = db.Adresses.Select(x => x.Phone).FirstOrDefault();
            ViewBag.mail = db.Adresses.Select(x => x.Mail).FirstOrDefault();
            ViewBag.adresDetail = db.Adresses.Select(x => x.AdressDetail).FirstOrDefault();
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult PartialContact(Contact contact)
        {
            db.Contacts.Add(contact);
            db.SaveChanges();
            return PartialView("PartialContact");
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

    }
}