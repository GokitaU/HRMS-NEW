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
    public class LoginDBops
    {
        public User MyHome1(string UserName, string Password)
        {
            User objUserName = new User();
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Newuserdetail", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserName", UserName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Password", Password));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objUserName.UserId = Convert.ToInt64(reader["UserID"]);
                        objUserName.EmployeeCode = Convert.ToString(reader["EmployeeCode"]);
                        objUserName.EmailId = Convert.ToString(reader["EMailID"]);
                        objUserName.UserName = Convert.ToString(reader["UserName"]);
                        objUserName.ContactNo = Convert.ToString(reader["ContactNo"]);
                        objUserName.RoleID = Convert.ToInt64(reader["RoleID"]);
                        objUserName.RoleName = Convert.ToString(reader["RoleName"]);
                        objUserName.FullName = Convert.ToString(reader["FullName"]);
                        objUserName.EmployeeId = Convert.ToInt64(reader["EmployeeId"]);
                        objUserName.DesignationName = DBNull.Value.Equals(reader["DesignationName"]) ? "" : Convert.ToString(reader["DesignationName"]);
                        objUserName.BranchName = DBNull.Value.Equals(reader["BranchName"]) ? "" : Convert.ToString(reader["BranchName"]);
                        objUserName.ReportingManagerId = Convert.ToInt64(reader["ReportingManagerId"]);
                    }
                    reader.Close();
                    return objUserName;
                }
            }
        }
    }
}
