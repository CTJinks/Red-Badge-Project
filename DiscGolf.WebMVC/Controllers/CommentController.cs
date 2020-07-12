using DiscGolf.Data;
using DiscGolf.Models.CommentModels;
using DiscGolf.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscGolf.WebMVC.Controllers
{
    public class CommentController : Controller
    {
        // GET: Comment
        public ActionResult Index()
        {
            var service = new CommentService();
            var model = service.GetComments();
            return View(model);
        }
        // GET: Comments coorelated with course
        public ActionResult GetCourseComments(Course course)
        {
            var service = new CommentService();
            var model = service.GetCommentByCourse(course);
            return View(model);
        }
        // Post: Chatroom/PostComment
        [HttpPost]
        public ActionResult PostComment(CommentCreate model)
        {
            int userId = Convert.ToInt32(User.Identity.GetUserId());
            if (userId == 0)
            {
                return RedirectToAction("Login", "Account");
            }
            var service = new CommentService();
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
            var service = new CommentService();
            return service;
        }
    }
}