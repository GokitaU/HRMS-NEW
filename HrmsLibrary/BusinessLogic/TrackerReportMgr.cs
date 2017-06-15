using HrmsLibrary.DataAccess;
using HrmsObjects.Details;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class TrackerReportMgr
    {
        public List<IssueEntry> MainGrid(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 UserID, string fromdate, string todate, Int64 status, Int64 txtAssignedId, Int64 txtProjectId, Int64 totxtTaskId)
        {
            TrackerReportDbo TrackerReportDbo = new TrackerReportDbo();
            return TrackerReportDbo.MainGrid(PageNo, RowperPage, SearchText, UserID,fromdate,todate, status, txtAssignedId,txtProjectId,totxtTaskId);
        }
        //public List<IssueEntry> ExportData(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 UserID, string fromdate, string todate, Int64 status, Int64 txtAssignedId, Int64 txtProjectId, Int64 totxtTaskId)
        //{
        //    TrackerReportDbo TrackerReportDbo = new TrackerReportDbo();
        //    return TrackerReportDbo.ExportData(PageNo, RowperPage, SearchText, UserID, fromdate, todate, status, txtAssignedId, txtProjectId, totxtTaskId);
        //}

        public List<Employee> GetEmployeeContacts(Int32 PageNo, Int32 RowperPage, String SearchText)
        {
            TrackerReportDbo TrackerReportDbo = new TrackerReportDbo();
            return TrackerReportDbo.GetEmployeeContacts(PageNo, RowperPage, SearchText);
        }
        public List<IssueEntry> ProjectList()
        {
            TrackerReportDbo TrackerReportDbo = new TrackerReportDbo();
            return TrackerReportDbo.ProjectList();
        }
        public List<Employee> EmployeeList()
        {
            TrackerReportDbo TrackerReportDbo = new TrackerReportDbo();
            return TrackerReportDbo.EmployeeList();
        }
        public List<Product> TaskList()
        {
            TrackerReportDbo TrackerReportDbo = new TrackerReportDbo();
            return TrackerReportDbo.TaskList();
        }
    }
}
