using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    public class Department
    {
        public Int64 DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string Description { get; set; }
        public Int64 ClientID { get; set; }
        public bool Activeflag { get; set; }
        public Int64 Createdby { get; set; }
        public DateTime Createddate { get; set; }
        public Int64 TotalRecords { get; set; }

    }
}
