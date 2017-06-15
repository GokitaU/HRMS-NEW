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
    public class IssueEntryMgr
    {
        public List<IssueEntry> ProjectList()
        {
            IssueEntryDbo objIssueEntryDbo = new IssueEntryDbo();
            return objIssueEntryDbo.ProjectList();
        }
        public string Issuesave(IssueEntry IssueObj)
        {
            IssueEntryDbo objIssueEntryDbo = new IssueEntryDbo();
            return objIssueEntryDbo.Issuesave(IssueObj);
        }
        public string IssueUpdate(IssueEntry IssueObj)
        {
            IssueEntryDbo objIssueEntryDbo = new IssueEntryDbo();
            return objIssueEntryDbo.IssueUpdate(IssueObj);
        }
        public List<IssueEntry> MainGrid(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 UserID)
        {
            IssueEntryDbo objIssueEntryDbo = new IssueEntryDbo();
            return objIssueEntryDbo.MainGrid(PageNo, RowperPage, SearchText, UserID);
        }
        public List<IssueEntry> EntryDelete(int EntryId)
        {
            IssueEntryDbo objIssueEntryDbo = new IssueEntryDbo();
            return objIssueEntryDbo.EntryDelete(EntryId);
        }

    }
}
