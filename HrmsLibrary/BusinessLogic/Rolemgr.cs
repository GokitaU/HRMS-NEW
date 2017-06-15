using HrmsLibrary.DataAccess;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class Rolemgr
    {
        public List<Role> SearchPage(int PageNo, int RowsPerPage, string SearchText)
        {
            RoleDBOps objRoleDB = new RoleDBOps();
            return objRoleDB.SearchPage(PageNo, RowsPerPage, SearchText);
        }
        public string Create(Role objRole)
        {
            RoleDBOps objRoleDB = new RoleDBOps();
            return objRoleDB.Create(objRole);
        }
        public Boolean Update(Role objRole)
        {
            RoleDBOps objRoleDB = new RoleDBOps();
            return objRoleDB.Update(objRole);
        }
    }
}
