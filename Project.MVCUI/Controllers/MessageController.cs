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
    public class MessageController : Controller
    {
        MessageRepository _mRep;

        public MessageController()
        {
            _mRep = new MessageRepository();
        }
        // GET: Message
        public ActionResult Inbox()
        {
            MessageVM mvm = new MessageVM
            {
                Messages = _mRep.GetActives().Where(x=> x.ReceiverMail == "admin@gmail.com").ToList()
            };
            return View(mvm);
        }

        public ActionResult SendBox()
        {
            MessageVM mvm = new MessageVM
            {
                Messages = _mRep.GetActives().Where(x => x.SenderMail == "admin@gmail.com").ToList()
            };
            return View(mvm);
        }

        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            _mRep.Add(message);

            return RedirectToAction("Inbox");
        }
    }
}