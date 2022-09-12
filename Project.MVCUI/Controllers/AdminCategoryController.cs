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
    public class AdminCategoryController : Controller
    {
        CategoryRepository _cRep;

        public AdminCategoryController()
        {
            _cRep = new CategoryRepository();
        }

        // GET: Category
        [Authorize(Roles="A")]
        public ActionResult GetCategoryList()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories = _cRep.GetActives()
            };
            return View(cvm);
        }

        public ActionResult AddCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator cv = new CategoryValidator();
            ValidationResult results = cv.Validate(category);
            if (results.IsValid)
            {
                _cRep.Add(category);
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();

            }


        }

        public ActionResult DeleteCategory(int id)
        {

            _cRep.Delete(_cRep.Find(id));
            return RedirectToAction("GetCategoryList");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = _cRep.Find(id)
            };
            return View(cvm);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            _cRep.Update(category);
            return RedirectToAction("GetCategoryList");
        }

    }
}