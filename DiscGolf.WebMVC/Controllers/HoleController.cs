using DiscGolf.Models.HoleModels;
using DiscGolf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscGolf.WebMVC.Controllers
{
    public class HoleController : Controller
    {
        // GET: Hole
        public ActionResult Index()
        {
            var service = new HoleService();
            var model = service.GetHoles();

            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HoleCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new HoleService();

            service.CreateHole(model);

            return RedirectToAction("Index");

        }
    }
}