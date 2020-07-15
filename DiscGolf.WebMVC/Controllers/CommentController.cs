using DiscGolf.Data;
using DiscGolf.Models.CommentModels;
using DiscGolf.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace DiscGolf.WebMVC.Controllers
{
    public class CommentController : Controller
    {
        
        // GET: Comment
        public ActionResult Index(string sortOrder, string searchString)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "commentId_desc" : "";
            ViewBag.CourseNameSortParm = sortOrder == "courseName" ? "courseName_desc" : "courseName";

            var userId = User.Identity.GetUserId();
            var service = new CommentService(userId);
            //CommentService service = CreateCommentService();
            var model = service.SortComments(sortOrder, searchString);

            return View(model);
        }
        // GET: Comments coorelated with course
        /*public ActionResult GetCourseComments(Course course)
        {
            var service = new CommentService();
            var model = service.GetCommentByCourse(course);
            return View(model);
        }*/
        // Post: Chatroom/PostComment
        //GET
        public ActionResult Create()
        {
            var service = new CourseService();
            var comments = service.GetCourses();
            ViewBag.Courses = new SelectList(comments, "CourseId", "CourseName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(CommentCreate model)
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
            var userId = User.Identity.GetUserId();
            var service = new CommentService(userId);
            service.CreateComment(model);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            var svc = CreateCommentService();
            var model = svc.GetCommentById(id);
            return View(model);
        }
        private CommentService CreateCommentService()
        {
            var userId = User.Identity.GetUserId();
            var service = new CommentService(userId);
            return service;
        }
    }
}