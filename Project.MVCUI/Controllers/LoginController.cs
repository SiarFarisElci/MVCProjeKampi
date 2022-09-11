using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class LoginController : Controller
    {
        AdminRepository _aRep;

        public LoginController()
        {

        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
    }
}