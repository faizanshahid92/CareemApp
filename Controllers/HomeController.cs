using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace URideApp.Controllers
{
   [Authorize]
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
            

        }
        public JsonResult SearchName(string SearchKeyword)
        {
            Models.FinalMVCProjectQueryEntities db = new Models.FinalMVCProjectQueryEntities();
            List<string> names = db.DriverInfoes.Where(i => i.DriverName.Contains(SearchKeyword)).Select(o => o.DriverName).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }
      
        public JsonResult SearchName2(string SearchKeyword)
        {
            Models.FinalMVCProjectQueryEntities db = new Models.FinalMVCProjectQueryEntities();
            List<string> names = db.CarInfoes.Where(i => i.Name.Contains(SearchKeyword)).Select(o => o.Name).ToList();
            return Json(names, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}