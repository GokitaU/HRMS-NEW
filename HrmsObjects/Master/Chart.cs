using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    public class ChartObj
    {
        [DataMember]
        public Int64 Count { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}
