using PortfolioProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjesi.Controllers
{
    public class StatisticController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        // GET: Statistic
        public ActionResult Index()
        {
            ViewBag.totalProjectCount = db.Projects.Count();
            ViewBag.totalTestimonialCount = db.Testimonials.Count();
            ViewBag.sumWorkDay = db.Projects.Sum(x => x.CompleteDay);
            ViewBag.avgWorkDay = db.Projects.Average(x => x.CompleteDay);
            var avgPrice = db.Projects.Average(x => x.Price).ToString();
            ViewBag.avgPrice = avgPrice.Substring(0,avgPrice.IndexOf('.')+3);
            var value = db.Projects.Max(x => x.Price);
            ViewBag.maxProjectPrice = db.Projects.Where(x => x.Price == value).Select(y => y.ProjectTitle).FirstOrDefault();
            var value2 = db.Categories.Where(x => x.CategoryName == "Web geliştirme").Select(y => y.CategoryID).FirstOrDefault();
            ViewBag.categoryCountByName = db.Projects.Where(x => x.ProjectCategory == value2).Count();
            return View();
        }
    }
}