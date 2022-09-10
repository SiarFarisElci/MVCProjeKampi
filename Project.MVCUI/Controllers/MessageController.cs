using FluentValidation.Results;
using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.BLL.ValidationRules;
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
        MessageValidation mv = new MessageValidation(); 

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
            ValidationResult result = mv.Validate(message);
            if (result.IsValid)
            {
                _mRep.Add(message);
                return RedirectToAction("SendBox");


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
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
    }
}