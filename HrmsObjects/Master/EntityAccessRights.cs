using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HrmsObjects.Master
{
    [DataContract]
    public class EntityAccessRights
    {
        [DataMember]
        public Int64 EntityID { get; set; }
        [DataMember]
        public Int64 ModuleTypeID { get; set; }
        [DataMember]
        public Int64 RoleId { get; set; }
        [DataMember]
        public Int64 CreatedBy { get; set; }
        [DataMember]
        public Int64 EntityAccessId { get; set; }
        [DataMember]
        public Int64 TotalRecords { get; set; }
        [DataMember]
        public Int64 UserId { get; set; }
        [DataMember]
        public string Entitydescription { get; set; }
        [DataMember]
        public string Username { get; set; }
        [DataMember]
        public string Modulename { get; set; }
        [DataMember]
        public string Rolename { get; set; }
        [DataMember]
        public string EntityName { get; set; }
        [DataMember]
        public bool EntityCreate { get; set; }
        [DataMember]
        public bool EntityDelete { get; set; }
        [DataMember]
        public bool EntityUpdate { get; set; }
        [DataMember]
        public bool EntityRead { get; set; }
        [DataMember]
        public bool EntityPrint { get; set; }

    }
    

}
