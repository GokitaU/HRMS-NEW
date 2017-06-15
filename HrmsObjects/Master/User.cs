using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class User
    {
        [DataMember]
        public string OfficialMailId { get; set; }

        [DataMember]
        public Int64 EmployeeId { get; set; }
        [DataMember]
        public string EmployeeName { get; set; }
        [DataMember]
        public string DesignationName { get; set; }
        [DataMember]
        public string BranchName { get; set; }
        [DataMember]
        public Int64 ReportingManagerId { get; set; }
        private Int64 _UserId;
        [DataMember]
        public Int64 UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }
        private string _EmployeeCode;
        [DataMember]
        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }

        private string _RoleName;
        [DataMember]
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }
        private string _UserName;
        [DataMember]
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }


        private string _Password;
        [DataMember]
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _cPassword;
        [DataMember]
        public string cPassword
        {
            get { return _cPassword; }
            set { _cPassword = value; }
        }


        private string _Description;
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }


        private bool _ActiveFlag;
        [DataMember]
        public bool ActiveFlag
        {
            get { return _ActiveFlag; }
            set { _ActiveFlag = value; }
        }


        private Int64 _CreatedBy;
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }


        private DateTime _ModifiedDate;
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }


        private DateTime _createdDate;
        [DataMember]
        public DateTime CreatedDate
        {
            get { return _createdDate; }
            set { _createdDate = value; }
        }


        private Int64 _RoleID;
        [DataMember]
        public Int64 RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }


        private string _EmailId;
        [DataMember]
        public string EmailId
        {
            get { return _EmailId; }
            set { _EmailId = value; }
        }


        private string _ContactNo;
        [DataMember]
        public string ContactNo
        {
            get { return _ContactNo; }
            set { _ContactNo = value; }
        }


        private string _FullName;
        [DataMember]
        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }


        private string _RequestedFor;
        [DataMember]
        public string RequestedFor
        {
            get { return _RequestedFor; }
            set { _RequestedFor = value; }
        }


        private bool _ApproveFlag;
        [DataMember]
        public bool ApproveFlag
        {
            get { return _ApproveFlag; }
            set { _ApproveFlag = value; }
        }


        private bool _IsFirstLogin;
        [DataMember]
        public bool IsFirstLogin
        {
            get { return _IsFirstLogin; }
            set { _IsFirstLogin = value; }
        }


        private int _recordNO;
        [DataMember]
        public int RecordNO
        {
            get { return _recordNO; }
            set { _recordNO = value; }
        }


        private int _totalRecords;
        [DataMember]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }

        private int _counts;
        [DataMember]
        public int Counts
        {
            get { return _counts; }
            set { _counts = value; }
        }

    }
}
