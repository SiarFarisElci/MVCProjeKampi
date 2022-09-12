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
    public class WritePanelController : Controller
    {
        WriteRepository _wRep;
        CategoryRepository _cRep;
        HeadingRepository _hRep;
        public WritePanelController()
        {
            _wRep = new WriteRepository();
            _cRep = new CategoryRepository();
            _hRep = new HeadingRepository();
        }
        // GET: WritePanel
        public ActionResult WriteProfile()
        {
            return View();
        }

        public ActionResult MyHeading()
        {
            
            HeadingVM hvm = new HeadingVM
            {
                Headings = _hRep.GetActives().Where(x=>x.WriteID==4).ToList(),
                Categories = _cRep.GetActives(),
                //Writes = _wRep.GetActives()
            };

            return View(hvm);
        }
        public ActionResult EkleHeading()
        {
            HeadingVM hvm = new HeadingVM
            {
                Categories = _cRep.GetActives(),
                Writes = _wRep.GetActives()
            };
            return View(hvm);
        }


        [HttpPost]
        public ActionResult EkleHeading(Heading heading)
        {
            _hRep.Add(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            _hRep.Delete(_hRep.Find(id));
            return RedirectToAction("MyHeading");
        }
    }
}