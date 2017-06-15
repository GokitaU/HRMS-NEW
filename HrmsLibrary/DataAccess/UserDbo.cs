using HrmsLibrary.Common;
using HrmsObjects.Details;
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
    internal class UserDbo
    {
        public List<User> SearchList(int PageNo, int RowsPerPage, string SearchText)
        {
            int TotalRecords = 0;
            List<User> UsersList = new List<User>();
            User objUsers = null;
            IDbConnection conn = null;
            IDbCommand cmd;
            IDataReader reader;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();

                using (cmd = DataFactory.CreateCommand("Sp_SearchUser", conn))
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
                            objUsers = new User();

                            objUsers.UserId = DBNull.Value.Equals(reader["UserId"]) ? 0 : Convert.ToInt64(reader["UserId"]);
                            objUsers.EmployeeId = DBNull.Value.Equals(reader["EmployeeId"]) ? 0 : Convert.ToInt64(reader["EmployeeId"]);
                            objUsers.UserName = DBNull.Value.Equals(reader["UserName"]) ? string.Empty : Convert.ToString(reader["UserName"]);
                            objUsers.EmployeeCode = DBNull.Value.Equals(reader["EmployeeCode"]) ? string.Empty : Convert.ToString(reader["EmployeeCode"]);
                            objUsers.Password = DBNull.Value.Equals(reader["Password"]) ? string.Empty : Convert.ToString(reader["Password"]);
                            objUsers.FullName = DBNull.Value.Equals(reader["FullName"]) ? string.Empty : Convert.ToString(reader["FullName"]);
                            objUsers.RoleID = DBNull.Value.Equals(reader["RoleID"]) ? 0 : Convert.ToInt64(reader["RoleID"]);
                            objUsers.RoleName = DBNull.Value.Equals(reader["RoleName"]) ? string.Empty : Convert.ToString(reader["RoleName"]);
                            objUsers.EmailId = DBNull.Value.Equals(reader["EmailID"]) ? string.Empty : Convert.ToString(reader["EmailID"]);
                            objUsers.ContactNo = DBNull.Value.Equals(reader["ContactNo"]) ? string.Empty : Convert.ToString(reader["ContactNo"]);
                            objUsers.Description = DBNull.Value.Equals(reader["Description"]) ? string.Empty : Convert.ToString(reader["Description"]);
                            objUsers.CreatedDate = DBNull.Value.Equals(reader["CreatedDate"]) ? DateTime.Now : Convert.ToDateTime(reader["CreatedDate"]); 
                            objUsers.TotalRecords = TotalRecords;
                            UsersList.Add(objUsers);
                        }
                    }
                }
                reader.Close();
            }
            return UsersList;
        }

        public List<User> RoleID()
        {
            List<User> userList = new List<User>();
            User objUser = null;
            IDbCommand cmd = null;
            IDbConnection conn = null;
            IDataReader reader = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_RoleIDList", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objUser = new User();
                        objUser.RoleID = Convert.ToInt64(reader["RoleId"]);
                        objUser.RoleName = Convert.ToString(reader["RoleName"]);
                        userList.Add(objUser);
                    }
                    reader.Close();
                }
                return userList;
            }

        }

        public Employee AutoBind(Int64 EmployeeId)
        {
            Employee objEmployee = new Employee();
            IDbCommand cmd = null;
            IDbConnection conn = null;
            IDataReader reader = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_UserListAutoBind", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objEmployee.EmployeeId = Convert.ToInt64(reader["EmployeeId"]);
                        objEmployee.EmployeeName = Convert.ToString(reader["EmployeeName"]);
                        objEmployee.EmployeeCode = DBNull.Value.Equals(reader["Employeecode"]) ? string.Empty : Convert.ToString(reader["Employeecode"]);
                        objEmployee.EmailID = DBNull.Value.Equals(reader["EmailID"]) ? string.Empty : Convert.ToString(reader["EmailID"]);
                        objEmployee.MobileNo = DBNull.Value.Equals(reader["MobileNo"]) ? string.Empty : Convert.ToString(reader["MobileNo"]);

                    }
                    reader.Close();
                }
                return objEmployee;
            }

        }

        public List<Employee> Employee()
        {
            List<Employee> objEmployeeList = new List<Employee>();
            Employee objEmployee = null;
            IDbCommand cmd = null;
            IDbConnection conn = null;
            IDataReader reader = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_UserEmployee", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;

                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objEmployee = new Employee();
                        objEmployee.EmployeeId = Convert.ToInt64(reader["EmployeeId"]);
                        objEmployee.EmployeeName = Convert.ToString(reader["EmployeeName"]);
                        objEmployeeList.Add(objEmployee);
                    }
                    reader.Close();
                }
                return objEmployeeList;
            }

        }
        public Int32 NameMatch(string Name)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            IDataReader reader;
            Int32 Exists = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_User_NameCheck", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Name", Name));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Exists = Convert.ToInt32(reader["Exist"]);
                    }

                    reader.Close();

                }
                return Exists;
            }

        }
        public string Create(User objUser)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;

            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateUsers", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", objUser.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserName", objUser.UserName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@FullName", objUser.FullName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Password", objUser.Password));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RoleID", objUser.RoleID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RoleName", objUser.RoleName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeCode",objUser.EmployeeCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmailID", objUser.EmailId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ContactNo", objUser.ContactNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Description", objUser.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@CreatedBy", objUser.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;

                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordsAffected = cmd.ExecuteNonQuery();
                    objUser.UserId = Convert.ToInt64(param.Value);

                }
            }
            return Convert.ToString(objUser.UserId);

        }

        public Boolean Update(User objUser)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;

            int RecordsAffected = 0;
            try
            {
                using (conn = DataFactory.CreateConnection())
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("Sp_CreateUsers", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("@IsSave", "0"));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@UserID", DBNull.Value));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", objUser.EmployeeId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@UserName", objUser.UserName));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@FullName", objUser.FullName));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@Password", objUser.Password));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@RoleID", objUser.RoleID));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@RoleName", objUser.RoleName));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeCode", objUser.EmployeeCode));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EmailID", objUser.EmailId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@ContactNo", objUser.ContactNo));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@Description", objUser.Description));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@CreatedBy", objUser.CreatedBy));
                        IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                        param.DbType = DbType.Int64;
                        cmd.Parameters.Add(param);
                        cmd.ExecuteNonQuery();
                    }
                    if (RecordsAffected >0)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {
                string m = ex.Message;
            }
            return false;
            }
        

        public string CheckOldPass(Int64 Userid)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            IDataReader dr = null;
            User ob = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CompareOldPass", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserId", Userid));
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        ob = new User();

                        ob.Password = Convert.ToString(dr["password"]);

                    }

                }
            }
            return ob.Password;
        }
    }
}
