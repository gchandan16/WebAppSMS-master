using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED;
using DAL;
using System.Data;

namespace BAL
{
    public class BALCommon
    { 
        string ConStr = "";
        public BALCommon(string ConnectionString)
        {
            ConStr = ConnectionString;
        }
      
        public DataSet GetCommonDashboardData(DashboardMaster obj)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetCommonDashboardData(obj);
        }

        public List<MenuMaster> GetAllMenuByStatus(string status)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetAllMenuByStatus(status);
        }

        public List<MenuMaster> GetMenuListByUserId(int userId)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetMenuListByUserId(userId);
        }

        public List<MenuMaster> GetAllMenuListByUserId(int userId)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetAllMenuListByUserId(userId);
        }

        public List<PermissionMaster> GetPermissionByMenuid(int menuId)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetPermissionByMenuid(menuId);
        }

        public List<UserMasters> GetAllUser()
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetAllUser();
        }

        public void AddUser(UserMasters UserMasters)
        {
            DALCommon dal = new DALCommon(ConStr);
             dal.AddUser(UserMasters);
        }

        public void UpdateUser(UserMasters UserMasters)
        {
            DALCommon dal = new DALCommon(ConStr);
             dal.UpdateUser(UserMasters);
        }

        public bool IsUserNameAllow(string UserName, int userId)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.IsUserNameAllow(UserName, userId);
        }

        public UserMasters GetByUserId(int userId)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetByUserId(userId);
        }


        public UserMasters ValidateUser(string UserName, string Password)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.ValidateUser(UserName, Password);
        }

        public void Insert(UserMasters usermaster)
        {
            DALCommon dal = new DALCommon(ConStr);
            dal.Insert(usermaster);
        }

        public void Update(UserMasters usermaster)
        {
            DALCommon dal = new DALCommon(ConStr);
            dal.Update(usermaster);
        }
        public UserMasters getUserProfile(string UserName)
        {
            DALCommon dal = new DALCommon(ConStr);
           return dal.GetUserProfile(UserName);
        }
        public UserInfo GetUserInfoByuserId(int userId)
        {
            DALCommon dal = new DALCommon(ConStr);
            return dal.GetUserInfoByuserId(userId);
        }
    }
}
