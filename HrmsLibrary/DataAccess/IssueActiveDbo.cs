using HrmsLibrary.Common;
using HrmsObjects.Details;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.DataAccess
{
    [Serializable]
    public class IssueActiveDbo
    {
        public List<IssueEntry> ProjectList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<IssueEntry> objProjectList = new List<IssueEntry>();
            IssueEntry ProjectList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListProject", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ProjectList = new IssueEntry();
                        ProjectList.ProjectName = DBNull.Value.Equals(reader["ProductName"]) ? string.Empty : Convert.ToString(reader["ProductName"]);
                        ProjectList.ProjectId = DBNull.Value.Equals(reader["ProductID"]) ? 0 : Convert.ToInt32(reader["ProductID"]);
                        objProjectList.Add(ProjectList);
                    }
                    reader.Close();
                }
                return objProjectList;
            }
        }


        //public string Issuesave(IssueEntry IssueObj)
        //{
        //    IDbConnection con = null;
        //    IDbCommand cmd = null;
        //    int RecordAffected = 0;
        //    using (con = DataFactory.CreateConnection())
        //    {
        //        con.Open();
        //        cmd = con.CreateCommand();
        //        using (cmd = DataFactory.CreateCommand("sp_CreateIssueEntry", con))
        //        {
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("IssueEntryID", DBNull.Value));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("ProjectId", IssueObj.ProjectId));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("ModuleId", IssueObj.ModuleId));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("AssignedToId", IssueObj.AssignedToId));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", IssueObj.CreatedBy));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("AssignedToName", IssueObj.AssignedToName));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("IssueDate", IssueObj.IssueDate));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("IssueTime", IssueObj.IssueTime));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("StatusFlag", IssueObj.StatusFlag));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("IssueDescription", IssueObj.IssueDescription));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("AssignedByName", IssueObj.AssignedByName));
        //            cmd.Parameters.Add(DataFactory.CreateParameter("AssignedById", IssueObj.AssignedById));
        //            IDbDataParameter param = DataFactory.CreateParameter("@@Guid", DBNull.Value);
        //            param.DbType = DbType.Int64;
        //            param.Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add(param);
        //            RecordAffected = cmd.ExecuteNonQuery();
        //            IssueObj.IssueEntryID = Convert.ToInt64(param.Value);
        //        }
        //    }
        //    if (RecordAffected > 0)
        //        return Convert.ToString(IssueObj.IssueEntryID);
        //    else
        //        return "error";
        //}

        public string IssueUpdate(IssueEntry IssueObj)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            try
            {
                using (con = DataFactory.CreateConnection())
                {
                    con.Open();
                    cmd = con.CreateCommand();
                    using (cmd = DataFactory.CreateCommand("sp_CreateIssueEntry", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", "0"));
                        cmd.Parameters.Add(DataFactory.CreateParameter("IssueEntryID", IssueObj.IssueEntryID));
                        cmd.Parameters.Add(DataFactory.CreateParameter("StatusFlag", IssueObj.StatusFlag));
                        cmd.Parameters.Add(DataFactory.CreateParameter("ProjectId", IssueObj.ProjectId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("ModuleId", IssueObj.ModuleId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("AssignedById", IssueObj.AssignedById));
                        cmd.Parameters.Add(DataFactory.CreateParameter("AssignedToId", IssueObj.AssignedToId));
                        cmd.Parameters.Add(DataFactory.CreateParameter("IssueDate", IssueObj.IssueDate));
                        cmd.Parameters.Add(DataFactory.CreateParameter("IssueTime", IssueObj.IssueTime));
                        cmd.Parameters.Add(DataFactory.CreateParameter("AssignedToName", IssueObj.AssignedToName));
                        cmd.Parameters.Add(DataFactory.CreateParameter("AssignedByName", IssueObj.AssignedByName));
                        cmd.Parameters.Add(DataFactory.CreateParameter("IssueDescription", IssueObj.IssueDescription));
                        
                        // cmd.Parameters.Add(DataFactory.CreateParameter("StatusFlag", IssueObj.ProjectName));
                        cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", IssueObj.CreatedBy));
                        cmd.Parameters.Add(DataFactory.CreateParameter("IssueClosedDate", IssueObj.IssueClosedDate));
                        cmd.Parameters.Add(DataFactory.CreateParameter("ActualTime", IssueObj.ActualTime));
                        cmd.Parameters.Add(DataFactory.CreateParameter("ResolvedDescription", IssueObj.ResolvedDescription));
                        IDbDataParameter param = DataFactory.CreateParameter("@@Guid", DBNull.Value);
                        param.DbType = DbType.Int64;
                        param.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(param);
                        RecordAffected = cmd.ExecuteNonQuery();
                    }
                }
                if (RecordAffected > 0)
                    return Convert.ToString(IssueObj.IssueEntryID);
                else
                    return "error";
            }
            catch(Exception Ex)
            {
                string m = Ex.Message;
            }
            return null;
        }


        public List<IssueEntry> MainGrid(Int32 PageNo, Int32 RowsPerPage, String SearchText, Int64 UserID)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Int64 TotalRecords = 0;
            List<IssueEntry> issuelist = new List<IssueEntry>();
            IssueEntry objissue = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_IssueEntryActiveMain", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowsPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserID", UserID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                        while (reader.Read())
                        {
                            objissue = new IssueEntry();
                            objissue.IssueEntryID = Convert.ToInt64(reader["IssueEntryID"]);
                            objissue.ProjectId = Convert.ToInt64(reader["ProjectId"]);
                            objissue.ModuleId = Convert.ToInt64(reader["ModuleId"]);
                            objissue.AssignedToId = DBNull.Value.Equals(reader["AssignedToId"]) ? 0 : Convert.ToInt64(reader["AssignedToId"]);
                            objissue.AssignedToName = DBNull.Value.Equals(reader["AssignedToName"]) ? string.Empty : Convert.ToString(reader["AssignedToName"]);
                            objissue.IssueDate = DBNull.Value.Equals(reader["IssueDate"]) ? string.Empty : Convert.ToString(reader["IssueDate"]);
                            objissue.IssueTime = DBNull.Value.Equals(reader["IssueTime"]) ? 0 : Convert.ToDecimal(reader["IssueTime"]);
                            objissue.StatusFlag = DBNull.Value.Equals(reader["StatusFlag"]) ? 0 : Convert.ToInt16(reader["StatusFlag"]);
                            objissue.IssueDescription = DBNull.Value.Equals(reader["IssueDescription"]) ? string.Empty : Convert.ToString(reader["IssueDescription"]);
                            objissue.AssignedByName = DBNull.Value.Equals(reader["AssignedByName"]) ? string.Empty : Convert.ToString(reader["AssignedByName"]);
                            objissue.AssignedById = DBNull.Value.Equals(reader["AssignedById"]) ? 0 : Convert.ToInt64(reader["AssignedById"]);
                            objissue.ModuleName = DBNull.Value.Equals(reader["ModuleTypeName"]) ? string.Empty : Convert.ToString(reader["ModuleTypeName"]);
                            objissue.AssignedToName = DBNull.Value.Equals(reader["AssignedToName"]) ? string.Empty : Convert.ToString(reader["AssignedToName"]);
                            objissue.ProjectName = DBNull.Value.Equals(reader["ProductName"]) ? string.Empty : Convert.ToString(reader["ProductName"]);
                            objissue.IssueClosedDate= DBNull.Value.Equals(reader["IssueClosedDate"]) ? string.Empty : Convert.ToString(reader["IssueClosedDate"]);
                            objissue.ActualTime= DBNull.Value.Equals(reader["ActualTime"]) ? string.Empty : Convert.ToString(reader["ActualTime"]);
                            objissue.ResolvedDescription = DBNull.Value.Equals(reader["ResolvedDescription"]) ? string.Empty : Convert.ToString(reader["ResolvedDescription"]);
                            objissue.StatusName = DBNull.Value.Equals(reader["StatusName"]) ? string.Empty : Convert.ToString(reader["StatusName"]);
                            objissue.TotalRecords = TotalRecords;
                            issuelist.Add(objissue);
                        }
                    reader.Close();
                    return issuelist;
                }
            }
        }

        public List<IssueEntry> MainGridClosed(Int32 PageNo, Int32 RowsPerPage, String SearchText, Int64 UserId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Int64 TotalRecords = 0;
            List<IssueEntry> issuelist = new List<IssueEntry>();
            IssueEntry objissue = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_IssueEntryClosedMain", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowsPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserId", UserId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                        while (reader.Read())
                        {
                            objissue = new IssueEntry();
                            objissue.IssueEntryID = Convert.ToInt64(reader["IssueEntryID"]);
                            objissue.ProjectId = Convert.ToInt64(reader["ProjectId"]);
                            objissue.ModuleId = Convert.ToInt64(reader["ModuleId"]);
                            objissue.AssignedToId = DBNull.Value.Equals(reader["AssignedToId"]) ? 0 : Convert.ToInt64(reader["AssignedToId"]);
                            objissue.AssignedToName = DBNull.Value.Equals(reader["AssignedToName"]) ? string.Empty : Convert.ToString(reader["AssignedToName"]);
                            objissue.IssueDate = DBNull.Value.Equals(reader["IssueDate"]) ? string.Empty : Convert.ToString(reader["IssueDate"]);
                            objissue.IssueTime = DBNull.Value.Equals(reader["IssueTime"]) ? 0 : Convert.ToDecimal(reader["IssueTime"]);
                            objissue.StatusFlag = DBNull.Value.Equals(reader["StatusFlag"]) ? 0 : Convert.ToInt16(reader["StatusFlag"]);
                            objissue.IssueDescription = DBNull.Value.Equals(reader["IssueDescription"]) ? string.Empty : Convert.ToString(reader["IssueDescription"]);
                            objissue.AssignedByName = DBNull.Value.Equals(reader["AssignedByName"]) ? string.Empty : Convert.ToString(reader["AssignedByName"]);
                            objissue.AssignedById = DBNull.Value.Equals(reader["AssignedById"]) ? 0 : Convert.ToInt64(reader["AssignedById"]);
                            objissue.ModuleName = DBNull.Value.Equals(reader["ModuleTypeName"]) ? string.Empty : Convert.ToString(reader["ModuleTypeName"]);
                            objissue.AssignedToName = DBNull.Value.Equals(reader["AssignedToName"]) ? string.Empty : Convert.ToString(reader["AssignedToName"]);
                            objissue.ProjectName = DBNull.Value.Equals(reader["ProductName"]) ? string.Empty : Convert.ToString(reader["ProductName"]);
                            objissue.StatusName = DBNull.Value.Equals(reader["StatusName"]) ? string.Empty : Convert.ToString(reader["StatusName"]);
                            objissue.IssueClosedDate = DBNull.Value.Equals(reader["IssueClosedDate"]) ? string.Empty : Convert.ToString(reader["IssueClosedDate"]);
                            objissue.TotalRecords = TotalRecords;
                            issuelist.Add(objissue);
                        }
                    reader.Close();
                    return issuelist;
                }
            }
        }
    }
}
