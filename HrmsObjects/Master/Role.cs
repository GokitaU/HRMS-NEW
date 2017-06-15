using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class Role
    {

        private Int64 _roleID;
        private Int64 _clientID;
        private string _roleName;
        private string _description;
        private Boolean _Activeflag;
        private Int64 _createdby;
        private DateTime _createddate;
        private Int64 _modifiedby;
        private DateTime _modifieddate;
        private Int64 _totalRecords;
        private Int64 _counts;



        [DataMember]
        public Int64 TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public Int64 RoleID
        {
            get { return _roleID; }
            set { _roleID = value; }
        }
        [DataMember]
        public Int64 ClientID
        {
            get { return _clientID; }
            set { _clientID = value; }
        }
        [DataMember]
        public string RoleName
        {
            get { return _roleName; }
            set { _roleName = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DataMember]
        public Boolean Activeflag
        {
            get { return _Activeflag; }
            set { _Activeflag = value; }
        }
        [DataMember]
        public Int64 Createdby
        {
            get { return _createdby; }
            set { _createdby = value; }
        }
        [DataMember]
        public DateTime Createddate
        {
            get { return _createddate; }
            set { _createddate = value; }
        }
        [DataMember]
        public Int64 Modifiedby
        {
            get { return _modifiedby; }
            set { _modifiedby = value; }
        }

        [DataMember]
        public DateTime Modifieddate
        {
            get { return _modifieddate; }
            set { _modifieddate = value; }
        }
        [DataMember]
        public Int64 Counts
        {
            get { return _counts; }
            set { _counts = value; }
        }
    }
}
