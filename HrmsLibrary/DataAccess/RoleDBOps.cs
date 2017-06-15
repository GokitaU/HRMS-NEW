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
    public class RoleDBOps
    {
        public List<Role> SearchPage(int PageNo, int RowsPerPage, string SearchText)
        {
            int TotalRecords = 0;
            List<Role> roleList = new List<Role>();
            Role objRole;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_SearchRole", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("RowsPerPage", RowsPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt32(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            objRole = new Role();
                            objRole.RoleID = Convert.ToInt64(reader["roleId"]);
                            objRole.RoleName = Convert.ToString(reader["RoleName"]);
                            objRole.Description = Convert.ToString(reader["Description"]);
                            objRole.TotalRecords = TotalRecords;
                            roleList.Add(objRole);
                        }
                    }
                    reader.Close();
                    return roleList;
                }
            }
        }

        public string Create(Role objRole)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateRole", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("RoleID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("RoleName", objRole.RoleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objRole.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", objRole.Createdby));
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", 1));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordsAffected = cmd.ExecuteNonQuery();
                    objRole.RoleID = Convert.ToInt64(param.Value);
                }
                return Convert.ToString(objRole.RoleID);

            }
        }

        public Boolean Update(Role objRole)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateRole", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("RoleID", objRole.RoleID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("RoleName", objRole.RoleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objRole.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", objRole.Createdby));
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", 0));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;

                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordsAffected = cmd.ExecuteNonQuery();
                }

                return true;
            }
        }
    }
}
