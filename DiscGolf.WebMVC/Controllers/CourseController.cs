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
        // GET: Hole
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "courseId_desc" : "";
            ViewBag.CountyNameSortParm = sortOrder == "countyName" ? "countyName_desc" : "countyName";

            CourseService service = CreateCourseService();
            var model = service.SortCourses(sortOrder, searchString);

            return View(model);
        }
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
            bool UserIsLoggedIn = User.Identity.IsAuthenticated;
            if (!UserIsLoggedIn)
            {
                return RedirectToAction("Login", "Account");
            }
            var service = new CourseService();

            service.CreateCourse(model);

            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            var svc = CreateCourseService();
            var model = svc.GetCourseDetailById(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateCourseService();
            var detail = service.GetCourseById(id);
            var model =
                new CourseEdit
                {
                    CourseId = detail.CourseId,
                    CourseName = detail.CourseName,
                    CourseLocation = detail.CourseLocation,
                    Holes = detail.Holes,
                    CourseDescription = detail.CourseDescription
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CourseEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CourseId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateCourseService();

            if (service.UpdateCourse(model))
            {
                TempData["SaveResult"] = "Course was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Course could not be updated.");
            return View(model);
        }
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateCourseService();
            var model = svc.GetCourseById(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateCourseService();

            service.DeleteCourse(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }
        private CourseService CreateCourseService()
        {
            var service = new CourseService();
            return service;
        }
    }
}