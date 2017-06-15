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
    public class LeaveApplyMgr
    {
        public List<LeaveForm> Leavelist(int PageNo, int RowPerPage, string SearchText, int leaveEmployeeID)
        {
            LeaveApplyDBO objintDb = new LeaveApplyDBO();
            return objintDb.Leavelist(PageNo, RowPerPage, SearchText, leaveEmployeeID);
        }
        public List<LeaveForm> RemainingDaysAvailable(int PageNo, int RowPerPage, string SearchText, int EmployeeID)
        {
            LeaveApplyDBO objintDb = new LeaveApplyDBO();
            return objintDb.RemainingDaysAvailable(PageNo, RowPerPage, SearchText, EmployeeID);
        }
        public List<LeaveForm> autoList(string SEARCHTEXT)
        {
            LeaveApplyDBO objintDb = new LeaveApplyDBO();
            return objintDb.autoList(SEARCHTEXT);
        }
        public string insert(LeaveForm objint)
        {
            LeaveApplyDBO objintDb = new LeaveApplyDBO();
            return objintDb.insert(objint);
        }
        //public string Updated(LeaveForm objint)
        //{
        //    LeaveApplyDBO objintDb = new LeaveApplyDBO();
        //    return objintDb.Updated(objint);
        //}


    }
}
