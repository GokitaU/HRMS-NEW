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
    public class ModuleMasterDbo
    {
        public List<entity> MainGrid(int PageNo, int RowsPerPage, string SearchText)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            Int64 TotalRecords = 0;
            List<entity> objentity = new List<entity>();
            entity objlist = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("SP_ModuleTypeMaster_Search", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowsPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            objlist = new entity();
                            objlist.ModuletypeId = Convert.ToInt64(reader["ModuleTypeID"]);
                            objlist.ModuleName = Convert.ToString(reader["ModuleTypeName"]);
                            objlist.Description = Convert.ToString(reader["Description"]);
                            objlist.TotalRecords = TotalRecords;
                            objentity.Add(objlist);

                        }
                    }
                    reader.Close();
                }
                return objentity;
            }
        }

        public Int32 CheckModuleTypeName(string LeaveTypeName)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            IDataReader reader;
            Int32 counts = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("[Sp_ModuleTypeName_Check]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ModuleTypeName", LeaveTypeName));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        counts = Convert.ToInt32(reader["Activeflag"]);
                    }

                    reader.Close();

                }
                return counts;
            }

        }

        public string Create(entity objModuleType)
        {
            string LTypeID = string.Empty;
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("[Sp_ModuleTypeMaster_insert]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", 1));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleTypeID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleName", objModuleType.ModuleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objModuleType.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objModuleType.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    LTypeID = param.Value.ToString();
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objModuleType.ModuletypeId);
            else
                return "Error";

        }

        public string Update(entity objModuleType)
        {
            string LTypeID = string.Empty;
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ModuleTypeMaster_insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", "0"));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleTypeID",objModuleType.ModuletypeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleName", objModuleType.ModuleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description",objModuleType.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objModuleType.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    LTypeID = param.Value.ToString();
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objModuleType.ModuletypeId);
            else
                return "Error";

        }
    }
}
