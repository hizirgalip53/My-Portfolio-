using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PortfolioProjesi.Models;

namespace PortfolioProjesi.Controllers
{
    public class TestimonialController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        // GET: Testimonial
        public ActionResult Index()
        {
            var values = db.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddTestimonial()  
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTestimonial(Testimonial testimonial)
        {
            db.Testimonials.Add(testimonial);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteTestimonial(int id)
        {
            var value = db.Testimonials.Find(id);
            db.Testimonials.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = db.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = db.Testimonials.Find(testimonial.TestimonialID);
            value.NameSurname = testimonial.NameSurname;
            value.Sehir = testimonial.Sehir;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}