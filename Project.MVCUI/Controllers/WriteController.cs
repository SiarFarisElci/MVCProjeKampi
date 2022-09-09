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
    public class WriteController : Controller
    {
        WriteRepository _wRep;
        WriteValidator wv = new WriteValidator();

        public WriteController()
        {
            _wRep = new WriteRepository();
        }

        // GET: Write
        public ActionResult WriteList()
        {
            WriteVM wvm = new WriteVM
            {
                Writes = _wRep.GetActives()
            };

            return View(wvm);
        }

        public ActionResult AddWrite()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWrite(Write write)
        {
            ValidationResult result = wv.Validate(write);
            if (result.IsValid)
            {
                _wRep.Add(write);
                return RedirectToAction("WriteList");


            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName , item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteWrite(int id)
        {
            _wRep.Delete(_wRep.Find(id));
            return RedirectToAction("WriteList");

        }

        public ActionResult EditWriter(int id)
        {
            WriteVM wvm = new WriteVM
            {
                Write = _wRep.Find(id)
            };
            return View(wvm);
        }
        [HttpPost]
        public ActionResult EditWriter(Write write)
        {
            ValidationResult result = wv.Validate(write);
            if (result.IsValid)
            {
                _wRep.Update(write);
                return RedirectToAction("WriteList");


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

    }
}