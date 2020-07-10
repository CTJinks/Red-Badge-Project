using DiscGolf.Models;
using DiscGolf.Models.CountyModels;
using DiscGolf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DiscGolf.WebMVC.Controllers
{
    public class CountyController : Controller
    {
        // GET: County
        public ActionResult Index()
        {
            var service = new CountyService();
            var model = service.GetCounties();

            return View(model);
        }
        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CountyCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new CountyService();

            service.CreateCounty(model);

            return RedirectToAction("Index");

        }
    }
}