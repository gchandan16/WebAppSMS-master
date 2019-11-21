using DAL;
using SHARED;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAL
{
  public class BALRole
    {
        string ConStr = "";
        public BALRole(string ConnectionString)
        {
            ConStr = ConnectionString;
        }
        public void AddRole(RoleMaster rolemaster, List<MenuPermissionMapMaster> menupermissionList)
        {
            RoleDB Rdb = new RoleDB(ConStr);
            Rdb.AddRole(rolemaster, menupermissionList);
        }
    }
}
