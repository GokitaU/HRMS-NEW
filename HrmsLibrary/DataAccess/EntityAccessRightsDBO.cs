using HrmsLibrary.Common;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.DataAccess
{
    [Serializable]
    public class EntityAccessRightsDBO
    {
        public List<EntityAccessRights> EntityListgrid(Int64 pageNo, Int64 rowsperpage, string SearchText)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            Int64 TotalRecords = 0;
            List<EntityAccessRights> objEntityUserRights = new List<EntityAccessRights>();
            EntityAccessRights objlist = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_entityaccessright_search", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Pageno", pageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", rowsperpage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    //cmd.Parameters.Add(DataFactory.CreateParameter("@ClientID", ClientID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            objlist = new EntityAccessRights();
                            objlist.Modulename = DBNull.Value.Equals(reader["ModuleTypeName"]) ? string.Empty : Convert.ToString(reader["ModuleTypeName"]);
                            objlist.ModuleTypeID = DBNull.Value.Equals(reader["ModuleTypeId"]) ? 0 : Convert.ToInt32(reader["ModuleTypeId"]);
                            objlist.RoleId = DBNull.Value.Equals(reader["RoleId"]) ? 0 : Convert.ToInt32(reader["RoleId"]);
                            objlist.Rolename = DBNull.Value.Equals(reader["RoleName"]) ? string.Empty : Convert.ToString(reader["RoleName"]);
                            objEntityUserRights.Add(objlist);
                        }
                    }
                    reader.Close();
                }
                return objEntityUserRights;
            }
        }
        public List<EntityAccessRights> ModuleList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<EntityAccessRights> objModuleList = new List<EntityAccessRights>();
            EntityAccessRights ModuleList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListModule", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ModuleList = new EntityAccessRights();
                        ModuleList.Modulename = DBNull.Value.Equals(reader["ModuleTypeName"]) ? string.Empty : Convert.ToString(reader["ModuleTypeName"]);
                        ModuleList.ModuleTypeID = DBNull.Value.Equals(reader["ModuleTypeId"]) ? 0 : Convert.ToInt32(reader["ModuleTypeId"]);
                        objModuleList.Add(ModuleList);
                    }
                    reader.Close();
                }
                return objModuleList;
            }
        }

        public List<EntityAccessRights> Listusername(string searchtext)
        {
            List<EntityAccessRights> EntityAccesslist = new List<EntityAccessRights>();
            EntityAccessRights objEntityAccessRights = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_EntityAccessRights_list", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserName", searchtext));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objEntityAccessRights = new EntityAccessRights();
                        objEntityAccessRights.UserId = Convert.ToInt64(reader["UserId"]);
                        objEntityAccessRights.Username = Convert.ToString(reader["Username"]);
                        EntityAccesslist.Add(objEntityAccessRights);
                    }
                }
                return EntityAccesslist;
            }
        }

        public List<EntityAccessRights> listRole(string searchtext)
        {
            List<EntityAccessRights> EntityAccesslist = new List<EntityAccessRights>();
            EntityAccessRights objEntityAccessRights = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_entityaccessrights_role", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RoleName", searchtext));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objEntityAccessRights = new EntityAccessRights();
                        objEntityAccessRights.RoleId = Convert.ToInt64(reader["RoleId"]);
                        objEntityAccessRights.Rolename = Convert.ToString(reader["RoleName"]);
                        EntityAccesslist.Add(objEntityAccessRights);
                    }
                }
                return EntityAccesslist;
            }
        }
        public List<entity> EntityList1( int id)
        {
            List<entity> Entitylist = new List<entity>();
            entity objEntity = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            try
            {
                using (conn = DataFactory.CreateConnection())
                {
                    int TotalRecords = 0;
                    conn.Open();
                    cmd = conn.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("[sp_EntityListByModule]", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                     
                        cmd.Parameters.Add(DataFactory.CreateParameter("id", id));
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            TotalRecords = Convert.ToInt32(reader["TotalRecords"]);
                        }

                        if (reader.NextResult())
                        {
                            while (reader.Read())
                            {
                                objEntity = new entity();
                                objEntity.EntityId = Convert.ToInt64(reader["EntityID"]);
                                objEntity.EntityName = Convert.ToString(reader["EntityName"]);
                                objEntity.ModuletypeId = Convert.ToInt64(reader["ModuleTypeID"]);
                                objEntity.Description = Convert.ToString(reader["Description"]);
                                objEntity.Activeflag = Convert.ToBoolean(reader["Activeflag"]);
                                objEntity.CreateDate = Convert.ToDateTime(reader["CreatedDate"]);
                                objEntity.TotalRecords = TotalRecords;
                                Entitylist.Add(objEntity);
                            }
                        }

                    }
                }
            }

            catch (Exception Ex)
            {
                string m = Ex.Message;
            }

            return Entitylist;
        }
    

        public List<entity> EntityAccessList(int ModuleId, Int64 RoleId)
        {
            List<entity> Entitylist = new List<entity>();
            entity objEntity = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_EntityAccess", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ModuleId", ModuleId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RoleId", RoleId));
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objEntity = new entity();
                        objEntity.EntityId = Convert.ToInt64(reader["EntityID"]);
                        objEntity.EntityAccessId = Convert.ToInt64(reader["EntityAccessId"]);

                        Entitylist.Add(objEntity);
                    }

                }

                return Entitylist;
            }
        }

        public string Create(EntityAccessRights objEntityAccessRights)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_EntityAccessRights", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EntityAccessId", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EntityId", objEntityAccessRights.EntityID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("moduletypeID", objEntityAccessRights.ModuleTypeID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("roleid", objEntityAccessRights.RoleId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("entitycreate", objEntityAccessRights.EntityCreate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("entityread", objEntityAccessRights.EntityRead));
                    cmd.Parameters.Add(DataFactory.CreateParameter("entitydelete", objEntityAccessRights.EntityDelete));
                    cmd.Parameters.Add(DataFactory.CreateParameter("entityupdate", objEntityAccessRights.EntityUpdate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("entityprint", objEntityAccessRights.EntityPrint));
                    cmd.Parameters.Add(DataFactory.CreateParameter("createdby", objEntityAccessRights.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("entitydescription", objEntityAccessRights.Entitydescription));

                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;


                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordsAffected = cmd.ExecuteNonQuery();

                }
                if (RecordsAffected > 0)
                    return Convert.ToString(objEntityAccessRights.EntityAccessId);
                else
                    return Convert.ToString(objEntityAccessRights.EntityAccessId);

            }
        }

        public List<EntityAccessRights> GetEntityRightsForMenu(Int64 userID, Int64 roleID)
        {
            List<EntityAccessRights> objEntityAccessRightsList = new List<EntityAccessRights>();
            EntityAccessRights objEntityAccessRights = null;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();

                using (cmd = DataFactory.CreateCommand("Sp_GetEntityAccessRightsForMenu", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("UserID", userID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("RoleID", roleID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objEntityAccessRights = new EntityAccessRights();
                        objEntityAccessRights.RoleId = Convert.ToInt64(reader["RoleId"]);
                        objEntityAccessRights.Modulename = Convert.ToString(reader["ModuleTypeName"]);
                        objEntityAccessRights.EntityName = Convert.ToString(reader["EntityName"]);
                        objEntityAccessRights.Rolename = Convert.ToString(reader["Rolename"]);
                        objEntityAccessRights.EntityDelete = Convert.ToBoolean(reader["EntityDelete"]);
                        objEntityAccessRightsList.Add(objEntityAccessRights);

                    }
                    reader.Close();
                }
            }
            return objEntityAccessRightsList;
        }
    }
}
