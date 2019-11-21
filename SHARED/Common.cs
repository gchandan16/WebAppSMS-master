using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace SHARED
{
    public class Common
    {
    }

    public class Common_UserArea
    {
        public int AREAID { get; set; }
        public string AREANAME { get; set; }
        public string ISACTIVE { get; set; }

    }
    public class MenuMaster
    {
        [DataMember]
        public List<PermissionMaster> PermissionList { get; set; }
        [DataMember]
        public string Permissions { get; set; }
        [DataMember]
        public List<string> PermissionNameList { get; set; }
        public int MENU_ID { get; set; }
        public string MENUCODE { get; set; }
        public string MENUNAME { get; set; }
        public string PAGETITLE { get; set; }
        public Nullable<int> PARENTMENUID { get; set; }
        public Nullable<int> DISPLAYORDER { get; set; }
        public string URL { get; set; }
        public string IMAGEPATH { get; set; }
        public Boolean ISACTIVE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string ISDISPLAY { get; set; }
    }
    public class PermissionMaster
    {
        [DataMember]
        public List<PermissionMaster> PermissionList { get; set; }
    }
    public class MenuPermissionMapMaster
    {
        [DataMember]
        public int MENU_PERMISSION_ID { get; set; }
        [DataMember]
        public Nullable<int> MENU_ID { get; set; }
        [DataMember]
        public Nullable<int> PERMISSION_ID { get; set; }
        [DataMember]
        public string Menu_PermissionString { get; set; }
        [DataMember]
        public string LeafMenuString { get; set; }

    }
    public class RoleMenuPermissionMapping
    {
        [DataMember]
        public int ROLEMENUE_PERMISSION_ID { get; set; }
        [DataMember]
        public int ROLE_MENU_ID { get; set; }
        [DataMember]
        public int PERMISSION_ID { get; set; }
    }
    public class UserMasters
    {
        [DataMember]
        public List<MenuPermissionMapMaster> MenuPermissionList { get; set; }
        [DataMember]
        public int UserId { get; set; }
        [DataMember]
        public string FISRTNAME { get; set; }
        [DataMember]
        public string LASTNAME { get; set; }
        [DataMember]
        public string EMAILID { get; set; }
        [DataMember]
        public string USERNAME { get; set; }
        [DataMember]
        public string PASSWORD { get; set; }
        [DataMember]
        public string ADDRESS { get; set; }
        [DataMember]
        public Nullable<int> CITY_ID { get; set; }
        [DataMember]
        public Nullable<int> STATE_ID { get; set; }
        [DataMember]
        public Nullable<int> COUNTRY_ID { get; set; }
        [DataMember]
        public Nullable<int> ROLE_ID { get; set; }
        [DataMember]
        public bool ISACTIVE { get; set; }
        [DataMember]
        public string IMAGE { get; set; }
        [DataMember]
        public string CREATEDBY { get; set; }
        [DataMember]

        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        [DataMember]
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        [DataMember]
        public string MODIFIEDBY { get; set; }
        [DataMember]
        public string PASSWORDRESETTOKEN { get; set; }
        [DataMember]
        public Nullable<System.DateTime> PASSWORDRESETEXPIRATION { get; set; }

        [DataMember]
        public string ISUSERLOGGED { get; set; }
        [DataMember]
        public string SchoolID { get; set; }
    }
    public class DashboardMaster
    {
        [DataMember]
        public Nullable<DateTime> FROMDATE { get; set; }
        [DataMember]
        public Nullable<DateTime> TODATE { get; set; }
        [DataMember]
        public int USER_ID { get; set; }

    }
    
    public class UserModel 
    {
        public int User_Id { get; set; }
        public string UserCode { get; set; }
        [Required(ErrorMessage = "Please enter user code")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string Password { get; set; }
        public bool IsUserLoggedIn { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int Role_Id { get; set; }
        public List<MenuPermissionMapMaster> MenuPermissionList { get; set; }

        public List<RoleMaster> RoleList { get; set; }

        public List<UserMasters> UserList { get; set; }


    }
    public partial class RoleMaster
    {
        // Additional Parameter As per Requirement
        public string MenuName { get; set; }

        public string PermissionName { get; set; }

        public List<MenuPermissionMapMaster> MenuPermissionList { get; set; }


    }
    public class EmployeeModel 
    {
        public int EMP_ID { get; set; }

        [Required(ErrorMessage = "Please enter employee code")]
        public string EMPCODE { get; set; }
        public string ISACTIVE { get; set; }
        [Required(ErrorMessage = "Please select Department")]
        public int DEPARTMENT_ID { get; set; }
        [Required(ErrorMessage = "Please select Designation")]
        public int DESIGNATION_ID { get; set; }
        public int CONTACTTITLE { get; set; }
        [Required(ErrorMessage = "Please enter first name")]
        public string FIRSTNAME { get; set; }
        public string MIDDLENAME { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string LASTNAME { get; set; }
        [Required(ErrorMessage = "Please enter mobile number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid mobile number")]
        public string MOBILENUMBER { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Email is not valid")]
        public string EMAIL { get; set; }
        [Required(ErrorMessage = "Please enter date")]
        public Nullable<System.DateTime> BIRTHDATE { get; set; }
        [Required(ErrorMessage = "Please select gender")]
        public string GENDER { get; set; }
        [Required(ErrorMessage = "Please select blood group")]
        public string BLOODGROUP { get; set; }
        [Required(ErrorMessage = "Please select marital status")]
        public string MARITALSTATUS { get; set; }
        [Required(ErrorMessage = "Please enter qualification1")]
        public string QUALIFICATION1 { get; set; }
        public string QUALIFICATION2 { get; set; }
        [Required(ErrorMessage = "Please enter date")]
        public Nullable<System.DateTime> JOININGDATE { get; set; }

        public Nullable<System.DateTime> CONFIRMATIONDATE { get; set; }
        public Nullable<System.DateTime> LEAVINGDATE { get; set; }
        public decimal SALARY { get; set; }
        public string BANKACNO { get; set; }
        public string BANKNAME { get; set; }
        public string BANKBRANCH { get; set; }
        public string PFNO { get; set; }
        public string PANNO { get; set; }
        public string REMARKS { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string MODIFIEDBY { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        [Required(ErrorMessage = "Please enter FATHER  Name")]
        public string FATHER_SPOUSE { get; set; }
        public string PF_ESTD_CODE { get; set; }
        public string PF_UAN { get; set; }
        public Nullable<decimal> VPF_CONTB_RATE { get; set; }
        public string IFSC_CODE { get; set; }
        public string LEAVE_PL_ENTITLED { get; set; }
        public string LEAVE_CL_ENTITLED { get; set; }
        public string LEAVE_SL_ENTITLED { get; set; }
        public Nullable<decimal> GROSS_BASIC { get; set; }
        public Nullable<decimal> GROSS_HRA { get; set; }
        public Nullable<decimal> GROSS_CONVEYANCE { get; set; }
        public Nullable<decimal> GROSS_CHILDREN_EDUCATION { get; set; }
        public Nullable<decimal> GROSS_UNIFORM_MAINTENANCE { get; set; }
        public Nullable<decimal> GROSS_CAR_AMOUNT { get; set; }
        public Nullable<decimal> GROSS_SPECIAL_ALLOWANCE { get; set; }
        public Nullable<decimal> GROSS_SALARY { get; set; }
        public string EMERGENCY_CONT_PRS { get; set; }
        public string EMERGENCY_CONT_NO { get; set; }
        public Nullable<int> REPORTING_MANAGER { get; set; }
        public string PANIMGPATH { get; set; }
        public string EMPIMGPATH { get; set; }
        public string SPOUSE { get; set; }
        public List<ListItem> ContactList { get; set; }
        public List<ListItem> GenderList { get; set; }
        public List<ListItem> MaritalStatusList { get; set; }
        public List<ListItem> BloodGroupList { get; set; }

        public List<DepartmentMaster> DepartmentList { get; set; }
        public List<DesignationMaster> DesignationList { get; set; }
        public List<CityMaster> HdQtrList { get; set; }
        public List<PinMaster> PinCodeList { get; set; }

    }
    public class DepartmentMaster
    {
    }
    public  class DesignationMaster
    {
    }
    public  class PinMaster
    {
    }
    public class BaseModel
    {
        public List<string> PermissionNameList { get; set; }

        public UserInfo BaseUserInfo { get; set; }
        public string usermenu { get; set; }
    }
    public class Common_UserAreaModel
    {
        public List<Common_UserArea> C_CountryList { get; set; }
        public List<Common_UserArea> C_StateList { get; set; }
        public List<Common_UserArea> C_DistrictList { get; set; }
        public List<Common_UserArea> C_ZoneList { get; set; }
        public List<Common_UserArea> C_TerriotryList { get; set; }
        public List<Common_UserArea> C_CityList { get; set; }
        public List<Common_UserArea> C_PartyList { get; set; }
        public List<Common_UserArea> C_PartyGroupList { get; set; }

        public List<int> C_SelectedIds { get; set; }

        public string C_SelectedAreaType { get; set; }
        //public List<ListItem> C_AreaTypeList { get; set; }


        public List<Common_UserArea> C_SegmentList { get; set; }
        public List<Common_UserArea> C_ProductCategoryList { get; set; }
        public List<Common_UserArea> C_SubCategoryList { get; set; }
        public List<Common_UserArea> C_PartFamilyList { get; set; }
        public List<Common_UserArea> C_PartList { get; set; }
        public List<Common_UserArea> C_ExistingItemGroupList { get; set; }

        public string C_SelectedItemType { get; set; }
        public List<ListItem> C_ItemGroupTypeList { get; set; }

    }
    public class DashboardModel 
    {
        public Nullable<DateTime> FromDate { get; set; }
        public Nullable<DateTime> ToDate { get; set; }
        public StringBuilder ComonDashboardData { get; set; }

    }
    public class UserInfo
    {
        public string CityName { get; set; }

        public string StateName { get; set; }

        public string COUNTRYNAME { get; set; }


        public string DesgnationName { get; set; }

        public string CurrentDate { get; set; }

        public string UserType_Name { get; set; }

        public int User_ID { get; set; }
        public string BIRTHDATE { get; set; }
        public string MOBILENO { get; set; }
        public string EMAIL { get; set; }
        public string USERCODE { get; set; }
        public string USERNAME { get; set; }
        public string EMPIMGPATH { get; set; }

    }
    public class Constants
    {
        #region SystemRole
        public static string SUPERADMIN = "SUPERADMIN";
        #endregion
        #region BreadCrumbURL
        public const string DEMOBREADCRUMB = "";
        #endregion
        #region Status
        public const string ALLSTATUS = "";
        public const string NSTATUS = "N";
        public const string YSTATUS = "Y";
        #endregion
        public class Session
        {
            public const string USER = "CurrentUser";
            public const string USERINFO = "CurrentUserInfo";
            public const string MENU = "CurrentMenu";
            public const string MENUPERMISSION = "MenuPermission";
            public const string ALLMENUPERMISSION = "AllMenuPermission";
        }
        public class MessageInfo
        {
            public const string SUCCESS = "success";
            public const string ERROR = "error";
            public const string INFORMATION = "info";
            public const string WARNING = "warning";
            public const string BLANK = "Blank";
        }

        #region ListStatus
        public static string ACTIVE = "Y";
        public static string INACTIVE = "N";

        #endregion
        #region UserLogin
        public static string USER_NOT_VALID = "Incorrect username or password.";
        public static string AREA_NOT_ASSIGNED = "Please assign area before login.";
        #endregion

        #region RoleManagement
        public static string ROLE_ADD_SUCCESS = "Role added successfully";
        public static string ROLE_UPDATE_SUCCESS = "Role updated successfully";
        public static string ROLE_ADD_FAIL = "Unable to update details, Please try after sometime";
        public static string ROLE_DELETE_SUCCESS = "Role deleted successfully";
        public static string ROLE_DELETE_FAIL = "Unable to delete Role";
        #endregion

        #region Orgnisation
        public static string EMPATTACHMENT = "~/Content/Orgnisationatt/";
        public static string Orgnisation_ADD_SUCCESS = "Registered successfully";
        #endregion

        #region ButtonName

        public static string BTN_CREATE = "create";
        public static string BTN_EDIT = "edit";
        public static string BTN_DISPLAY = "display";
        #endregion

    }
}
