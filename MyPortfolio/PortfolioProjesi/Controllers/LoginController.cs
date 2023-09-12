using PortfolioProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PortfolioProjesi.Controllers
{
    public class LoginController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin a)
        {
            var values = db.Admins.FirstOrDefault(x => x.UserName == a.UserName && x.Password == a.Password);
            if (values != null) 
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["username"] = values.UserName.ToString();
                return RedirectToAction("Index", "Service");
            }
            return View();
        }
    }
}