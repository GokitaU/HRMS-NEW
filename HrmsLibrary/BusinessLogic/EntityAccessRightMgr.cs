using HrmsLibrary.DataAccess;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.BusinessLogic
{
    [Serializable]
    public class EntityAccessRightMgr
    {
        public List<EntityAccessRights> EntityListgrid(Int64 Pageno, Int64 Rowperpage, string SearchText)
        {
            EntityAccessRightsDBO objEntityAccessRightsDB = new EntityAccessRightsDBO();
            return objEntityAccessRightsDB.EntityListgrid(Pageno, Rowperpage, SearchText);
        }
        public List<EntityAccessRights> ModuleList()
        {
            EntityAccessRightsDBO objEntityAccessRightsMgr = new EntityAccessRightsDBO();
            return objEntityAccessRightsMgr.ModuleList();
        }
        public List<EntityAccessRights> Listusername(string SearchText)
        {
            EntityAccessRightsDBO objEntityAccessRightsDB = new EntityAccessRightsDBO();
            return objEntityAccessRightsDB.Listusername(SearchText);
        }
        public List<EntityAccessRights> listRole(string SearchText)
        {
            EntityAccessRightsDBO objEntityAccessRightsDB = new EntityAccessRightsDBO();
            return objEntityAccessRightsDB.listRole(SearchText);
        }
        public List<entity> EntityList(int id)
        {
            EntityAccessRightsDBO objEntityAccessRightsDB = new EntityAccessRightsDBO();
            return objEntityAccessRightsDB.EntityList1( id);
        }
        public List<entity> EntityAccessList(int id, Int64 RoleId)
        {
            EntityAccessRightsDBO objEntityAccessRightsDB = new EntityAccessRightsDBO();
            return objEntityAccessRightsDB.EntityAccessList(id, RoleId);
        }
        public string Create(EntityAccessRights objEntityAccessRights)
        {
            EntityAccessRightsDBO objEntityAccessRightsDB = new EntityAccessRightsDBO();
            return objEntityAccessRightsDB.Create(objEntityAccessRights);
        }

        public List<EntityAccessRights> GetEntityRightsForMenu(Int64 userID, Int64 roleID)
        {
            EntityAccessRightsDBO objEntityAccessRightDB = new EntityAccessRightsDBO();
            return objEntityAccessRightDB.GetEntityRightsForMenu(userID, roleID);
        }
    }
}
