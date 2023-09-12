using PortfolioProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjesi_Portfolio.Controllers
{
    public class EducationController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        public ActionResult Index()
        {
            var values = db.Educations.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEducation() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(Education education)
        {
            db.Educations.Add(education);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEducation(int id)
        {
            var value = db.Educations.Find(id);
            db.Educations.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateEducation(int id)
        {
            var value = db.Educations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateEducation(Education education)
        {
            var value = db.Educations.Find(education.EducationID);
            value.EducationName = education.EducationName;
            value.EducationDescription = education.EducationDescription;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}