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
    public class EmployeeDbo
    {
        public List<Employee> BranchList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<Employee> objEmployeeList = new List<Employee>();
            Employee EmployeeList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListBranch", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeList = new Employee();
                        EmployeeList.BranchName = DBNull.Value.Equals(reader["BranchName"]) ? string.Empty : Convert.ToString(reader["BranchName"]);
                        EmployeeList.BranchId = DBNull.Value.Equals(reader["BranchID"]) ? 0 : Convert.ToInt32(reader["BranchID"]);
                        objEmployeeList.Add(EmployeeList);
                    }
                    reader.Close();
                }
                return objEmployeeList;
            }
        }

        public List<Employee> DepartmentList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<Employee> objDepartmentList = new List<Employee>();
            Employee DepartmentList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListDepartment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DepartmentList = new Employee();
                        DepartmentList.DepartmentName = DBNull.Value.Equals(reader["DepartmentName"]) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                        DepartmentList.DepartmentId = DBNull.Value.Equals(reader["DepartmentID"]) ? 0 : Convert.ToInt32(reader["DepartmentID"]);
                        objDepartmentList.Add(DepartmentList);
                    }
                    reader.Close();
                }
                return objDepartmentList;
            }
        }

        public List<Employee> DesignationList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<Employee> objDesignationList = new List<Employee>();
            Employee DesignationList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListDesignation", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        DesignationList = new Employee();
                        DesignationList.DesignationName = DBNull.Value.Equals(reader["DesignationName"]) ? string.Empty : Convert.ToString(reader["DesignationName"]);
                        DesignationList.DesignationId = DBNull.Value.Equals(reader["DesignationID"]) ? 0 : Convert.ToInt32(reader["DesignationID"]);
                        objDesignationList.Add(DesignationList);
                    }
                    reader.Close();
                }
                return objDesignationList;
            }
        }

        public List<Employee> EmployeeList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<Employee> objEmployeeList = new List<Employee>();
            Employee EmployeeList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmployeeList = new Employee();
                        EmployeeList.EmployeeName = DBNull.Value.Equals(reader["EmployeeName"]) ? string.Empty : Convert.ToString(reader["EmployeeName"]);
                        EmployeeList.EmployeeId = DBNull.Value.Equals(reader["EmployeeId"]) ? 0 : Convert.ToInt32(reader["EmployeeId"]);
                        objEmployeeList.Add(EmployeeList);
                    }
                    reader.Close();
                }
                return objEmployeeList;
            }
        }

        public List<Employee> LeaveList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<Employee> objLeaveList = new List<Employee>();
            Employee LeaveList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListLeaveType", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LeaveList = new Employee();
                        LeaveList.LeaveType = DBNull.Value.Equals(reader["LeaveType"]) ? string.Empty : Convert.ToString(reader["LeaveType"]);

                        LeaveList.LeaveTypeId = DBNull.Value.Equals(reader["LeaveTypeId"]) ? "" : Convert.ToString(reader["LeaveTypeId"]);

                        objLeaveList.Add(LeaveList);
                    }
                    reader.Close();
                }
                return objLeaveList;
            }
        }
        public List<Employee> LeaveTypeList(int EmployeeID)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<Employee> objLeaveTypeList = new List<Employee>();
            Employee LeaveTypeList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_LeaveTypeList", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Employeeid", EmployeeID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        LeaveTypeList = new Employee();
                        LeaveTypeList.LeaveType = DBNull.Value.Equals(reader["LeaveType"]) ? string.Empty : Convert.ToString(reader["LeaveType"]);
                        LeaveTypeList.LeaveTypeId = DBNull.Value.Equals(reader["LTypeID"]) ? string.Empty : Convert.ToString(reader["LTypeID"]);
                        //LeaveTypeList.LeaveTypeId = DBNull.Value.Equals(reader["LTypeID"]) ? "" : Convert.ToString(reader["LeaveTypeId"]);

                        objLeaveTypeList.Add(LeaveTypeList);
                    }
                    reader.Close();
                }
                return objLeaveTypeList;
            }
        }

        public string Save(Employee PersonalObj)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            string EmployeeId = string.Empty;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeePersonal", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeCode", PersonalObj.EmployeeCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("FirstName", PersonalObj.FirstName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LastName", PersonalObj.LastName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DateOfBirth", PersonalObj.DateOfBirth));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Age", PersonalObj.Age));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BloodGroupFlag", PersonalObj.BloodGroupFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("GenderFlag", PersonalObj.GenderFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("MaritalStatus", PersonalObj.MaritalStatus));
                    cmd.Parameters.Add(DataFactory.CreateParameter("MobileNo", PersonalObj.MobileNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Religion", PersonalObj.Religion));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Nationality", PersonalObj.Nationality));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmailID", PersonalObj.EmailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LanguageKnown", PersonalObj.LanguageKnown));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Address", PersonalObj.Address));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmergencyContact", PersonalObj.EmergencyContact));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortTypeFlag", PersonalObj.PassPortTypeFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortNo", PersonalObj.PassPortNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortIssuePlace", PersonalObj.PassPortIssuePlace));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortIssueCountry", PersonalObj.PassPortIssueCountry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortDateIssue", PersonalObj.PassPortDateIssue));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortDateExpiry", PersonalObj.PassPortDateExpiry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaTypeFlag", PersonalObj.VisaTypeFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaNo", PersonalObj.VisaNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaDateIssue", PersonalObj.VisaDateIssue));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaDateExpiry", PersonalObj.VisaDateExpiry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PanNo", PersonalObj.PanNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceTypeFlag", PersonalObj.DriveLiceTypeFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceNo", PersonalObj.DriveLiceNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceDateIssue", PersonalObj.DriveLiceDateIssue));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceDateExpiry", PersonalObj.DriveLiceDateExpiry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", PersonalObj.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordsAffected = cmd.ExecuteNonQuery();
                    EmployeeId = param.Value.ToString();
                    
                }
                if (RecordsAffected > 0)
                    return EmployeeId;
                else
                    return EmployeeId;

            }
        }

        public string SaveOfficial(Employee OfficialObj)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeeOfficial", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", OfficialObj.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BranchId", OfficialObj.BranchId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentId", OfficialObj.DepartmentId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationId", OfficialObj.DesignationId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CategoryId", OfficialObj.CategoryId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ReportingManagerId", OfficialObj.ReportingManagerId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DateOfJoining", OfficialObj.DateOfJoining));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OfficialMailId", OfficialObj.OfficialMailId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProbationaryPeriod", OfficialObj.ProbationaryPeriod));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", OfficialObj.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", OfficialObj.CreatedBy));
                    RecordsAffected = cmd.ExecuteNonQuery();
                }
                if (RecordsAffected > 0)
                    return Convert.ToString(OfficialObj.EmployeeId);
                else
                    return Convert.ToString(OfficialObj.EmployeeId);

            }
        }

        public string SaveQualification(Employee Qualilist)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeeQualification", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", Qualilist.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", Qualilist.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Qualification", Qualilist.Qualification));
                    cmd.Parameters.Add(DataFactory.CreateParameter("MediumOfInstruction", Qualilist.MediumOfInstruction));
                    cmd.Parameters.Add(DataFactory.CreateParameter("UniversityName", Qualilist.UniversityName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CertificateNo", Qualilist.CertificateNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Percentage", Qualilist.Percentage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("YearOfPassOut", Qualilist.YearOfPassOut));
                    RecordsAffected = cmd.ExecuteNonQuery();
                }
                if (RecordsAffected > 0)
                    return Convert.ToString(Qualilist.EmployeeId);
                else
                    return Convert.ToString(Qualilist.EmployeeId);

            }
        }

        public string SaveExprience(Employee Explist)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeeExprience", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", Explist.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", Explist.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationName", Explist.OrganizationName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("WebSite", Explist.WebSite));
                    cmd.Parameters.Add(DataFactory.CreateParameter("WorkedAs", Explist.WorkedAs));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmpFromperiod", Explist.EmpFromperiod));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmpToperiod", Explist.EmpToperiod));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ReferenceManagerOrHrName", Explist.ReferenceManagerOrHrName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("RefContactNo", Explist.RefContactNo));
                    RecordsAffected = cmd.ExecuteNonQuery();
                }
                if (RecordsAffected > 0)
                    return Convert.ToString(Explist.EmployeeId);
                else
                    return Convert.ToString(Explist.EmployeeId);

            }
        }

        public string SaveLeave(Employee Leavelist)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeeLeave", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", Leavelist.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", Leavelist.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LeaveType", Leavelist.LeaveType));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LTypeID", Leavelist.LTypeID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LeaveFromDate", Leavelist.LeaveFromDate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LeaveToDate", Leavelist.LeaveToDate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Days", Leavelist.Days));
                    RecordsAffected = cmd.ExecuteNonQuery();
                }
                if (RecordsAffected > 0)
                    return Convert.ToString(Leavelist.EmployeeId);
                else
                    return Convert.ToString(Leavelist.EmployeeId);

            }
        }

        public string SaveAsset(Employee Assetlist)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeeAsset", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", Assetlist.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", Assetlist.CreatedBy));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AssetName", Assetlist.AssetName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("SerialNo", Assetlist.SerialNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AssetDate", Assetlist.AssetDate));
                    RecordsAffected = cmd.ExecuteNonQuery();
                }
                if (RecordsAffected > 0)
                    return Convert.ToString(Assetlist.EmployeeId);
                else
                    return Convert.ToString(Assetlist.EmployeeId);

            }
        }

        public List<Employee> MainGrid(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 RoleId, Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Int64 TotalRecord=0;
            List<Employee> emplist = new List<Employee>();
            Employee objemp = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeCurrentMain", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowperPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RoleId", RoleId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecord = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                        while (reader.Read())
                        {
                            objemp = new Employee();
                            objemp.EmployeeId = Convert.ToInt64(reader["EmployeeID"]);
                            objemp.EmployeeName = DBNull.Value.Equals(reader["EmployeeName"]) ? string.Empty : Convert.ToString(reader["EmployeeName"]);
                            objemp.EmployeeCode = Convert.ToString(reader["EmployeeCode"]);
                            objemp.DateOfBirth = Convert.ToString(reader["DateOfBirth"]);
                            objemp.Age = DBNull.Value.Equals(reader["Age"]) ? string.Empty : Convert.ToString(reader["Age"]);
                            objemp.BloodGroupFlag = DBNull.Value.Equals(reader["BloodGroupFlag"]) ? 0 : Convert.ToInt16(reader["BloodGroupFlag"]);
                            objemp.GenderFlag = DBNull.Value.Equals(reader["GenderFlag"]) ? 0 : Convert.ToInt16(reader["GenderFlag"]);
                            objemp.MaritalStatus = DBNull.Value.Equals(reader["MaritalStatus"]) ? 0 : Convert.ToInt16(reader["MaritalStatus"]);
                            objemp.MobileNo = DBNull.Value.Equals(reader["MobileNo"]) ? string.Empty : Convert.ToString(reader["MobileNo"]);
                            objemp.Religion = DBNull.Value.Equals(reader["Religion"]) ? 0 : Convert.ToInt16(reader["Religion"]);
                            objemp.Nationality = DBNull.Value.Equals(reader["Nationality"]) ? string.Empty : Convert.ToString(reader["Nationality"]);
                            objemp.EmailID = DBNull.Value.Equals(reader["EmailID"]) ? string.Empty : Convert.ToString(reader["EmailID"]);
                            objemp.LanguageKnown = DBNull.Value.Equals(reader["LanguageKnown"]) ? string.Empty : Convert.ToString(reader["LanguageKnown"]);
                            objemp.Address = DBNull.Value.Equals(reader["Address"]) ? string.Empty : Convert.ToString(reader["Address"]);
                            objemp.EmergencyContact = DBNull.Value.Equals(reader["EmergencyContact"]) ? string.Empty : Convert.ToString(reader["EmergencyContact"]);
                            objemp.PassPortTypeFlag = DBNull.Value.Equals(reader["PassPortTypeFlag"]) ? 0 : Convert.ToInt16(reader["PassPortTypeFlag"]);
                            objemp.PassPortNo = DBNull.Value.Equals(reader["PassPortNo"]) ? string.Empty : Convert.ToString(reader["PassPortNo"]);
                            objemp.PassPortIssuePlace = DBNull.Value.Equals(reader["PassPortIssuePlace"]) ? string.Empty : Convert.ToString(reader["PassPortIssuePlace"]);
                            objemp.PassPortIssueCountry = DBNull.Value.Equals(reader["PassPortIssueCountry"]) ? string.Empty : Convert.ToString(reader["PassPortIssueCountry"]);
                            objemp.PassPortDateIssue = DBNull.Value.Equals(reader["PassPortDateIssue"]) ? string.Empty : Convert.ToString(reader["PassPortDateIssue"]);
                            objemp.PassPortDateExpiry = DBNull.Value.Equals(reader["PassPortDateExpiry"]) ? string.Empty : Convert.ToString(reader["PassPortDateExpiry"]);
                            objemp.VisaTypeFlag = DBNull.Value.Equals(reader["VisaTypeFlag"]) ? 0 : Convert.ToInt16(reader["VisaTypeFlag"]);
                            objemp.VisaDateIssue = DBNull.Value.Equals(reader["VisaDateIssue"]) ? string.Empty : Convert.ToString(reader["VisaDateIssue"]);
                            objemp.VisaDateExpiry = DBNull.Value.Equals(reader["VisaDateExpiry"]) ? string.Empty : Convert.ToString(reader["VisaDateExpiry"]);
                            objemp.PanNo = DBNull.Value.Equals(reader["PanNo"]) ? string.Empty : Convert.ToString(reader["PanNo"]);
                            objemp.DriveLiceTypeFlag = DBNull.Value.Equals(reader["DriveLiceTypeFlag"]) ? 0 : Convert.ToInt16(reader["DriveLiceTypeFlag"]);
                            objemp.DriveLiceNo = DBNull.Value.Equals(reader["DriveLiceNo"]) ? string.Empty : Convert.ToString(reader["DriveLiceNo"]);
                            objemp.DriveLiceDateIssue = DBNull.Value.Equals(reader["DriveLiceDateIssue"]) ? string.Empty : Convert.ToString(reader["DriveLiceDateIssue"]);
                            objemp.DriveLiceDateExpiry = DBNull.Value.Equals(reader["DriveLiceDateExpiry"]) ? string.Empty : Convert.ToString(reader["DriveLiceDateExpiry"]);
                            objemp.DepartmentId = DBNull.Value.Equals(reader["DepartmentId"]) ? 0 : Convert.ToInt64(reader["DepartmentId"]);
                            objemp.DepartmentName = DBNull.Value.Equals(reader["DepartmentName"]) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                            objemp.DesignationId = DBNull.Value.Equals(reader["DesignationId"]) ? 0 : Convert.ToInt64(reader["DesignationId"]);
                            objemp.DesignationName = DBNull.Value.Equals(reader["DesignationName"]) ? string.Empty : Convert.ToString(reader["DesignationName"]);
                            objemp.DateOfJoining = DBNull.Value.Equals(reader["DateOfJoining"]) ? string.Empty : Convert.ToString(reader["DateOfJoining"]);
                            objemp.VisaNo = DBNull.Value.Equals(reader["VisaNo"]) ? string.Empty : Convert.ToString(reader["VisaNo"]);
                            objemp.TotalRecords = TotalRecord;
                            emplist.Add(objemp);
                        }
                    reader.Close();
                    return emplist;
                }
            }

        }

        public List<Employee> MainGridResgn(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 RoleId, Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Int64 TotalRecord;
            List<Employee> emplist = new List<Employee>();
            Employee objemp = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeResignMain", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowperPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RoleId", RoleId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecord = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                        while (reader.Read())
                        {
                            objemp = new Employee();
                            objemp.EmployeeId = Convert.ToInt64(reader["EmployeeID"]);
                            objemp.EmployeeName = DBNull.Value.Equals(reader["EmployeeName"]) ? string.Empty : Convert.ToString(reader["EmployeeName"]);
                            objemp.EmployeeCode = Convert.ToString(reader["EmployeeCode"]);
                            objemp.DateOfBirth = Convert.ToString(reader["DateOfBirth"]);
                            objemp.Age = DBNull.Value.Equals(reader["Age"]) ? string.Empty : Convert.ToString(reader["Age"]);
                            objemp.BloodGroupFlag = DBNull.Value.Equals(reader["BloodGroupFlag"]) ? 0 : Convert.ToInt16(reader["BloodGroupFlag"]);
                            objemp.GenderFlag = DBNull.Value.Equals(reader["GenderFlag"]) ? 0 : Convert.ToInt16(reader["GenderFlag"]);
                            objemp.MaritalStatus = DBNull.Value.Equals(reader["MaritalStatus"]) ? 0 : Convert.ToInt16(reader["MaritalStatus"]);
                            objemp.MobileNo = DBNull.Value.Equals(reader["MobileNo"]) ? string.Empty : Convert.ToString(reader["MobileNo"]);
                            objemp.Religion = DBNull.Value.Equals(reader["Religion"]) ? 0 : Convert.ToInt16(reader["Religion"]);
                            objemp.Nationality = DBNull.Value.Equals(reader["Nationality"]) ? string.Empty : Convert.ToString(reader["Nationality"]);
                            objemp.EmailID = DBNull.Value.Equals(reader["EmailID"]) ? string.Empty : Convert.ToString(reader["EmailID"]);
                            objemp.LanguageKnown = DBNull.Value.Equals(reader["LanguageKnown"]) ? string.Empty : Convert.ToString(reader["LanguageKnown"]);
                            objemp.Address = DBNull.Value.Equals(reader["Address"]) ? string.Empty : Convert.ToString(reader["Address"]);
                            objemp.EmergencyContact = DBNull.Value.Equals(reader["EmergencyContact"]) ? string.Empty : Convert.ToString(reader["EmergencyContact"]);
                            objemp.PassPortTypeFlag = DBNull.Value.Equals(reader["PassPortTypeFlag"]) ? 0 : Convert.ToInt16(reader["PassPortTypeFlag"]);
                            objemp.PassPortNo = DBNull.Value.Equals(reader["PassPortNo"]) ? string.Empty : Convert.ToString(reader["PassPortNo"]);
                            objemp.PassPortIssuePlace = DBNull.Value.Equals(reader["PassPortIssuePlace"]) ? string.Empty : Convert.ToString(reader["PassPortIssuePlace"]);
                            objemp.PassPortIssueCountry = DBNull.Value.Equals(reader["PassPortIssueCountry"]) ? string.Empty : Convert.ToString(reader["PassPortIssueCountry"]);
                            objemp.PassPortDateIssue = DBNull.Value.Equals(reader["PassPortDateIssue"]) ? string.Empty : Convert.ToString(reader["PassPortDateIssue"]);
                            objemp.PassPortDateExpiry = DBNull.Value.Equals(reader["PassPortDateExpiry"]) ? string.Empty : Convert.ToString(reader["PassPortDateExpiry"]);
                            objemp.VisaTypeFlag = DBNull.Value.Equals(reader["VisaTypeFlag"]) ? 0 : Convert.ToInt16(reader["VisaTypeFlag"]);
                            objemp.VisaDateIssue = DBNull.Value.Equals(reader["VisaDateIssue"]) ? string.Empty : Convert.ToString(reader["VisaDateIssue"]);
                            objemp.VisaDateExpiry = DBNull.Value.Equals(reader["VisaDateExpiry"]) ? string.Empty : Convert.ToString(reader["VisaDateExpiry"]);
                            objemp.PanNo = DBNull.Value.Equals(reader["PanNo"]) ? string.Empty : Convert.ToString(reader["PanNo"]);
                            objemp.DriveLiceTypeFlag = DBNull.Value.Equals(reader["DriveLiceTypeFlag"]) ? 0 : Convert.ToInt16(reader["DriveLiceTypeFlag"]);
                            objemp.DriveLiceNo = DBNull.Value.Equals(reader["DriveLiceNo"]) ? string.Empty : Convert.ToString(reader["DriveLiceNo"]);
                            objemp.DriveLiceDateIssue = DBNull.Value.Equals(reader["DriveLiceDateIssue"]) ? string.Empty : Convert.ToString(reader["DriveLiceDateIssue"]);
                            objemp.DriveLiceDateExpiry = DBNull.Value.Equals(reader["DriveLiceDateExpiry"]) ? string.Empty : Convert.ToString(reader["DriveLiceDateExpiry"]);
                            objemp.DepartmentId = DBNull.Value.Equals(reader["DepartmentId"]) ? 0 : Convert.ToInt64(reader["DepartmentId"]);
                            objemp.DepartmentName = DBNull.Value.Equals(reader["DepartmentName"]) ? string.Empty : Convert.ToString(reader["DepartmentName"]);
                            objemp.DesignationId = DBNull.Value.Equals(reader["DesignationId"]) ? 0 : Convert.ToInt64(reader["DesignationId"]);
                            objemp.DesignationName = DBNull.Value.Equals(reader["DesignationName"]) ? string.Empty : Convert.ToString(reader["DesignationName"]);
                            objemp.DateOfJoining = DBNull.Value.Equals(reader["DateOfJoining"]) ? string.Empty : Convert.ToString(reader["DateOfJoining"]);
                            objemp.DateOfResign = DBNull.Value.Equals(reader["DateOfResign"]) ? string.Empty : Convert.ToString(reader["DateOfResign"]);
                            emplist.Add(objemp);
                        }
                    reader.Close();
                    return emplist;
                }
            }

        }


        public Employee GetOfficial(Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Employee objoff = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeOfficial", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objoff = new Employee();
                        objoff.BranchId = DBNull.Value.Equals(reader["BranchId"]) ? 0 : Convert.ToInt64(reader["BranchId"]);
                        objoff.DepartmentId = DBNull.Value.Equals(reader["DepartmentId"]) ? 0 : Convert.ToInt64(reader["DepartmentId"]);
                        objoff.DesignationId = DBNull.Value.Equals(reader["DesignationId"]) ? 0 : Convert.ToInt64(reader["DesignationId"]);
                        objoff.CategoryId = DBNull.Value.Equals(reader["CategoryId"]) ? 0 : Convert.ToInt16(reader["CategoryId"]);
                        objoff.ReportingManagerId = DBNull.Value.Equals(reader["ReportingManagerId"]) ? 0 : Convert.ToInt16(reader["ReportingManagerId"]);
                        objoff.DateOfJoining = DBNull.Value.Equals(reader["DateOfJoining"]) ? string.Empty : Convert.ToString(reader["DateOfJoining"]);
                        objoff.OfficialMailId = DBNull.Value.Equals(reader["OfficialMailId"]) ? string.Empty : Convert.ToString(reader["OfficialMailId"]);

                        objoff.ProbationaryPeriod = DBNull.Value.Equals(reader["ProbationaryPeriod"]) ? 0 : Convert.ToInt16(reader["ProbationaryPeriod"]);
                        objoff.Description = DBNull.Value.Equals(reader["Description"]) ? string.Empty : Convert.ToString(reader["Description"]);
                        objoff.DateOfResign = DBNull.Value.Equals(reader["DateOfResign"]) ? string.Empty : Convert.ToString(reader["DateOfResign"]);
                        objoff.ResignFlag = DBNull.Value.Equals(reader["ResignFlag"]) ? 0 : Convert.ToInt16(reader["ResignFlag"]);

                    }
                    reader.Close();
                    return objoff;
                }
            }

        }

        public List<Employee> GetQualification(Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Employee objoff = null;
            List<Employee> QualList = new List<Employee>();
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeQualification", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objoff = new Employee();
                        objoff.EmployeeQualificationId = DBNull.Value.Equals(reader["EmployeeQualificationId"]) ? 0 : Convert.ToInt64(reader["EmployeeQualificationId"]);
                        objoff.Qualification = DBNull.Value.Equals(reader["Qualification"]) ? "" : Convert.ToString(reader["Qualification"]);
                        objoff.MediumOfInstruction = DBNull.Value.Equals(reader["MediumOfInstruction"]) ? "" : Convert.ToString(reader["MediumOfInstruction"]);
                        objoff.UniversityName = DBNull.Value.Equals(reader["UniversityName"]) ? "" : Convert.ToString(reader["UniversityName"]);
                        objoff.CertificateNo = DBNull.Value.Equals(reader["CertificateNo"]) ? "" : Convert.ToString(reader["CertificateNo"]);
                        objoff.Percentage = DBNull.Value.Equals(reader["Percentage"]) ? string.Empty : Convert.ToString(reader["Percentage"]);
                        objoff.YearOfPassOut = DBNull.Value.Equals(reader["YearOfPassOut"]) ? 0 : Convert.ToInt16(reader["YearOfPassOut"]);
                        QualList.Add(objoff);
                    }
                    reader.Close();
                    return QualList;
                }
            }

        }

        public List<Employee> GetExperience(Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Employee objoff = null;
            List<Employee> ExpList = new List<Employee>();
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeExprience", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objoff = new Employee();
                        objoff.EmployeeExprienceId = DBNull.Value.Equals(reader["EmployeeExprienceId"]) ? 0 : Convert.ToInt64(reader["EmployeeExprienceId"]);
                        objoff.OrganizationName = DBNull.Value.Equals(reader["OrganizationName"]) ? "" : Convert.ToString(reader["OrganizationName"]);
                        objoff.WebSite = DBNull.Value.Equals(reader["WebSite"]) ? "" : Convert.ToString(reader["WebSite"]);
                        objoff.WorkedAs = DBNull.Value.Equals(reader["WorkedAs"]) ? "" : Convert.ToString(reader["WorkedAs"]);
                        objoff.EmpFromperiod = DBNull.Value.Equals(reader["EmpFromperiod"]) ? "" : Convert.ToString(reader["EmpFromperiod"]);
                        objoff.EmpToperiod = DBNull.Value.Equals(reader["EmpToperiod"]) ? string.Empty : Convert.ToString(reader["EmpToperiod"]);
                        objoff.ReferenceManagerOrHrName = DBNull.Value.Equals(reader["ReferenceManagerOrHrName"]) ? "" : Convert.ToString(reader["ReferenceManagerOrHrName"]);
                        objoff.RefContactNo = DBNull.Value.Equals(reader["RefContactNo"]) ? string.Empty : Convert.ToString(reader["RefContactNo"]);


                        ExpList.Add(objoff);
                    }
                    reader.Close();
                    return ExpList;
                }
            }

        }

        public List<Employee> GetLeave(Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Employee objoff = null;
            List<Employee> LeaveList = new List<Employee>();
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeLeave", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objoff = new Employee();
                        objoff.EmployeeLeaveId = DBNull.Value.Equals(reader["EmployeeLeaveId"]) ? 0 : Convert.ToInt64(reader["EmployeeLeaveId"]);
                        objoff.LeaveType = DBNull.Value.Equals(reader["LeaveType"]) ? "" : Convert.ToString(reader["LeaveType"]);
                        objoff.LeaveFromDate = DBNull.Value.Equals(reader["LeaveFromDate"]) ? "" : Convert.ToString(reader["LeaveFromDate"]);
                        objoff.LeaveToDate = DBNull.Value.Equals(reader["LeaveToDate"]) ? "" : Convert.ToString(reader["LeaveToDate"]);
                        objoff.Days = DBNull.Value.Equals(reader["Days"]) ? 0 : Convert.ToInt16(reader["Days"]);
                        objoff.LTypeID = DBNull.Value.Equals(reader["LTypeID"]) ? 0 : Convert.ToInt64(reader["LTypeID"]);
                        objoff.RemainingDays = DBNull.Value.Equals(reader["RemainingDays"]) ? 0 : Convert.ToDecimal(reader["RemainingDays"]);
                        objoff.EmployeeLeaveId = DBNull.Value.Equals(reader["EmployeeLeaveID"]) ? 0 : Convert.ToInt32(reader["EmployeeLeaveID"]);
                        LeaveList.Add(objoff);
                    }
                    reader.Close();
                    return LeaveList;
                }
            }

        }

        public List<Employee> GetAsset(Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Employee objoff = null;
            List<Employee> AssetList = new List<Employee>();
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeAsset", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objoff = new Employee();
                        objoff.EmployeeAssetId = DBNull.Value.Equals(reader["EmployeeAssetId"]) ? 0 : Convert.ToInt64(reader["EmployeeAssetId"]);
                        objoff.AssetName = DBNull.Value.Equals(reader["AssetName"]) ? "" : Convert.ToString(reader["AssetName"]);
                        objoff.SerialNo = DBNull.Value.Equals(reader["SerialNo"]) ? "" : Convert.ToString(reader["SerialNo"]);
                        objoff.AssetDate = DBNull.Value.Equals(reader["AssetDate"]) ? "" : Convert.ToString(reader["AssetDate"]);
                        AssetList.Add(objoff);
                    }
                    reader.Close();
                    return AssetList;
                }
            }
        }

        public User GetUser(Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            User objoff = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("sp_EmployeeUser", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objoff = new User();
                        objoff.UserName = DBNull.Value.Equals(reader["UserName"]) ? string.Empty : Convert.ToString(reader["UserName"]);
                        objoff.RoleID = DBNull.Value.Equals(reader["RoleId"]) ? 0 : Convert.ToInt64(reader["RoleId"]);
                        string password = DBNull.Value.Equals(reader["Password"]) ? string.Empty : Convert.ToString(reader["Password"]);
                        objoff.Password = DataFactory.GetDecryptedData(password);
                    }
                    reader.Close();
                    return objoff;
                }
            }

        }

        public string UpdatePersonal(Employee PersonalObj)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            string EmployeeId = string.Empty;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeePersonal", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", "0"));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", PersonalObj.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeCode", PersonalObj.EmployeeCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("FirstName", PersonalObj.FirstName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LastName", PersonalObj.LastName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DateOfBirth", PersonalObj.DateOfBirth));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Age", PersonalObj.Age));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BloodGroupFlag", PersonalObj.BloodGroupFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("GenderFlag", PersonalObj.GenderFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("MaritalStatus", PersonalObj.MaritalStatus));
                    cmd.Parameters.Add(DataFactory.CreateParameter("MobileNo", PersonalObj.MobileNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Religion", PersonalObj.Religion));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Nationality", PersonalObj.Nationality));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmailID", PersonalObj.EmailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LanguageKnown", PersonalObj.LanguageKnown));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Address", PersonalObj.Address));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmergencyContact", PersonalObj.EmergencyContact));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortTypeFlag", PersonalObj.PassPortTypeFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortNo", PersonalObj.PassPortNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortIssuePlace", PersonalObj.PassPortIssuePlace));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortIssueCountry", PersonalObj.PassPortIssueCountry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortDateIssue", PersonalObj.PassPortDateIssue));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PassPortDateExpiry", PersonalObj.PassPortDateExpiry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaTypeFlag", PersonalObj.VisaTypeFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaNo", PersonalObj.VisaNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaDateIssue", PersonalObj.VisaDateIssue));
                    cmd.Parameters.Add(DataFactory.CreateParameter("VisaDateExpiry", PersonalObj.VisaDateExpiry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PanNo", PersonalObj.PanNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceTypeFlag", PersonalObj.DriveLiceTypeFlag));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceNo", PersonalObj.DriveLiceNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceDateIssue", PersonalObj.DriveLiceDateIssue));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DriveLiceDateExpiry", PersonalObj.DriveLiceDateExpiry));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", PersonalObj.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordsAffected = cmd.ExecuteNonQuery();
                    EmployeeId = param.Value.ToString();
                }
                if (RecordsAffected > 0)
                    return EmployeeId;
                else
                    return EmployeeId;

            }
        }
      
        public string UpdateOfficial(Employee OfficialObj)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_CreateEmployeeOfficial", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", "0"));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeID", OfficialObj.EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BranchId", OfficialObj.BranchId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DepartmentId", OfficialObj.DepartmentId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DesignationId", OfficialObj.DesignationId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CategoryId", OfficialObj.CategoryId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ReportingManagerId", OfficialObj.ReportingManagerId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("DateOfJoining", OfficialObj.DateOfJoining));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OfficialMailId", OfficialObj.OfficialMailId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProbationaryPeriod", OfficialObj.ProbationaryPeriod));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", OfficialObj.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", OfficialObj.CreatedBy));
                
                    RecordsAffected = cmd.ExecuteNonQuery();
                }
                if (RecordsAffected > 0)
                    return Convert.ToString(OfficialObj.EmployeeId);
                else
                    return Convert.ToString(OfficialObj.EmployeeId);

            }
        }

        public string AutoCode()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            string EmpCode = string.Empty;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_EmpCode", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        EmpCode = DBNull.Value.Equals(reader["EmpCode"]) ? string.Empty : Convert.ToString(reader["EmpCode"]);
                    }
                    reader.Close();
                }
                return EmpCode;
            }
        }
        public List<Employee> LeaveUpdated(int EmployeeId, int leavetypeID, int Days, decimal RemainingDays, int EmployeeLeaveId)
        {
            
            string m = "";
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            string EmpCode = string.Empty;
            List<Employee> LeaveList = new List<Employee>();
            try
            {
                using (conn = DataFactory.CreateConnection())
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("SP_LEAVEUPDATE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@LeaveTypeId", leavetypeID));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@days", Days));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeLeaveId", EmployeeLeaveId));
                        //cmd.Parameters.Add(DataFactory.CreateParameter("LTypeId", leavetypeID));
                        //cmd.Parameters.Add(DataFactory.CreateParameter("Days", Days));
                        //cmd.Parameters.Add(DataFactory.CreateParameter("RemainingDays", RemainingDays));
                        RecordsAffected = cmd.ExecuteNonQuery();
                    }
                }


                if (RecordsAffected > 0)
                    return LeaveList;
                else
                    return LeaveList;
                 

            }
            catch (Exception ex)
            {
         
                 m = ex.Message.ToString();
                
            }
            
            return null; 

        }
        public List<Employee> QualificationUpdated(string qualification, string medium, string university, string percentage, string year, string certificateno, int EmployeeId,int EmployeeQualificationId)
        {

            string m = "";
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            string EmpCode = string.Empty;
            List<Employee> LeaveList = new List<Employee>();
            try
            {
                using (conn = DataFactory.CreateConnection())
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("SP_QUALIFICATIONUPDATE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPLOYEEID", EmployeeId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPLOYEEQUALIFICATIONID",EmployeeQualificationId ));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@PERCENTAGE", percentage));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@YEAROFPASSOUT", year));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@QUALIFICATION", qualification));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@MEDIUMOFINSTRUCTION", medium));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@CERTIFICATENO", certificateno));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@UNIVERSITYNAME", university));
                        RecordsAffected = cmd.ExecuteNonQuery();
                    }
                }


                if (RecordsAffected > 0)
                    return LeaveList;
                else
                    return LeaveList;


            }
            catch (Exception ex)
            {

                m = ex.Message.ToString();

            }

            return null;

        }
        public List<Employee> ExperienceUpdated(string ON, string WB, string WA, string FP, string TP, string RM, string CN, int EmployeeId, int EmployeeExperienceId)
        {

            string m = "";
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            string EmpCode = string.Empty;
            List<Employee> LeaveList = new List<Employee>();
            try
            {
                using (conn = DataFactory.CreateConnection())
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("SP_EXPERIENCEUPDATE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPLOYEEID", EmployeeId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPLOYEEEXPERIENCEID", EmployeeExperienceId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@ORGANIZATIONNAME", ON));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@WEBSITE", WB));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@WORKEDAS", WA));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPFROM", FP));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPTO", TP));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@REFMGR", RM));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@REFCON", CN));
                        RecordsAffected = cmd.ExecuteNonQuery();
                    }
                }


                if (RecordsAffected > 0)
                    return LeaveList;
                else
                    return LeaveList;


            }
            catch (Exception ex)
            {

                m = ex.Message.ToString();

            }

            return null;

        }
        public List<Employee> AssetUpdated(string AN, string AGD, string SN, int EmployeeId, int EmployeeAssetId)
        {

            string m = "";
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            string EmpCode = string.Empty;
            List<Employee> LeaveList = new List<Employee>();
            try
            {
                using (conn = DataFactory.CreateConnection())
                {
                    conn.Open();
                    cmd = conn.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("SP_ASSETUPDATE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPLOYEEID", EmployeeId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@EMPLOYEEASSETID", EmployeeAssetId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@ASSETNAME", AN));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@AGD", AGD));
                        cmd.Parameters.Add(DataFactory.CreateParameter("@SN", SN));
                        RecordsAffected = cmd.ExecuteNonQuery();
                    }
                }


                if (RecordsAffected > 0)
                    return LeaveList;
                else
                    return LeaveList;


            }
            catch (Exception ex)
            {

                m = ex.Message.ToString();

            }

            return null;

        }

    }

    }
 
