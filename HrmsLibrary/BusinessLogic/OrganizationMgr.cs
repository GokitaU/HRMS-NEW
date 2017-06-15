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
    public class OrganizationMgr
    {
        
        public string Create(Organization objMgr)
        {
            OrganizationDBOps objOrganization = new OrganizationDBOps();
            return objOrganization.Create(objMgr);
        }
        public List<Organization> SearchPage(int PageNo, int RowsPerPage, string SearchText, Int64 OrganizationID)
        {
            OrganizationDBOps objOrganization = new OrganizationDBOps();
            return objOrganization.SearchPage(PageNo,RowsPerPage,SearchText,OrganizationID);
        }
        public Boolean Update(Organization objMgr)
        {
            OrganizationDBOps objOrganization = new OrganizationDBOps();
            return objOrganization.Update(objMgr);
        }
    }
}
