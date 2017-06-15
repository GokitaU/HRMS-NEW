using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class entity
    {
        #region Private Members

        private Int64 _entityId;
        private string _entityName;
        private Int64 _moduletypeId;
        private string _entityPath;
        private string _description;
        private bool _activeflag;
        private Int64 _createdBy;
        private DateTime _createDate;
        private string _ModifiedBy;
        private DateTime _ModifiedDate;
        private Int64 _TotalRecords;
        private Int64 _counts;
        private Int64 _EntityAccessId;

        #endregion


        #region Public Members
        [DataMember]
        public Int64 TotalRecords
        {
            get { return _TotalRecords; }
            set { _TotalRecords = value; }
        }

        [DataMember]
        public Int64 EntityId
        {
            get { return _entityId; }
            set { _entityId = value; }
        }
        [DataMember]
        public string EntityName
        {
            get { return _entityName; }
            set { _entityName = value; }
        }
        [DataMember]
        public Int64 ModuletypeId
        {
            get { return _moduletypeId; }
            set { _moduletypeId = value; }
        }
        [DataMember]
        public string EntityPath
        {
            get { return _entityPath; }
            set { _entityPath = value; }
        }
        [DataMember]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        [DataMember]
        public bool Activeflag
        {
            get { return _activeflag; }
            set { _activeflag = value; }
        }
        [DataMember]
        public Int64 CreatedBy
        {
            get { return _createdBy; }
            set { _createdBy = value; }
        }
        [DataMember]
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        [DataMember]
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }
        [DataMember]
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }
        [DataMember]
        public Int64 Counts
        {
            get { return _counts; }
            set { _counts = value; }
        }


        private string _formname;
        [DataMember]
        public string FormName
        {
            get { return _formname; }
            set { _formname = value; }
        }

        private string _modulename;
        [DataMember]
        public string ModuleName
        {
            get { return _modulename; }
            set { _modulename = value; }
        }

        [DataMember]
        public Int64 EntityAccessId
        {
            get { return _EntityAccessId; }
            set { _EntityAccessId = value; }
        }

        #endregion
    }
}
