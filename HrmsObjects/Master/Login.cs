using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class Login
    {
        #region private members
        private string _organizationName;
        private string _organizationCode;
        private string _userName;
        private string _password;
        private Int64 _clientID;
        private Int64 _userID;
        private string _employeeCode;
        private string _employee;
        private string _employeename;
        private string _DateofBirth;
        private string _Designation;
        private string _Department;
        private Int32 _totalRecords;
        private Int32 _totalRecord;
        private string _Description;
        private Int32 _birthDayCount;
        private Int32 _RoleID;
        private Int64 _Age;
        private string _Email;

        private Int64 _Mid;
        private string _title;
        private string _link;

        private string _Stitle;
        private string _Slink;
        private Int64 _Sid;
        private Int64 _Smid;
        private string _Saction;
        private Int64 _employeeID;

        [DataMember]
        public Int64 EmployeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }
        [DataMember]
        public string EmployeeCode
        {
            get { return _employeeCode; }
            set { _employeeCode = value; }
        }

        [DataMember]
        public Int64 UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }

        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }

        [DataMember]
        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; }
        }
        [DataMember]
        public string OrganizationCode
        {
            get { return _organizationCode; }
            set { _organizationCode = value; }
        }
        [DataMember]
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }
        [DataMember]
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        [DataMember]
        public string Employee
        {
            get { return _employee; }
            set { _employee = value; }
        }
        [DataMember]
        public string EmployeeName
        {
            get { return _employeename; }
            set { _employeename = value; }
        }
        [DataMember]
        public string DateofBirth
        {
            get { return _DateofBirth; }
            set { _DateofBirth = value; }
        }
        [DataMember]
        public string Designation
        {
            get { return _Designation; }
            set { _Designation = value; }
        }
        [DataMember]
        public string Department
        {
            get { return _Department; }
            set { _Department = value; }
        }
        [DataMember]
        public Int32 TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }

        [DataMember]
        public Int32 RoleID
        {
            get { return _RoleID; }
            set { _RoleID = value; }
        }
        [DataMember]
        public Int32 TotalRecord
        {
            get { return _totalRecord; }
            set { _totalRecord = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [DataMember]
        public Int32 BirthDayCount
        {
            get { return _birthDayCount; }
            set { _birthDayCount = value; }
        }
        [DataMember]
        public Int64 Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        [DataMember]
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }



        [DataMember]
        public Int64 Mid
        {
            get { return _Mid; }
            set { _Mid = value; }
        }
        [DataMember]
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }
        [DataMember]
        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }



        [DataMember]
        public Int64 Sid
        {
            get { return _Sid; }
            set { _Sid = value; }
        }
        [DataMember]
        public string Stitle
        {
            get { return _Stitle; }
            set { _Stitle = value; }
        }
        [DataMember]
        public string Slink
        {
            get { return _Slink; }
            set { _Slink = value; }
        }


        [DataMember]
        public Int64 smid
        {
            get { return _Smid; }
            set { _Smid = value; }
        }
        [DataMember]
        public string Action
        {
            get { return _Saction; }
            set { _Saction = value; }
        }





        #endregion
    }
}
