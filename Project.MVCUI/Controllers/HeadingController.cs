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
    public class HeadingController : Controller
    {
        WriteRepository _wRep;
        CategoryRepository _cRep;
        HeadingRepository _hRep;
        public HeadingController()
        {
            _wRep = new WriteRepository();
            _cRep = new CategoryRepository();
            _hRep = new HeadingRepository();
        }
        // GET: Heading
        public ActionResult ListHeading()
        {
            HeadingVM hvm = new HeadingVM
            {
                Headings = _hRep.GetAll(),
                Categories = _cRep.GetActives(),
                Writes = _wRep.GetActives()
            };
            return View(hvm);
        }


        public ActionResult AddHeading()
        {
            HeadingVM hvm = new HeadingVM
            {
                Categories = _cRep.GetActives(),
                Writes = _wRep.GetActives()
            };
            return View(hvm);
        }


        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            _hRep.Add(heading);
            return RedirectToAction("ListHeading");
        }

        public ActionResult EditHeading(int id)
        {
            HeadingVM hvm = new HeadingVM
            {
                Heading = _hRep.Find(id),
                Categories = _cRep.GetActives(),
                Writes = _wRep.GetActives()
            };

            return View(hvm);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            _hRep.Update(heading);
            return RedirectToAction("ListHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            _hRep.Delete(_hRep.Find(id));
            return RedirectToAction("ListHeading");
        }
       
    }
}