using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SHARED
{
    [ServiceContract]
    public interface ICommonSrv
    {
        [OperationContract]
        DataSet GetCommonDashboardData(DashboardMaster obj);
        [OperationContract]
        List<MenuMaster> GetAllMenuByStatus(string status);
        [OperationContract]
        List<MenuMaster> GetMenuListByUserId(int userId);
        [OperationContract]
        List<MenuMaster> GetAllMenuListByUserId(int userId);
        [OperationContract]
        List<PermissionMaster> GetPermissionByMenuid(int menuId);
        [OperationContract]
        List<UserMasters> GetAllUser();
        [OperationContract]
        void AddUser(UserMasters UserMasters);
        [OperationContract]
        void UpdateUser(UserMasters UserMasters);
        [OperationContract]
        bool IsUserNameAllow(string UserName, int userId);
        [OperationContract]
        UserMasters GetByUserId(int userId);
        [OperationContract]
        UserInfo GetUserInfoByuserId(int userId);
        [OperationContract]
        UserMasters ValidateUser(string UserName, string Password);
        [OperationContract]
        void Insert(UserMasters usermaster);
        [OperationContract]
        void Update(UserMasters usermaster);
       
        [OperationContract]
        UserMasters getUserProfile(string UserName);
    }
}
