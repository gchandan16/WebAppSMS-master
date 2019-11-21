using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using WEB.AppCode;
using SHARED;
using WEB.Models;

namespace WEB.Controllers
{
    [PageActionFilter]
    public class HomeController : Controller
    {
        public HomeController()
        {
        }
        public ActionResult Index()
        {
            BaseModel model = new BaseModel();
           // UserMasters currentUser = new UserMasters();
            //currentUser.USER_ID = WebSecurity.CurrentUserId;
            //currentUser.USERNAME = WebSecurity.CurrentUserName;
            //var currentmonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            //model.FromDate = currentmonth;
            //model.ToDate = currentmonth.AddMonths(1).AddDays(-1);

            return View(model);
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
