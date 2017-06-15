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
    public class ApproveMgr
    {
        public List<LeaveApprove> LeaveApprovelist(int PageNo, int RowPerPage, string SearchText, int EmployeeID)
        {
            LeaveApproveDBO objintDb = new LeaveApproveDBO();
            return objintDb.LeaveApprovelist(PageNo, RowPerPage, SearchText, EmployeeID);
        }
        
        public List<LeaveApprove> autoList(string SEARCHTEXT)
        {
            LeaveApproveDBO objintDb = new LeaveApproveDBO();
            return objintDb.autoList(SEARCHTEXT);
        }
        public List<LeaveApprove> Approval(int leaveEmployeeId, string fromDate, string toDate, decimal days, int leaveTypeID, int ApprovedId,string OfficailMailId,string empName,int EmployeeId)
        {
            LeaveApproveDBO objintDb = new LeaveApproveDBO();
            return objintDb.Approval(leaveEmployeeId, fromDate, toDate, days, leaveTypeID, ApprovedId,OfficailMailId,empName,EmployeeId);
        }

        public List<LeaveApprove> Reject(int ApprovedId, string OfficialMailId, string empName)
        {
            LeaveApproveDBO objintDb = new LeaveApproveDBO();
            return objintDb.leaveReject(ApprovedId,OfficialMailId,empName);
        }


    }
}
