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
        ChannelFactory<ICommonSrv> CF = new ChannelFactory<ICommonSrv>("COMMON");
        ICommonSrv CSvc;

        public AccountController()
        {
           CSvc  = (ICommonSrv)CF.CreateChannel();
        }
        //test done
        int a = 0;//for testing 
        StringBuilder str = new StringBuilder();
        List<MenuMaster> menulist;
        [AllowAnonymous]
        public ActionResult Create()
        {
            SignupModel model = new SignupModel();
            model.CountryList = CSvc.GetCountryList();
            model.CityList = CSvc.GetCityList(0);
            model.StateList = CSvc.GetStateList(0);
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Create(SignupModel model,FormCollection collection)
        {
            OragnisationMaster master = new OragnisationMaster();
            model.CountryList = CSvc.GetCountryList();
            model.CityList = CSvc.GetCityList(0);
            model.StateList = CSvc.GetStateList(0);
            if(ModelState.IsValid)
            {
                try
                {
                    HttpPostedFileBase empimg = Request.Files["emppathimage"];
                    if (empimg.ContentLength > 0)
                    {
                        string _FileName = Path.GetFileName(empimg.FileName);
                        string folderpath = Constants.EMPATTACHMENT;
                        string guidstring = Guid.NewGuid().ToString();
                        string filepath = Path.Combine(Server.MapPath(folderpath) + guidstring + "_" + _FileName);
                        string dbpath = Path.Combine(folderpath + guidstring + "_" + _FileName);
                        empimg.SaveAs(filepath);
                        master.OrgImage = dbpath;
                    }

                    master.Oname = model.Oname;
                    master.BOAddress = model.BOAddress;
                    master.BOAddress2 = model.BOAddress2;
                    master.BOCity = model.CITY_ID;
                    master.BOPincode = model.BOPincode;
                    master.LCountry = model.COUNTRY_ID;
                    master.LState = model.STATE_ID;
                    master.LDistict = model.LDistict;
                    master.LArea = model.LArea;
                    master.LEmailId = model.LEmailId;
                    master.LMobile = model.LMobile;
                    master.LPhone = model.LPhone;
                    master.LWebsite = model.LWebsite;
                    master.OAfficilate = model.OAfficilate;
                    master.OlicNo = model.OlicNo;
                    master.OTaxNo = model.OTaxNo;
                    master.OPanNo = model.OPanNo;
                    master.OContactNo = model.OContactNo;
                    master.IsActive = false;
                    master.Createddate = DateTime.Now;
                    master.Modifieddate = DateTime.Now;
                    master.CreatedBy = "EndUser";
                    master.ModifiedBy = "EndUser";
                    master.Otype = "INS" ;
                    int _retua =CSvc.OragnasitionBasicopation(master);
                    if(_retua>0)
                    {
                        WebSecurity.CreateUserAndAccount(master.LEmailId, "P@ssword1", new { Name = master.OContactNo, Mobile = master.LMobile, EmailId = master.LEmailId, Address = master.BOAddress, RoleId = 1, CITY_ID = master.BOCity, STATE_ID = master.LState, COUNTRY_ID = master.LCountry, ISACTIVE = 0 });
                       TempData[Constants.MessageInfo.SUCCESS]=  Constants.Orgnisation_ADD_SUCCESS;
                        ModelState.Values.Clear();
                       
                    }
                }
                catch (Exception ex)
                {
                    WebSecurity.Logout();
                    ExecptionLogger.FileHandling("Account(Create_Post)", "Error_014", ex, "Account");
                }

            }

            return View(model);
        }
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

        #region ForValidationPurpose
        [AllowAnonymous]
        public JsonResult EmailExists(string LEmailId)
        {
            OragnisationMaster master = new OragnisationMaster();
            master = CSvc.GetOragnisationAlready(LEmailId);
            return Json(!String.Equals(LEmailId, master.LEmailId, StringComparison.OrdinalIgnoreCase));
        }
        #endregion

    }

}

