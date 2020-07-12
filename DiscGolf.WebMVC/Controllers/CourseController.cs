using DiscGolf.Data;
using DiscGolf.Models;
using DiscGolf.Models.CourseModels;
using DiscGolf.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DiscGolf.WebMVC.Controllers
{
    public class CourseController : Controller
    {
     //   private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: Hole
        public ActionResult Index()
        {
            var service = new CourseService();
            var model = service.GetCourses();

            return View(model);
        }
        //GET
        //public ActionResult Create()
        //{
        //    SampleDBContext db = new SampleDBContext();
        //    ViewBag.Counties = new SelectList(db.Counties, "CountyId", "CountyName");
        //    return View();
        //}
        public ActionResult Create()
        {
            var service = new CountyService();
            var courses = service.GetCounties();
            ViewBag.Counties = new SelectList(courses, "CountyId", "CountyName");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CourseCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CourseService();

            service.CreateCourse(model);

            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            //add services, make comment models
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);
            //var comments = _db.Comments.ToList();
            return View(model);
        }
        
        private CourseService CreateCourseService()
        {
            var service = new CourseService();
            return service;
        }
    }
}