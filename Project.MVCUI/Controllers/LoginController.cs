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
        WriteRepository _wRep;

        public LoginController()
        {
            _wRep = new WriteRepository();
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

        public ActionResult WriterLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult WriterLogin(Write write)
        {
            var writeUserInfo = _wRep.FirstOrDefault(x => x.WriteMail == write.WriteMail && x.WritePassword == write.WritePassword);
            if (writeUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(writeUserInfo.WriteMail, false);
                Session["WriteUserName"] = writeUserInfo.WriteMail;
                return RedirectToAction("MyContent", "WritePanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }
           
        }

    }
}