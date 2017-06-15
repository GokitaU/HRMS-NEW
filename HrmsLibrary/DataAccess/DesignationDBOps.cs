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
    public class DesignationDBOps
    {
        public List<Designation> DesigMainGrid(Int32 PageNo, Int32 RowperPage, String SearchText)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Int64 TotalRecord;
            List<Designation> deplist = new List<Designation>();
            Designation objdep = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_Designation_search", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowperPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecord = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                        while (reader.Read())
                        {
                            objdep = new Designation();
                            objdep.DesignationID = Convert.ToInt16(reader["DesignationID"]);
                            objdep.DesignationName = Convert.ToString(reader["DesignationName"]);
                            objdep.DesignationCode = Convert.ToString(reader["DesignationCode"]);
                            objdep.Description = Convert.ToString(reader["Description"]);
                            deplist.Add(objdep);
                        }
                    reader.Close();
                    return deplist;
                }
            }

        }
        public string Create(Designation objDesignation)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Designation_create", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationName", objDesignation.DesignationName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationCode", objDesignation.DesignationCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objDesignation.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createby", objDesignation.Createdby));
                    IDbDataParameter param = DataFactory.CreateParameter("@@Guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objDesignation.DesignationID = Convert.ToInt64(param.Value);
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objDesignation.DesignationID);
            else
                return "error";
        }
        public Boolean Update(Designation objdesn)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecoredAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Designation_create", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationID", objdesn.DesignationID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationName", objdesn.DesignationName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationCode", objdesn.DesignationCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objdesn.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createby", objdesn.Createdby));
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", 0));
                    IDbDataParameter param = DataFactory.CreateParameter("@@Guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecoredAffected = cmd.ExecuteNonQuery();
                }
                return true;
            }
        }
    }
}
