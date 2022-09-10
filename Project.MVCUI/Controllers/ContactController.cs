using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.BLL.ValidationRules;
using Project.MVCUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class ContactController : Controller
    {
        ContactRepository _cRep;

        ContactValidator validationRules = new ContactValidator();

        public ContactController()
        {
            _cRep = new ContactRepository();
        }

        // GET: Contact
        public ActionResult Index()
        {
            ContactVM cvm = new ContactVM
            {
                Contacts = _cRep.GetActives()
            };
            return View(cvm);
        }

        public ActionResult GetContactDetail(int id)
        {
            ContactVM cvm = new ContactVM
            {
                Contact = _cRep.Find(id)
            };

            return View(cvm);
        }

        public PartialViewResult MessageList()
        {

            return PartialView();
        }
    }
}