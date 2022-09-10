using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.MVCUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class ContentController : Controller
    {

        ContentRepository _cRep;
        WriteRepository _wRep;
        HeadingRepository _hRep;

        public ContentController()
        {
            _cRep = new ContentRepository();
            _wRep = new WriteRepository();
            _hRep = new HeadingRepository();
        }

        // GET: Content
        public ActionResult ContentHeading(int id)
        {
            ContentVM cvm = new ContentVM
            {
                Contents = _cRep.GetActives().Where(x=> x.HeadingID==id).ToList(),
                Headings = _hRep.GetActives(),
                Writes = _wRep.GetActives()
            };

            return View(cvm);
        }

        public ActionResult DeleteContent(int id)
        {
            _cRep.Delete(_cRep.Find(id));
            return RedirectToAction("ContentHeading");

        }
    }
}