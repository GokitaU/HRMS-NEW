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
    public class DepartmentDBOps
    {
        public List<Department> Gridview(Int32 PageNo, Int32 RowsPerPage, String SearchText)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Int64 TotalRecords = 0;
            List<Department> deplist = new List<Department>();
            Department objdep = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_department_search", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
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
                        while (reader.Read())
                        {
                            objdep = new Department();
                            objdep.DepartmentID = Convert.ToInt16(reader["DepartmentID"]);
                            objdep.DepartmentName = Convert.ToString(reader["DepartmentName"]);
                            objdep.DepartmentCode = Convert.ToString(reader["DepartmentCode"]);
                            objdep.Description = Convert.ToString(reader["Description"]);
                            objdep.TotalRecords = TotalRecords;
                            deplist.Add(objdep);
                        }
                    reader.Close();
                    return deplist;
                }
            }
        }
        public string Create(Department objDepartment)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentName", objDepartment.DepartmentName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentCode", objDepartment.DepartmentCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objDepartment.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objDepartment.Createdby));
                    IDbDataParameter param = DataFactory.CreateParameter("@@Guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objDepartment.DepartmentID = Convert.ToInt64(param.Value);
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objDepartment.DepartmentID);
            else
                return "error";
        }
        public string Update(Department objDepartment)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateDepartment", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", false));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentID", objDepartment.DepartmentID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentName", objDepartment.DepartmentName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentCode", objDepartment.DepartmentCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objDepartment.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objDepartment.Createdby));
                    IDbDataParameter param = DataFactory.CreateParameter("@@Guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objDepartment.DepartmentID);
            else
                return "error";
        }
    }
}
