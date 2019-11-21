using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using SHARED;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class RoleDB
    {
        private SqlDatabase DBHelper;
        private SqlCommand cmd = null;
        DataSet ds = null;
        public RoleDB(string connectionstring)
        {
            DBHelper = new SqlDatabase(connectionstring);
        }

        public void AddRole(RoleMaster rolemaster,List<MenuPermissionMapMaster> menupermissionList)
        {

        }
    }
}
