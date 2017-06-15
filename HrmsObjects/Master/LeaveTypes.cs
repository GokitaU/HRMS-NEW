using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]

    public class LeaveTypes
    {
        private DateTime _empFromperiod;
        [DataMember]
        public DateTime empFromperiod
        {
            get { return _empFromperiod; }
            set { _empFromperiod = value; }
        }

        private DateTime _emptopriod;
        [DataMember]
        public DateTime emptopriod
        {
            get { return _emptopriod; }
            set { _emptopriod = value; }
        }
        private string _LeaveTyps;
        [DataMember]
        public string LeaveTyps
        {
            get { return _LeaveTyps; }
            set { _LeaveTyps = value; }
        }
        private Int64 _EmpLeavetypeID;
        [DataMember]
        public Int64 EmpLeavetypeID
        {
            get { return _EmpLeavetypeID; }
            set { _EmpLeavetypeID = value; }
        }
        private Int64 _EmployeeID;

        [DataMember]
        public Int64 EmployeeID
        {
            get { return _EmployeeID; }
            set { _EmployeeID = value; }
        }
        private Int64 _LTypeID;
        [DataMember]
        public Int64 LTypeID
        {
            get { return _LTypeID; }
            set { _LTypeID = value; }
        }

        private string _LeaveType;
        [DataMember]
        public string LeaveType
        {
            get { return _LeaveType; }
            set { _LeaveType = value; }
        }

        private Int32 _Days;
        [DataMember]
        public Int32 Days
        {
            get { return _Days; }
            set { _Days = value; }
        }

        private string _Description;
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }

        private string _Carryover;
        [DataMember]
        public string Carryover
        {
            get { return _Carryover; }
            set { _Carryover = value; }
        }

        private Int64 _totalRecords1;
        [DataMember]
        public Int64 TotalRecords1
        {
            get { return _totalRecords1; }
            set { _totalRecords1 = value; }
        }

        private Int32 _LeaveTypecode;
        [DataMember]
        public Int32 LeaveTypecode
        {
            get { return _LeaveTypecode; }
            set { _LeaveTypecode = value; }
        }

        private Double _Eligible;


        private Int64 _departmentid;
        [DataMember]
        public Int64 departmentid
        {
            get { return _departmentid; }
            set { _departmentid = value; }
        }

        private string _departmentname;
        [DataMember]
        public string departmentname
        {
            get { return _departmentname; }
            set { _departmentname = value; }
        }



        [DataMember]
        public Double Eligible
        {
            get { return _Eligible; }
            set { _Eligible = value; }
        }
        private Double _Taken;
        [DataMember]
        public Double Taken
        {
            get { return _Taken; }
            set { _Taken = value; }
        }
        private Double _Balance;
        [DataMember]
        public Double Balance
        {
            get { return _Balance; }
            set { _Balance = value; }
        }
        private Int16 _Activeflag;
        [DataMember]
        public Int16 Activeflag
        {
            get { return _Activeflag; }
            set { _Activeflag = value; }
        }
        private Int64 _ClientID;
        [DataMember]
        public Int64 ClientID
        {
            get { return _ClientID; }
            set { _ClientID = value; }
        }
        private Int64 _Createdby;
        [DataMember]
        public Int64 Createdby
        {
            get { return _Createdby; }
            set { _Createdby = value; }
        }
        private DateTime _Createddate;
        [DataMember]
        public DateTime Createddate
        {
            get { return _Createddate; }
            set { _Createddate = value; }
        }

        private Int64 _Modifiedby;
        [DataMember]
        public Int64 Modifiedby
        {
            get { return _Modifiedby; }
            set { _Modifiedby = value; }
        }
        private DateTime _ModifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        private Int64 _Fromperiod;
        [DataMember]
        public Int64 Fromperiod
        {
            get { return _Fromperiod; }
            set { _Fromperiod = value; }
        }
        private Int64 _Toperiod;
        [DataMember]
        public Int64 Toperiod
        {
            get { return _Toperiod; }
            set { _Toperiod = value; }
        }
        private Int64 _Carryforward;
        [DataMember]
        public Int64 Carryforward
        {
            get { return _Carryforward; }
            set { _Carryforward = value; }
        }

        private Int64 _Informbefore;
        [DataMember]
        public Int64 Informbefore
        {
            get { return _Informbefore; }
            set { _Informbefore = value; }
        }

        private Int64 _from;
        [DataMember]
        public Int64 from
        {
            get { return _from; }
            set { _from = value; }
        }


        private Int64 _to;
        [DataMember]
        public Int64 to
        {
            get { return _to; }
            set { _to = value; }
        }


        private Int64 _temp;
        [DataMember]
        public Int64 temp
        {
            get { return _temp; }
            set { _temp = value; }
        }

        private string _ParameterName;
        [DataMember]
        public string ParameterName
        {
            get { return _ParameterName; }
            set { _ParameterName = value; }
        }

        private Int64 _Flag;
        [DataMember]
        public Int64 Flag
        {
            get { return _Flag; }
            set { _Flag = value; }
        }
    }
}
