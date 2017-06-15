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
    public class LeaveTypesMasterDBO
    {
        public List<LeaveTypes> LeaveList(int PageNo, int RowsPerPage, string SearchText)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            Int64 TotalRecords = 0;
            List<LeaveTypes> objleavetypes = new List<LeaveTypes>();
            LeaveTypes objlist = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("SP_LeaveTypeMaster_Search", conn))
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
                            objlist = new LeaveTypes();
                            objlist.LTypeID = Convert.ToInt64(reader["LTypeID"]);
                            objlist.LeaveType = Convert.ToString(reader["LeaveType"]);
                            objlist.Description = Convert.ToString(reader["Description"]);
                            objlist.TotalRecords1 = TotalRecords;
                            objleavetypes.Add(objlist);

                        }
                    }
                    reader.Close();
                }
                return objleavetypes;
            }
        }

        public Int32 CheckName(string LeaveTypeName)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            IDataReader reader;
            Int32 counts = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_LeaveTypeName_Check", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@LeaveType", LeaveTypeName));
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

        public string Create(LeaveTypes objLeaveType)
        {
            string LTypeID = string.Empty;
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_LeaveTypeMaster_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", 1));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LTypeID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LeaveType", objLeaveType.LeaveType));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objLeaveType.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objLeaveType.Createdby));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    LTypeID = param.Value.ToString();
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objLeaveType.LTypeID);
            else
                return "Error";

        }

        public string Update(LeaveTypes objLeaveType)
        {
            string LTypeID = string.Empty;
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_LeaveTypeMaster_Insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", "0"));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LTypeID", objLeaveType.LTypeID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LeaveType", objLeaveType.LeaveType));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objLeaveType.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objLeaveType.Createdby));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    LTypeID = param.Value.ToString();
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objLeaveType.LTypeID);
            else
                return "Error";

        }
    }
}
