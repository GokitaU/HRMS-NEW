using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class Area
    {

        private Int64 _AreaID;
        private string _AreaName;
        private Int64 _activeflag;
        private Int64 _ClientId;
        private Int64 _Creadtedby;
        private string _CityName;
        private string _StateName;
        private string _CountryName;
        private string _Employeecode;
        private Int64 _TotalRecords;

        [DataMember]
        public Int64 AreaID
        {
            get { return _AreaID; }
            set { _AreaID = value; }
        }
        [DataMember]
        public string AreaName
        {
            get { return _AreaName; }
            set { _AreaName = value; }
        }
        [DataMember]
        public string Employeecode
        {
            get { return _Employeecode; }
            set { _Employeecode = value; }
        }
        [DataMember]
        public Int64 TotalRecords
        {
            get { return _TotalRecords; }
            set { _TotalRecords = value; }
        }
        public Int64 activeflag
        {
            get { return _activeflag; }
            set { _activeflag = value; }
        }
        [DataMember]
        public Int64 ClientId
        {
            get { return _ClientId; }
            set { _ClientId = value; }
        }
        [DataMember]
        public Int64 Creadtedby
        {
            get { return _Creadtedby; }
            set { _Creadtedby = value; }
        }
        [DataMember]
        public string StateName
        {
            get { return _StateName; }
            set { _StateName = value; }
        }
        [DataMember]
        public string CityName
        {
            get { return _CityName; }
            set { _CityName = value; }
        }
        [DataMember]
        public string CountryName
        {
            get { return _CountryName; }
            set { _CountryName = value; }
        }






    }
}
