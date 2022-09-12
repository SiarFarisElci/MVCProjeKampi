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
    public class WritePanelMessageController : Controller
    {
        MessageRepository _mRep;

        public WritePanelMessageController()
        {
            _mRep = new MessageRepository();
        }

        // GET: WritePanelMessage
        public ActionResult Inbox()
        {
            MessageVM mvm = new MessageVM
            {
                Messages = _mRep.GetActives().Where(x => x.ReceiverMail == "siar@gmail.com").ToList()
            };
            return View(mvm);
        }

        public ActionResult SendBox()
        {
            MessageVM mvm = new MessageVM
            {
                Messages = _mRep.GetActives().Where(x => x.SenderMail == "siar@gmail.com").ToList()
            };
            return View(mvm);
        }
        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }
        public ActionResult GetInboxMessageDetail(int id)
        {
            MessageVM cvm = new MessageVM
            {
                Message = _mRep.Find(id)
            };

            return View(cvm);
        }

        public ActionResult GetSendMessageDetail(int id)
        {
            MessageVM cvm = new MessageVM
            {
                Message = _mRep.Find(id)
            };

            return View(cvm);
        }
        public ActionResult AddMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddMessage(Message message)
        {
            _mRep.Add(message);
            return RedirectToAction("SendBox");
        }
   
    }
}