using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WEB.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        #region EMPLOYEEMANAGEMENTSYSTEM
        public ActionResult EmployeeList()
        {
            return View();
        }

        public ActionResult CreateEmployee(Nullable<int> EmpId, string ActionName = "")
        {
            return View();
        }
        #endregion
    }
}