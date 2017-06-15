using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class DashBoard
    {
        [DataMember]
        public Int64 ProjectId { get; set; }
        [DataMember]
        public string ProjectName { get; set; }
        [DataMember]
        public Int64 EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public int AssignedHours { get; set; }
        [DataMember]
        public int ActiveHours { get; set; }
        [DataMember]
        public int CompletedHours { get; set; }
        [DataMember]
        public int PendingHours { get; set; }
        [DataMember]
        public Int64 TotalRecords { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Count { get; set; }
    }
}
