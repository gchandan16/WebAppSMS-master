using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHARED;
using System.Data.SqlClient;
using System.Data;
using ERROR;

namespace DAL
{
    public class DALCommon
    {
        private SqlDatabase DBHelper;
        private SqlCommand cmd = null;
        DataSet ds =  null;
        public DALCommon(string connectionstring)
        {
            DBHelper = new SqlDatabase(connectionstring);
        }

        public DataSet GetCommonDashboardData(DashboardMaster obj)
        {
            DataSet ds = new DataSet();
            return ds;
        }

        public List<MenuMaster> GetAllMenuByStatus(string status)
        {
            List<MenuMaster> obj = new List<MenuMaster>();
            return obj;
        }

        public List<MenuMaster> GetMenuListByUserId(int userId)
        {
            List<MenuMaster> obj = new List<MenuMaster>();
            return obj;
        }

        public List<MenuMaster> GetAllMenuListByUserId(int userId)
        {
            List<MenuMaster> obj = new List<MenuMaster>();
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("usp_MENU_GetAllMenuListByUserId");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                ds = DBHelper.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count == 1)
                {
                    for (int l = 0; l < ds.Tables[0].Rows.Count; l++)
                    {
                        obj.Add(new MenuMaster
                        {
                            CREATEDBY = Convert.ToString(ds.Tables[0].Rows[l]["CreatedBy"]),
                            CREATEDDATE = Convert.ToDateTime(ds.Tables[0].Rows[l]["CreatedDate"]),
                            DISPLAYORDER = Convert.ToInt32(ds.Tables[0].Rows[l]["DisplayOrder"]),
                            IMAGEPATH = Convert.ToString(ds.Tables[0].Rows[l]["ImagePath"]),
                            ISACTIVE = Convert.ToBoolean(ds.Tables[0].Rows[l]["IsActive"]),
                            //ISDISPLAY = Convert.ToString(ds.Tables[0].Rows[l][""]),
                            MENUCODE = Convert.ToString(ds.Tables[0].Rows[l]["MenuCode"]),
                            MENUNAME = Convert.ToString(ds.Tables[0].Rows[l]["MenuName"]),
                            MENU_ID = Convert.ToInt32(ds.Tables[0].Rows[l]["Menu_Id"]),
                            PAGETITLE = Convert.ToString(ds.Tables[0].Rows[l]["PageTitle"]),
                            PARENTMENUID = Convert.ToInt32(ds.Tables[0].Rows[l]["ParentMenuID"]),
                            //  PermissionList = Convert.ToString(ds.Tables[0].Rows[l]["Permissions"]),
                            PermissionNameList = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[l]["Permissions"])) ? Convert.ToString(ds.Tables[0].Rows[l]["Permissions"]).Split(',').ToList() : null,
                            //Permissions = Convert.ToString(ds.Tables[0].Rows[l][""]),
                            URL = Convert.ToString(ds.Tables[0].Rows[l]["URL"]),
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(GetAllMenuListByUserId)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }
            return obj;
        }

        public List<PermissionMaster> GetPermissionByMenuid(int menuId)
        {
            List<PermissionMaster> obj = new List<PermissionMaster>();
            return obj;
        }

        public List<UserMasters> GetAllUser()
        {
            List<UserMasters> obj = new List<UserMasters>();
            return obj;
        }

        public void AddUser(UserMasters UserMasters)
        {

        }

        public void UpdateUser(UserMasters UserMasters)
        {

        }

        public bool IsUserNameAllow(string UserName, int userId)
        {
            return true;
        }

        public UserMasters GetByUserId(int userId)
        {
            UserMasters obj = new UserMasters();
            return obj;
        }
        public UserInfo GetUserInfoByuserId(int userId)
        {
            UserInfo obj = new UserInfo();
            
            try
            {
                cmd = new SqlCommand("usp_User_GetUserInfoByuserId");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserId", userId);
                var dr = DBHelper.ExecuteReader(cmd);
                while (dr.Read())
                {
                    obj.BIRTHDATE = Convert.ToString(dr["BIRTHDATE"]);
                    obj.CityName = Convert.ToString(dr["CITYNAME"]);
                    obj.COUNTRYNAME = Convert.ToString(dr["DEPARTMENTNAME"]);
                    obj.CurrentDate = Convert.ToString(dr["CURRENTDATE"]);
                    obj.DesgnationName = Convert.ToString(dr["DESGNATIONNAME"]);
                    obj.EMAIL = Convert.ToString(dr["EMAIL"]);
                    obj.MOBILENO = Convert.ToString(dr["MOBILENO"]);
                    obj.StateName = Convert.ToString(dr["STATENAME"]);
                    obj.USERCODE = Convert.ToString(dr["USERNAME"]);
                    obj.USERNAME = Convert.ToString(dr["USERNAME"]);
                    obj.UserType_Name = Convert.ToString(dr["USERTYPE_NAME"]);
                    obj.User_ID = Convert.ToInt32(dr["USER_ID"]);
                }
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(GetUserInfoByuserId)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }
            return obj;
        }

        public UserMasters ValidateUser(string UserName, string Password)
        {
            UserMasters obj = new UserMasters();
            return obj;
        }

        public void Insert(UserMasters usermaster)
        {

        }

        public void Update(UserMasters usermaster)
        {

        }
        public UserMasters GetUserProfile(string UserName)
        {
            UserMasters obj = new UserMasters();
            obj.ISACTIVE = false;
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("USP_GetUserProfile");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@UserName", UserName);
                ds = DBHelper.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count == 1)
                {
                    if (ds.Tables[0].Rows.Count == 1)
                    {
                        obj.ADDRESS = Convert.ToString(ds.Tables[0].Rows[0]["ADDRESS"]);
                        obj.CITY_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["CITY_ID"]);
                        obj.COUNTRY_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["COUNTRY_ID"]);
                        obj.CREATEDBY = Convert.ToString(ds.Tables[0].Rows[0]["CREATEDBY"]);
                        obj.EMAILID = Convert.ToString(ds.Tables[0].Rows[0]["EMAILID"]);
                        obj.FISRTNAME = Convert.ToString(ds.Tables[0].Rows[0]["FISRTNAME"]);
                        obj.IMAGE = Convert.ToString(ds.Tables[0].Rows[0]["IMAGE"]);
                        obj.ISUSERLOGGED = Convert.ToString(ds.Tables[0].Rows[0]["ISUSERLOGGED"]);
                        obj.LASTNAME = Convert.ToString(ds.Tables[0].Rows[0]["LASTNAME"]);
                        //obj.MenuPermissionList = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]["MenuPermissionList"])) ? Convert.ToString(ds.Tables[0].Rows[0]["MenuPermissionList"]).Split(',').ToList() : null,
                        obj.MODIFIEDBY = Convert.ToString(ds.Tables[0].Rows[0]["MODIFIEDBY"]);
                        obj.MODIFIEDDATE = Convert.ToDateTime(ds.Tables[0].Rows[0]["MODIFIEDDATE"]);
                        obj.PASSWORDRESETEXPIRATION = Convert.ToDateTime(ds.Tables[0].Rows[0]["PASSWORDRESETEXPIRATION"]);
                        obj.PASSWORDRESETTOKEN = Convert.ToString(ds.Tables[0].Rows[0]["PASSWORDRESETTOKEN"]);
                        obj.ROLE_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ROLE_ID"]);
                        obj.STATE_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["STATE_ID"]);
                        obj.USERNAME = Convert.ToString(ds.Tables[0].Rows[0]["USERNAME"]);
                        obj.USER_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["USER_ID"]);
                        obj.ISACTIVE = Convert.ToBoolean(ds.Tables[0].Rows[0]["ISACTIVE"]);
                        obj.SchoolID = Convert.ToString(ds.Tables[0].Rows[0]["SchoolID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(GetUserProfile)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }
            return obj;
        }
    }
}
