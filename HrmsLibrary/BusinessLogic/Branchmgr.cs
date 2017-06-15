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
    public class Branchmgr
    {
        public List<Branch> ListClientInfoMainPage(int PageNo, int RowsPerPage, string SearchText)
        {
            BranchDBops objbranchlist = new BranchDBops();
            return objbranchlist.ListClientInfoMainPage(PageNo, RowsPerPage, SearchText);
        }
        public string Create(Branch objmgr)
        {
            BranchDBops objbranch = new BranchDBops();
            return objbranch.Create(objmgr);
        }
        public string Update(Branch objmgr)
        {
            BranchDBops objbranch = new BranchDBops();
            return objbranch.Update(objmgr);
        }
        public List<Area> AreaList(string SearchText)
        {
            BranchDBops objbranchdrop = new BranchDBops();
            return objbranchdrop.AreaList(SearchText);
        }
        public List<Branch> OrgAuto(string SearchText)
        {
            BranchDBops objbranchdrop = new BranchDBops();
            return objbranchdrop.OrgAuto(SearchText);
        }
    }
}
