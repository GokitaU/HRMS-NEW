using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class Branch
    {
        #region private members
        private Int64 _BranchID;
        private string _BranchName;
        private string _OrganizationName;
        private Int64 _Orgid;
        private string _OrganizationCode;
        private string _Address;
        private Int64 _AreaID;
        private string _AreaName;
        private string _CityName;
        private string _StateName;
        private string _CountryName;
        private string _Phone;
        private string _Website;
        private string _EmailID;
        private string _Description;
        private Int64 _Createdby;
        private DateTime _Createddate;
        private Int64 _Modifiedby;
        private DateTime _Modifieddate;


        #endregion

        #region public members

        [DataMember]
        public string OrganizationCode
        {
            get { return _OrganizationCode; }
            set { _OrganizationCode = value; }
        }
        [DataMember]
        public DateTime Modifieddate
        {
            get { return _Modifieddate; }
            set { _Modifieddate = value; }
        }
        [DataMember]
        public DateTime Createddate
        {
            get { return _Createddate; }
            set { _Createddate = value; }
        }
        [DataMember]
        public Int64 AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; }
        }

        [DataMember]
        public Int64 Orgid
        {
            get { return _Orgid; }
            set { _Orgid = value; }
        }
        [DataMember]
        public Int64 Createdby
        {
            get { return _Createdby; }
            set { _Createdby = value; }
        }
        [DataMember]
        public Int64 Modifiedby
        {
            get { return _Modifiedby; }
            set { _Modifiedby = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [DataMember]
        public string OrganizationName
        {
            get { return _OrganizationName; }
            set { _OrganizationName = value; }
        }
        [DataMember]
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }
        [DataMember]
        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }
        [DataMember]
        public string Phone
        {
            get { return _Phone; }
            set { _Phone = value; }
        }
        [DataMember]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        [DataMember]
        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }
        [DataMember]
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        [DataMember]
        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }
        [DataMember]
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }
        [DataMember]
        public string BranchName
        {
            get { return _BranchName; }
            set { _BranchName = value; }
        }
        [DataMember]
        public Int64 BranchID
        {
            get { return _BranchID; }
            set { _BranchID = value; }
        }
        #endregion
    }
}