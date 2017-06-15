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
    public class LeaveTypesMgr
    {
        public List<LeaveTypes> List(int PageNo, int RowsPerPage, string SearchText)
        {
            LeaveTypesMasterDBO objleavedbo = new LeaveTypesMasterDBO();
            return objleavedbo.LeaveList(PageNo, RowsPerPage, SearchText);
        }
        public Int32 CheckLeave(string LeaveTypeName)
        {
            LeaveTypesMasterDBO objleavedbo = new LeaveTypesMasterDBO();
            return objleavedbo.CheckName(LeaveTypeName);
        }
        public string Create(LeaveTypes objLeaveType)
        {
            LeaveTypesMasterDBO objleavedbo = new LeaveTypesMasterDBO();
            return objleavedbo.Create(objLeaveType);
        }
        public string Update(LeaveTypes objLeaveType)
        {
            LeaveTypesMasterDBO objleavedbo = new LeaveTypesMasterDBO();
            return objleavedbo.Update(objLeaveType);
        }

    }
}
