using HrmsLibrary.DataAccess;
using HrmsObjects.Details;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class IssueActiveMgr
    {
        public List<IssueEntry> ProjectList()
        {
            IssueActiveDbo objIssueActiveDbo = new IssueActiveDbo();
            return objIssueActiveDbo.ProjectList();
        }
        //public string Issuesave(IssueEntry IssueObj)
        //{
        //    IssueActiveDbo objIssueActiveDbo = new IssueActiveDbo();
        //    return objIssueActiveDbo.Issuesave(IssueObj);
        //}
        public List<IssueEntry> MainGrid(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 UserID)
        {
            IssueActiveDbo objIssueActiveDbo = new IssueActiveDbo();
            return objIssueActiveDbo.MainGrid(PageNo, RowperPage, SearchText, UserID);
        }
        public List<IssueEntry> MainGridClosed(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 UserId)
        {
            IssueActiveDbo objIssueActiveDbo = new IssueActiveDbo();
            return objIssueActiveDbo.MainGridClosed(PageNo, RowperPage, SearchText, UserId);
        }
        public string IssueUpdate(IssueEntry IssueObj)
        {
            IssueActiveDbo objIssueActiveDbo = new IssueActiveDbo();
            return objIssueActiveDbo.IssueUpdate(IssueObj);
        }
    }
}
