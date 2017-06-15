using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class Organization
    {
        #region Private Members

        private Int64 _OrganizationID;
        private string _OrganizationName;
        private string _OrganizationCode;
        private string _Address;
        private Int64 _clientid;
        private string _Areacode;
        private string _AreaID;
        private string _Citycode;
        private string _Statecode;
        private string _Countrycode;
        private string _CityID;
        private string _StateID;
        private string _CountryID;
        private string _AreaName;
        private string _City;
        private string _State;
        private string _Country;
        private string _Pincode;
        private string _PrimaryPhoneNo;
        private string _SecondaryPhoneNo;
        private string _FaxNo;
        private string _EmailID;
        private string _Website;
        private string _TinNo;
        private string _Description;
        private bool _Activeflag;
        private Int64 _CreatedBy;
        private int _totalRecords;

        #endregion

        #region Public Members

        [DataMember]
        public Int64 clientid
        {
            get { return _clientid; }
            set { _clientid = value; }
        }
        [DataMember]
        public Int64 OrganizationID
        {
            get { return _OrganizationID; }
            set { _OrganizationID = value; }
        }
        [DataMember]
        public string OrganizationName
        {
            get { return _OrganizationName; }
            set { _OrganizationName = value; }
        }
        [DataMember]
        public string OrganizationCode
        {
            get { return _OrganizationCode; }
            set { _OrganizationCode = value; }
        }
        [DataMember]
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
        [DataMember]
        public string Areacode
        {
            get { return _Areacode; }
            set { _Areacode = value; }
        }
        [DataMember]
        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }
        [DataMember]
        public string City
        {
            get { return _City; }
            set { _City = value; }
        }
        [DataMember]
        public string State
        {
            get { return _State; }
            set { _State = value; }
        }
        [DataMember]
        public string Country
        {
            get { return _Country; }
            set { _Country = value; }
        }
        [DataMember]
        public string Pincode
        {
            get { return _Pincode; }
            set { _Pincode = value; }
        }
        [DataMember]
        public string PrimaryPhoneNo
        {
            get { return _PrimaryPhoneNo; }
            set { _PrimaryPhoneNo = value; }
        }
        [DataMember]
        public string SecondaryPhoneNo
        {
            get { return _SecondaryPhoneNo; }
            set { _SecondaryPhoneNo = value; }
        }
        [DataMember]
        public string FaxNo
        {
            get { return _FaxNo; }
            set { _FaxNo = value; }
        }
        [DataMember]
        public string EmailID
        {
            get { return _EmailID; }
            set { _EmailID = value; }
        }
        [DataMember]
        public string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }
        [DataMember]
        public string TinNo
        {
            get { return _TinNo; }
            set { _TinNo = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        [DataMember]
        public bool Activeflag
        {
            get { return _Activeflag; }
            set { _Activeflag = value; }
        }
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        [DataMember]
        public int TotalRecords
        {
            get { return _totalRecords; }
            set { _totalRecords = value; }
        }
        [DataMember]
        public string CityID
        {
            get { return _CityID; }
            set { _CityID = value; }
        }
        [DataMember]
        public string StateID
        {
            get { return _StateID; }
            set { _StateID = value; }
        }
        [DataMember]
        public string CountryID
        {
            get { return _CountryID; }
            set { _CountryID = value; }
        }
        [DataMember]
        public string AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; }
        }
        [DataMember]
        public string Citycode
        {
            get { return _Citycode; }
            set { _Citycode = value; }
        }
        [DataMember]
        public string Statecode
        {
            get { return _Statecode; }
            set { _Statecode = value; }
        }
        [DataMember]
        public string Countrycode
        {
            get { return _Countrycode; }
            set { _Countrycode = value; }
        }
        #endregion

    }
}
