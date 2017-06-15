using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Details
{
    [DataContract]
    public class IssueEntry
    {
        [DataMember]
        public Int64 IssueEntryID { get; set; }
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public Int64 ProjectId { get; set; }
        [DataMember]
        public string ModuleName { get; set; }
        [DataMember]
        public Int64 ModuleId { get; set; }
        [DataMember]
        public string AssignedToName { get; set; }
        [DataMember]
        public Int64 AssignedToId { get; set; }
        [DataMember]
        public string IssueDate { get; set; }
        [DataMember]
        public decimal IssueTime { get; set; }
        [DataMember]
        public int StatusFlag { get; set; }
        [DataMember]
        public string StatusName { get; set; }
        [DataMember]
        public string IssueDescription { get; set; }
        [DataMember]
        public string AssignedByName { get; set; }
        [DataMember]
        public Int64 AssignedById { get; set; }
        [DataMember]
        public Int64 CreatedBy { get; set; }
        [DataMember]
        public Int64 TotalRecords { get; set; }
        [DataMember]
        public string IssueClosedDate { get; set; }
        [DataMember]
        public string ActualTime { get; set; }
        [DataMember]
        public string ResolvedDescription { get; set; }

    }
}
