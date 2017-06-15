using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    public class Designation
    {
        public Int64 DesignationID { get; set; }
        public string DesignationName { get; set; }
        public string DesignationCode { get; set; }
        public string Description { get; set; }
        public Int64 ClientID { get; set; }
        public bool Activeflag { get; set; }
        public Int64 Createdby { get; set; }
        public DateTime Createddate { get; set; }
    }
}
