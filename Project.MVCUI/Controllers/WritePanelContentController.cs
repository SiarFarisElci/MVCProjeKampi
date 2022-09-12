using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.MVCUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class WritePanelContentController : Controller
    {
        ContentRepository _cRep;
        WriteRepository _wRep;
        HeadingRepository _hRep;

        public WritePanelContentController()
        {
            _cRep = new ContentRepository();
            _wRep = new WriteRepository();
            _hRep = new HeadingRepository();
        }
        // GET: WritePanelContent
        public ActionResult MyContent()
        {

            ContentVM cvm = new ContentVM
            {
                Contents = _cRep.GetActives().Where(x=> x.WriteID == 4).ToList(),
                Headings = _hRep.GetActives(),
                Writes = _wRep.GetActives()
            };

            return View(cvm);
            
        }
    }
}