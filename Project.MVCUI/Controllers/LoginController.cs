using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Models;
using Project.MVCUI.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Project.MVCUI.Controllers
{
    public class LoginController : Controller
    {
        AdminRepository _aRep;

        public LoginController()
        {
            _aRep = new AdminRepository();
        }
        // GET: Login

        public ActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {

            var adminUserInfo = _aRep.GetActives().FirstOrDefault(x => x.AdminUserName == admin.AdminUserName && x.AdminPassword == admin.AdminPassword);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName , false);
                Session["AdminUserName"]=adminUserInfo.AdminUserName;
                return RedirectToAction("GetCategoryList", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
            
        }
    }
}