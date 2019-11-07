using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;
using WebMatrix.WebData;
using WEB.Filters;
using WEB.Models;
using System.ServiceModel;
using System.Web.Script.Serialization;
using System.Collections;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using SHARED;
using BAL;
using System.IO;
using ERROR;
using WEB.AppCode;
namespace WEB.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class AccountController : Controller
    {
        //test
        StringBuilder str = new StringBuilder();
        List<MenuMaster> menulist;
        #region Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            try
            {
                if (WebSecurity.CurrentUserId != 0)
                {
                    WebSecurity.Logout();
                }
                ViewBag.ReturnUrl = returnUrl;
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("Account(UserLogin)", "Error_007", ex, "Account");
            }
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //[OutputCache(NoStore = true, Duration = 0, VaryByParam = "None")] 
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            try
            {
                //ChannelFactory<IMembershipSrv> CF = new ChannelFactory<IMembershipSrv>("MEMBERSHIP");
                //IMembershipSrv CSvc = (IMembershipSrv)CF.CreateChannel();
                //SHARED.UserProfile userProfile = new SHARED.UserProfile();
                //userProfile = CSvc.GetUserProfile(model.UserName);
                //CF.Close();
                if (ModelState.IsValid && WebSecurity.Login(model.UserName, AESEncrytDecry.DecryptStringAES(model.Password), persistCookie: model.RememberMe))
                {
                    ChannelFactory<ICommonSrv> CF = new ChannelFactory<ICommonSrv>("COMMON");
                    ICommonSrv CSvc = (ICommonSrv)CF.CreateChannel();
                    try
                    {
                        UserMasters userMasters = CSvc.getUserProfile(model.UserName);
                        CF.Close();
                        if (!userMasters.ISACTIVE)
                        {
                            TempData["Msg"] = "Please Contact To Technical Team.";
                            WebSecurity.Logout();
                        }
                        else {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    catch (Exception ex)
                    {
                        WebSecurity.Logout();
                        ExecptionLogger.FileHandling("Account(UserLogin_getUserProfilePost)", "Error_014", ex, "Account");
                    }

                }
                else
                {
                    TempData["Msg"] = "UserName and/or Password is incorrect.";
                }
            }
            catch (Exception ex)
            {
                WebSecurity.Logout();
                ExecptionLogger.FileHandling("Account(UserLoginPost)", "Error_014", ex, "Account");
            }
            return View(model);
        }
        #endregion Login
        
    }

}

