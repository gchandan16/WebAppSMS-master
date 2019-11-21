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
                //  cmd = new SqlCommand("usp_MENU_GetAllMenuListByUserId");
                cmd = new SqlCommand("USP_MENU_GETALLMENULISTBYROLEBYUSERID");
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
        /*
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

        */
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
                        obj.CREATEDBY = Convert.ToString(ds.Tables[0].Rows[0]["UpdatedBy"]);
                        obj.EMAILID = Convert.ToString(ds.Tables[0].Rows[0]["EmailId"]);
                        obj.FISRTNAME = Convert.ToString(ds.Tables[0].Rows[0]["Name"]);
                        obj.IMAGE = Convert.ToString(ds.Tables[0].Rows[0]["IMAGE"]);

                        obj.LASTNAME = Convert.ToString(ds.Tables[0].Rows[0]["Lastname"]);
                        // //obj.MenuPermissionList = !string.IsNullOrEmpty(Convert.ToString(ds.Tables[0].Rows[0]
                        obj.ROLE_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["RoleId"]);
                        obj.STATE_ID = Convert.ToInt32(ds.Tables[0].Rows[0]["STATE_ID"]);
                        obj.USERNAME = Convert.ToString(ds.Tables[0].Rows[0]["UserName"]);
                        obj.UserId = Convert.ToInt32(ds.Tables[0].Rows[0]["UserId"]);
                        obj.ISACTIVE = Convert.ToBoolean(ds.Tables[0].Rows[0]["ISACTIVE"]);
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


        #region RoleManagement
        public List<RoleMaster> GetRoleList()
        {
            List<RoleMaster> _obj = new List<RoleMaster>();
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("usp_RoleMaster_GetAll");
                cmd.CommandType = CommandType.StoredProcedure;
                ds = DBHelper.ExecuteDataSet(cmd);
                if (ds != null && ds.Tables.Count == 1)
                {
                    for (int l = 0; l < ds.Tables[0].Rows.Count; l++)
                    {
                        _obj.Add(new RoleMaster
                        {
                            ROLE_ID = Convert.ToInt32(ds.Tables[0].Rows[l]["Role_id"]),
                            ROLENAME = Convert.ToString(ds.Tables[0].Rows[l]["Rolename"]),
                            ROLEDESCRIPTION = Convert.ToString(ds.Tables[0].Rows[l]["ROLEDESCRIPTION"]),
                            ISACTIVE = Convert.ToString(ds.Tables[0].Rows[l]["ISACTIVE"]),
                            CREATEDBY = Convert.ToString(ds.Tables[0].Rows[l]["CREATEDBY"]),
                            CREATEDDATE = Convert.ToDateTime(ds.Tables[0].Rows[l]["CREATEDDATE"]),
                            MenuName = Convert.ToString(ds.Tables[0].Rows[l]["MenuName"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(GetRoleList)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }

            return _obj;
        }
        #endregion

        #region Country-State-City
        public List<CountryMaster> GetCountryList()
        {
            List<CountryMaster> _lst = null;
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("SP_CountryMster");
                cmd.CommandType = CommandType.StoredProcedure;
                _lst = new List<CountryMaster>();
                
                IDataReader reader = DBHelper.ExecuteReader(cmd);
                while (reader.Read())
                {
                    _lst.Add(new CountryMaster
                    {
                        COUNTRY_ID = DBNull.Value != reader["COUNTRY_ID"] ? (int)reader["COUNTRY_ID"] : default(int),
                        COUNTRYNAME = DBNull.Value != reader["COUNTRYNAME"] ? (string)reader["COUNTRYNAME"] : default(string),
                        COUNTRYDESC = DBNull.Value != reader["COUNTRYDESC"] ? (string)reader["COUNTRYDESC"] : default(string),
                        ISACTIVE = DBNull.Value != reader["ISACTIVE"] ? (bool)reader["ISACTIVE"] : default(bool),
                        CREATEDBY = DBNull.Value != reader["CREATEDBY"] ? (string)reader["CREATEDBY"] : default(string),
                        CREATEDDATE = DBNull.Value != reader["CREATEDDATE"] ? (DateTime)reader["CREATEDDATE"] : default(DateTime),
                        MODIFIEDBY = DBNull.Value != reader["MODIFIEDBY"] ? (string)reader["MODIFIEDBY"] : default(string),
                        MODIFIEDDATE = DBNull.Value != reader["MODIFIEDDATE"] ? (DateTime)reader["MODIFIEDDATE"] : default(DateTime),
                        COUNTRYCODE = DBNull.Value != reader["COUNTRYCODE"] ? (string)reader["COUNTRYCODE"] : default(string),
                    });

                }
                
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(GetCountryList)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }

            return _lst;
        }

        public List<StateMaster> GetStateList(int? COUNTRY_ID)
        {
            List<StateMaster> _lst = new List<StateMaster>();
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("SP_StateMster");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@COUNTRY_ID", COUNTRY_ID);
                IDataReader reader = DBHelper.ExecuteReader(cmd);
                while (reader.Read())
                {
                    _lst.Add(new StateMaster
                    {
                        STATE_ID = DBNull.Value != reader["STATE_ID"] ? (int)reader["STATE_ID"] : default(int),
                        STATECODE = DBNull.Value != reader["STATECODE"] ? (string)reader["STATECODE"] : default(string),
                        STATENAME = DBNull.Value != reader["STATENAME"] ? (string)reader["STATENAME"] : default(string),
                        STATEDESC = DBNull.Value != reader["STATEDESC"] ? (string)reader["STATEDESC"] : default(string),
                        ISACTIVE = DBNull.Value != reader["ISACTIVE"] ? (bool)reader["ISACTIVE"] : default(bool),
                        COUNTRY_ID = DBNull.Value != reader["COUNTRY_ID"] ? (int)reader["COUNTRY_ID"] : default(int),
                        CREATEDBY = DBNull.Value != reader["CREATEDBY"] ? (string)reader["CREATEDBY"] : default(string),
                        CREATEDDATE = DBNull.Value != reader["CREATEDDATE"] ? (DateTime)reader["CREATEDDATE"] : default(DateTime),
                        MODIFIEDBY = DBNull.Value != reader["MODIFIEDBY"] ? (string)reader["MODIFIEDBY"] : default(string),
                        MODIFIEDDATE = DBNull.Value != reader["MODIFIEDDATE"] ? (DateTime)reader["MODIFIEDDATE"] : default(DateTime),

                    });

                }
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(GetStateList)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }

            return _lst;
        }

        public List<CityMaster> GetCityList(int? STATE_ID)
        {
            List<CityMaster> _lst = new List<CityMaster>() ;
            ds = new DataSet();
            try
            {
                cmd = new SqlCommand("SP_CityMster");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@STATE_ID", STATE_ID);
                IDataReader reader = DBHelper.ExecuteReader(cmd);
                while (reader.Read())
                {
                    _lst.Add(new CityMaster
                    {
                        CITY_ID = DBNull.Value != reader["CITY_ID"] ? (int)reader["CITY_ID"] : default(int),
                        CITYCODE = DBNull.Value != reader["CITYCODE"] ? (string)reader["CITYCODE"] : default(string),
                        CITYNAME = DBNull.Value != reader["CITYNAME"] ? (string)reader["CITYNAME"] : default(string),
                        CITYDESC = DBNull.Value != reader["CITYDESC"] ? (string)reader["CITYDESC"] : default(string),
                        STATE_ID = DBNull.Value != reader["STATE_ID"] ? (int)reader["STATE_ID"] : default(int),
                        ISACTIVE = DBNull.Value != reader["ISACTIVE"] ? (bool)reader["ISACTIVE"] : default(bool),
                        CREATEDBY = DBNull.Value != reader["CREATEDBY"] ? (string)reader["CREATEDBY"] : default(string),
                        CREATEDDATE = DBNull.Value != reader["CREATEDDATE"] ? (DateTime)reader["CREATEDDATE"] : default(DateTime),
                        MODIFIEDBY = DBNull.Value != reader["MODIFIEDBY"] ? (string)reader["MODIFIEDBY"] : default(string),
                        MODIFIEDDATE = DBNull.Value != reader["MODIFIEDDATE"] ? (DateTime)reader["MODIFIEDDATE"] : default(DateTime),

                    });

                }
              
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(GetCityList)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }

            return _lst;
        }
        #endregion

        #region OrgnisationOpration
        public OragnisationMaster GetOragnisationAlready(string LEmailId)
        {
            OragnisationMaster _lst = new OragnisationMaster();
            try
            {
                cmd = new SqlCommand("SP_Orgnisationmexist");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@LEmailId", LEmailId);
                var reader = DBHelper.ExecuteReader(cmd);
                while(reader.Read())
                {

                    _lst.OMID = DBNull.Value != reader["OMID"] ? (int)reader["OMID"] : default(int);
                    _lst.Oname = DBNull.Value != reader["Oname"] ? (string)reader["Oname"] : default(string);
                    _lst.BOAddress = DBNull.Value != reader["BOAddress"] ? (string)reader["BOAddress"] : default(string);
                    _lst.BOAddress2 = DBNull.Value != reader["BOAddress2"] ? (string)reader["BOAddress2"] : default(string);
                    _lst.BOCity = DBNull.Value != reader["BOCity"] ? (int)reader["BOCity"] : default(int);
                    _lst.BOPincode = DBNull.Value != reader["BOPincode"] ? (string)reader["BOPincode"] : default(string);
                    _lst.LCountry = DBNull.Value != reader["LCountry"] ? (int)reader["LCountry"] : default(int);
                    _lst.LState = DBNull.Value != reader["LState"] ? (int)reader["LState"] : default(int);
                    _lst.LDistict = DBNull.Value != reader["LDistict"] ? (string)reader["LDistict"] : default(string);
                    _lst.LArea = DBNull.Value != reader["LArea"] ? (string)reader["LArea"] : default(string);
                    _lst.LEmailId = DBNull.Value != reader["LEmailId"] ? (string)reader["LEmailId"] : default(string);
                    _lst.LMobile = DBNull.Value != reader["LMobile"] ? (string)reader["LMobile"] : default(string);
                    _lst.LPhone = DBNull.Value != reader["LPhone"] ? (string)reader["LPhone"] : default(string);
                    _lst.LWebsite = DBNull.Value != reader["LWebsite"] ? (string)reader["LWebsite"] : default(string);
                    _lst.OAfficilate = DBNull.Value != reader["OAfficilate"] ? (string)reader["OAfficilate"] : default(string);
                    _lst.OlicNo = DBNull.Value != reader["OlicNo"] ? (string)reader["OlicNo"] : default(string);
                    _lst.OTaxNo = DBNull.Value != reader["OTaxNo"] ? (string)reader["OTaxNo"] : default(string);
                    _lst.OPanNo = DBNull.Value != reader["OPanNo"] ? (string)reader["OPanNo"] : default(string);
                    _lst.OContactNo = DBNull.Value != reader["OContactNo"] ? (string)reader["OContactNo"] : default(string);
                    _lst.IsActive = DBNull.Value != reader["IsActive"] ? (bool)reader["IsActive"] : default(bool);
                    _lst.Createddate = DBNull.Value != reader["Createddate"] ? (DateTime)reader["Createddate"] : default(DateTime);
                    _lst.CreatedBy = DBNull.Value != reader["CreatedBy"] ? (string)reader["CreatedBy"] : default(string);
                    _lst.Modifieddate = DBNull.Value != reader["Modifieddate"] ? (DateTime)reader["Modifieddate"] : default(DateTime);
                    _lst.ModifiedBy = DBNull.Value != reader["ModifiedBy"] ? (string)reader["ModifiedBy"] : default(string);

                    
                }
              
            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(OragnasitionBasicopation)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }
            return _lst;
        }


        public int OragnasitionBasicopation(OragnisationMaster _Omaster)
        {
            int rettype = -1;
            try
            {
                cmd = new SqlCommand("SP_Orgnisationmaster");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@OMID", _Omaster.OMID);
                cmd.Parameters.AddWithValue("@Oname", _Omaster.Oname);
                cmd.Parameters.AddWithValue("@BOAddress", _Omaster.BOAddress);
                cmd.Parameters.AddWithValue("@BOAddress2", _Omaster.BOAddress2);
                cmd.Parameters.AddWithValue("@BOCity", _Omaster.BOCity);
                cmd.Parameters.AddWithValue("@BOPincode", _Omaster.BOPincode);
                cmd.Parameters.AddWithValue("@LCountry", _Omaster.LCountry);
                cmd.Parameters.AddWithValue("@LState", _Omaster.LState);
                cmd.Parameters.AddWithValue("@LDistict", _Omaster.LDistict);
                cmd.Parameters.AddWithValue("@LArea", _Omaster.LArea);
                cmd.Parameters.AddWithValue("@LEmailId", _Omaster.LEmailId);
                cmd.Parameters.AddWithValue("@LMobile", _Omaster.LMobile);
                cmd.Parameters.AddWithValue("@LPhone", _Omaster.LPhone);
                cmd.Parameters.AddWithValue("@LWebsite", _Omaster.LWebsite);
                cmd.Parameters.AddWithValue("@OAfficilate", _Omaster.OAfficilate);
                cmd.Parameters.AddWithValue("@OlicNo", _Omaster.OlicNo);
                cmd.Parameters.AddWithValue("@OTaxNo", _Omaster.OTaxNo);
                cmd.Parameters.AddWithValue("@OPanNo", _Omaster.OPanNo);
                cmd.Parameters.AddWithValue("@OContactNo", _Omaster.OContactNo);
                cmd.Parameters.AddWithValue("@IsActive", _Omaster.IsActive);
                cmd.Parameters.AddWithValue("@Createddate", _Omaster.Createddate);
                cmd.Parameters.AddWithValue("@CreatedBy", _Omaster.CreatedBy);
                cmd.Parameters.AddWithValue("@Modifieddate", _Omaster.Modifieddate);
                cmd.Parameters.AddWithValue("@ModifiedBy", _Omaster.ModifiedBy);
                cmd.Parameters.AddWithValue("@OrgImage", _Omaster.OrgImage);
                cmd.Parameters.AddWithValue("@Otype", _Omaster.Otype);
              rettype=   DBHelper.ExecuteNonQuery(cmd);
               

            }
            catch (Exception ex)
            {
                ExecptionLogger.FileHandling("DALCommon(OragnasitionBasicopation)", "Error_014", ex, "DALCommon");
            }
            finally
            {
                cmd.Dispose();
            }
            return rettype;
        }
        #endregion


    }
}
