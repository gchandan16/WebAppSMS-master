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
using System.ServiceModel;
using ERROR;

namespace WEB.Controllers
{
    [PageActionFilter]
    public class FeeController : Controller
    {
        public FeeController()
        {
        }
        public ActionResult FeeHeads()
        {
            FeeHead FH = new FeeHead();
            ChannelFactory<ICommonSrv> CF = new ChannelFactory<ICommonSrv>("COMMON");
            ChannelFactory<IFeeSrv> CFFee = new ChannelFactory<IFeeSrv>("FEE");
            ICommonSrv CSvc = (ICommonSrv)CF.CreateChannel();
            IFeeSrv CSFee = (IFeeSrv)CFFee.CreateChannel();
            try
            {
                UserMasters userMasters = CSvc.getUserProfile(WebSecurity.CurrentUserName);
                FH.SchoolID = userMasters.SchoolID;
                FH.CreatedBy = WebSecurity.CurrentUserName;
                FH.Action = "GET";
                FH.lstFeeHead = CSFee.GetFeeHeads(FH);
            }
            catch(Exception ex) { }
            finally
            {
                CF.Close();
                CFFee.Close();
            }
            return View(FH);
        }
        public JsonResult SaveFeeTerm(string FeeTerm, int Refundable, int Active)
        {
            FeeHead FH = new FeeHead();
            ChannelFactory<ICommonSrv> CF = new ChannelFactory<ICommonSrv>("COMMON");
            ChannelFactory<IFeeSrv> CFFee = new ChannelFactory<IFeeSrv>("FEE");
            ICommonSrv CSvc = (ICommonSrv)CF.CreateChannel();
            IFeeSrv CSFee = (IFeeSrv)CFFee.CreateChannel();
            string actionStatus = "";
            try
            {
                UserMasters userMasters = CSvc.getUserProfile(WebSecurity.CurrentUserName);
                FH.FeeTerm = FeeTerm;
                FH.Refundable = Convert.ToBoolean(Refundable);
                FH.Active = Convert.ToBoolean(Active);
                FH.Action = "INS";
                FH.CreatedBy = WebSecurity.CurrentUserName;
                FH.SchoolID = userMasters.SchoolID;
                actionStatus = CSFee.SaveFeeTerm(FH);

            }
            catch(Exception ex)
            {
                ExecptionLogger.FileHandling("Fee(SaveFeeTerm)", "Error_014", ex, "Fee");
            }
            finally
            {
                CF.Close();
                CFFee.Close();
            }
            return Json(actionStatus, JsonRequestBehavior.AllowGet);
        }
    }
}
