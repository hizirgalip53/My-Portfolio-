using PortfolioProjesi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProjesi.Controllers
{
    public class ProjectController : Controller
    {
        MyPortfolioDbEntities db = new MyPortfolioDbEntities();
        // GET: Project
        public ActionResult Index()
        {
            var values = db.Projects.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(Project project)
        {
            db.Projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value=db.Projects.Find(id);
            db.Projects.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            var value=db.Projects.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            var value = db.Projects.Find(project.ProjectID);
            value.ProjectTitle = project.ProjectTitle;
            value.Description = project.Description;
            value.ProjectCategory = project.ProjectCategory;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}