using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class Product
    {
        [DataMember]
        public Int64 ProductID { get; set; }
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public string ProjectManagerName { get; set; }
        [DataMember]
        public Int64 ProjectManagerId { get; set; }
        [DataMember]
        public Int64 ModuleMasterID { get; set; }
        [DataMember]
        public string ModuleMasterName { get; set; }
        [DataMember]
        public Int64 FormID { get; set; }
        [DataMember]
        public string FormName { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public int ActiveFlag { get; set; }
        [DataMember]
        public Int64 CreatedBy { get; set; }
        [DataMember]
        public Int64 TotalRecords { get; set; }
        
    }
}
