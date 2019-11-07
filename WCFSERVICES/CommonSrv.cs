using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED;
using BAL;
using System.Data;

namespace SERVICES
{
    public class CommonSrv : ICommonSrv
    {
        string ConStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
       
        
        public DataSet GetCommonDashboardData(DashboardMaster obj)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetCommonDashboardData(obj);
        }

        public List<MenuMaster> GetAllMenuByStatus(string status)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetAllMenuByStatus(status);
        }

        public List<MenuMaster> GetMenuListByUserId(int userId)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetMenuListByUserId(userId);
        }

        public List<MenuMaster> GetAllMenuListByUserId(int userId)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetAllMenuListByUserId(userId);
        }

        public List<PermissionMaster> GetPermissionByMenuid(int menuId)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetPermissionByMenuid(menuId);
        }

        public List<UserMasters> GetAllUser()
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetAllUser();
        }

        public void AddUser(UserMasters UserMasters)
        {
            BALCommon bal = new BALCommon(ConStr);
            bal.AddUser(UserMasters);
        }

        public void UpdateUser(UserMasters UserMasters)
        {
            BALCommon bal = new BALCommon(ConStr);
             bal.UpdateUser(UserMasters);
        }

        public bool IsUserNameAllow(string UserName, int userId)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.IsUserNameAllow(UserName, userId);
        }

        public UserMasters GetByUserId(int userId)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetByUserId(userId);
        }


        public UserMasters ValidateUser(string UserName, string Password)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.ValidateUser(UserName, Password);
        }

        public void Insert(UserMasters usermaster)
        {
            BALCommon bal = new BALCommon(ConStr);
            bal.Insert(usermaster);
        }

        public void Update(UserMasters usermaster)
        {
            BALCommon bal = new BALCommon(ConStr);
             bal.Update(usermaster);
        }
        public UserMasters getUserProfile(string UserName)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.getUserProfile(UserName);
        }
        public UserInfo GetUserInfoByuserId(int userId)
        {
            BALCommon bal = new BALCommon(ConStr);
            return bal.GetUserInfoByuserId(userId);
        }
    }
}
