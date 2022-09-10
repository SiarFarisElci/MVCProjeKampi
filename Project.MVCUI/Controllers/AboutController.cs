using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.MVCUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository _aREP;

        public AboutController()
        {
            _aREP = new AboutRepository();
        }
        // GET: About
        public ActionResult Index()
        {
            AboutVM avm = new AboutVM
            {
                Abouts = _aREP.GetActives()
            };
            return View(avm);
        }

        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            _aREP.Add(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {

            return PartialView();
        }

    }
}