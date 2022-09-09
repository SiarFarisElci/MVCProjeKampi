using Project.BLL.DesingPatterns.GenericRepository.ConcRep;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Project.MVCUI.Controllers
{
    public class StatisticController : Controller
    {
        CategoryRepository _cRep;
        HeadingRepository _hRep;
        WriteRepository _wRep;

        public StatisticController()
        {
            _wRep = new WriteRepository();
            _hRep = new HeadingRepository();
            _cRep = new CategoryRepository();   
        }
        // GET: Statistic
        public ActionResult Index()
        {
            //Kategori Sayisi
            TempData["TotalCategory"] = _cRep.GetActives().Count();

            //Yazılım Kategorisine gore ait baslılar

            TempData["SoftwareCategory"] = _hRep.GetActives().Count(x=> x.CategoryID ==2);

            //A Harfi olan yazar sayısı

            TempData["WriteName"] = _wRep.GetActives().Count(x=> x.Name.Contains("A") || x.Name.Contains("a"));

            //Enfazla Baslıga sahip kategori

            TempData["Title"] = _cRep.GetActives().Where(x => x.ID == x.Headings.GroupBy(y => y.CategoryID).OrderByDescending(y => y.Count()).Select(y => y.Key).FirstOrDefault()).Select(z => z.CategoryName).FirstOrDefault();


            //Aktif ve pasif arasındaki sayısal fark

            int fark = _cRep.GetActives().Count(x => x.Status != DataStatus.Deleted) - _cRep.GetActives().Count(y=> y.Status == DataStatus.Deleted);
            TempData["fark"] = fark;
            return View();
        }
    }
}