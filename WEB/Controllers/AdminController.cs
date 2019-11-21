using SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEB.Models;

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

        #region Role Management
        public ActionResult CreateRole(Nullable<int> RoleId,string ActionName="")
        {
            RoleModel model = new RoleModel();
            RoleMaster existingRole = new RoleMaster();
            if(RoleId.HasValue)
            {

            }
            return View();
        }
        #endregion

    }
}