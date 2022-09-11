using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.MVCUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class GalleryController : Controller
    {
        ImageFilesRepository _ifRep;

        public GalleryController()
        {
            _ifRep = new ImageFilesRepository();
        }
        // GET: Gallery
        public ActionResult Index()
        {
            ImageVM ivm = new ImageVM
            {
                ImageFiles = _ifRep.GetActives()
            };
            return View(ivm);
        }
    }
}