using HrmsLibrary.DataAccess;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    public class LeaveReportMgr
    {
        public List<LeaveApprove> FullListTable(int PageNo, int RowPerPage, string SearchText)
        {
            LeaveReportDbo objintDb = new LeaveReportDbo();
            return objintDb.FullListTable(PageNo, RowPerPage, SearchText);
        }
    }
}
