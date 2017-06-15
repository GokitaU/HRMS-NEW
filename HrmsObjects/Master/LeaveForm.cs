﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class LeaveForm
    {
        [DataMember]
        public int EmployeeID { get; set; }

        [DataMember]
        public decimal RemainingDays { get; set; }
        [DataMember]
        public int ReportingManagerId { get; set; }
        [DataMember]
        public int leaveTpyeId { get; set; }
        [DataMember]
        public int ID { get; set; }
        [DataMember]
        public string leaveTpye { get; set; }
        [DataMember]
        public string empCode { get; set; }
        [DataMember]
        public string empName { get; set; }
        [DataMember]
        public string fromDate { get; set; }
        [DataMember]
        public string toDate { get; set; }
        [DataMember]
        public decimal days { get; set; }
        [DataMember]
        public string reason { get; set; }
        [DataMember]
        public string timePeriodId { get; set; }
        [DataMember]
        public string timePeriod { get; set; }
        [DataMember]
        public int totalRecords { get; set; }
        [DataMember]
        public string stateName { get; set; }
        [DataMember]
        public string LeaveStatus { get; set; }

    }
}
