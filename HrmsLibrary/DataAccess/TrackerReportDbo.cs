using HrmsLibrary.Common;
using HrmsObjects.Details;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using ClosedXML;
using ClosedXML.Excel;
using System.IO;
using System.Configuration;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using System.Threading.Tasks;

namespace HrmsLibrary.DataAccess
{
    [Serializable]
    public class TrackerReportDbo
    {
        public List<IssueEntry> MainGrid(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 UserID, string fromdate, string todate, Int64 status, Int64 txtAssignedId, Int64 txtProjectId, Int64 totxtTaskId)
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
                using (cmd = DataFactory.CreateCommand("Sp_IssueReportMain", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowperPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@UserID", UserID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@fromdate", fromdate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@todate", todate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@status", status));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@txtAssignedId", txtAssignedId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@txtProjectId", txtProjectId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@totxtTaskId", totxtTaskId));
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
                            objissue.IssueTime = DBNull.Value.Equals(reader["IssueTime"]) ? 0: Convert.ToDecimal(reader["IssueTime"]);
                            objissue.StatusFlag = DBNull.Value.Equals(reader["StatusFlag"]) ? 0 : Convert.ToInt16(reader["StatusFlag"]);
                            objissue.IssueDescription = DBNull.Value.Equals(reader["IssueDescription"]) ? string.Empty : Convert.ToString(reader["IssueDescription"]);
                            objissue.AssignedByName = DBNull.Value.Equals(reader["AssignedByName"]) ? string.Empty : Convert.ToString(reader["AssignedByName"]);
                            objissue.AssignedById = DBNull.Value.Equals(reader["AssignedById"]) ? 0 : Convert.ToInt64(reader["AssignedById"]);
                            objissue.ModuleName = DBNull.Value.Equals(reader["ModuleTypeName"]) ? string.Empty : Convert.ToString(reader["ModuleTypeName"]);
                            objissue.AssignedToName = DBNull.Value.Equals(reader["AssignedToName"]) ? string.Empty : Convert.ToString(reader["AssignedToName"]);
                            objissue.ProjectName = DBNull.Value.Equals(reader["ProductName"]) ? string.Empty : Convert.ToString(reader["ProductName"]);
                            objissue.StatusName = DBNull.Value.Equals(reader["StatusName"]) ? string.Empty : Convert.ToString(reader["StatusName"]);
                            objissue.ActualTime = DBNull.Value.Equals(reader["ActualTime"]) ? string.Empty : Convert.ToString(reader["ActualTime"]);
                            objissue.ResolvedDescription = DBNull.Value.Equals(reader["ResolvedDescription"]) ? string.Empty : Convert.ToString(reader["ResolvedDescription"]);
                            objissue.TotalRecords = TotalRecords;
                            issuelist.Add(objissue);
                        }
                    reader.Close();
                    return issuelist;


                }
            }
        }
        //-----------------------------------------------------------------------------
    //    public List<IssueEntry> ExportData(Int32 PageNo, Int32 RowperPage, String SearchText, Int64 UserID, string fromdate, string todate, Int64 status, Int64 txtAssignedId, Int64 txtProjectId, Int64 totxtTaskId)
    //    {
    //        IDbCommand cmd = null;
    //        IDbConnection con = null;
    //        IDataReader reader;
    //        Int64 TotalRecords = 0;
    //        List<IssueEntry> issuelist = new List<IssueEntry>();
    //        IssueEntry objissue = null;
    //        using (con = DataFactory.CreateConnection())
    //        {
    //            con.Open();
    //            using (cmd = DataFactory.CreateCommand("Sp_IssueReportMain", con))
    //            {
    //                cmd.CommandType = CommandType.StoredProcedure;
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowperPage));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@UserID", UserID));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@fromdate", fromdate));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@todate", todate));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@status", status));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@txtAssignedId", txtAssignedId));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@txtProjectId", txtProjectId));
    //                cmd.Parameters.Add(DataFactory.CreateParameter("@totxtTaskId", totxtTaskId));
    //                reader = cmd.ExecuteReader();
    //                while (reader.Read())
    //                {
    //                    TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
    //                }
    //                if (reader.NextResult())
    //                    while (reader.Read())
    //                    {
    //                        objissue = new IssueEntry();
    //                        objissue.IssueEntryID = Convert.ToInt64(reader["IssueEntryID"]);
    //                        objissue.ProjectId = Convert.ToInt64(reader["ProjectId"]);
    //                        objissue.ModuleId = Convert.ToInt64(reader["ModuleId"]);
    //                        objissue.AssignedToId = DBNull.Value.Equals(reader["AssignedToId"]) ? 0 : Convert.ToInt64(reader["AssignedToId"]);
    //                        objissue.AssignedToName = DBNull.Value.Equals(reader["AssignedToName"]) ? string.Empty : Convert.ToString(reader["AssignedToName"]);
    //                        objissue.IssueDate = DBNull.Value.Equals(reader["IssueDate"]) ? string.Empty : Convert.ToString(reader["IssueDate"]);
    //                        objissue.IssueTime = DBNull.Value.Equals(reader["IssueTime"]) ? 0 : Convert.ToInt16(reader["IssueTime"]);
    //                        objissue.StatusFlag = DBNull.Value.Equals(reader["StatusFlag"]) ? 0 : Convert.ToInt16(reader["StatusFlag"]);
    //                        objissue.IssueDescription = DBNull.Value.Equals(reader["IssueDescription"]) ? string.Empty : Convert.ToString(reader["IssueDescription"]);
    //                        objissue.AssignedByName = DBNull.Value.Equals(reader["AssignedByName"]) ? string.Empty : Convert.ToString(reader["AssignedByName"]);
    //                        objissue.AssignedById = DBNull.Value.Equals(reader["AssignedById"]) ? 0 : Convert.ToInt64(reader["AssignedById"]);
    //                        objissue.ModuleName = DBNull.Value.Equals(reader["ModuleTypeName"]) ? string.Empty : Convert.ToString(reader["ModuleTypeName"]);
    //                        objissue.AssignedToName = DBNull.Value.Equals(reader["AssignedToName"]) ? string.Empty : Convert.ToString(reader["AssignedToName"]);
    //                        objissue.ProjectName = DBNull.Value.Equals(reader["ProductName"]) ? string.Empty : Convert.ToString(reader["ProductName"]);
    //                        objissue.StatusName = DBNull.Value.Equals(reader["StatusName"]) ? string.Empty : Convert.ToString(reader["StatusName"]);

    //                        objissue.ActualTime = DBNull.Value.Equals(reader["ActualTime"]) ? 0 : Convert.ToInt16(reader["ActualTime"]);
    //                        objissue.ResolvedDescription = DBNull.Value.Equals(reader["ResolvedDescription"]) ? string.Empty : Convert.ToString(reader["ResolvedDescription"]);
    //                        objissue.TotalRecords = TotalRecords;
    //                        issuelist.Add(objissue);
    //                    }
    //                reader.Close();

    //                try
    //                {
    //                    Microsoft.Office.Interop.Excel.Application xlApp;
    //                    Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
    //                    Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;
    //                    object misValue = Missing.Value;
    //                    xlApp = new Microsoft.Office.Interop.Excel.Application();
    //                    xlApp.Visible = false;
    //                    xlWorkBook = (Microsoft.Office.Interop.Excel.Workbook)(xlApp.Workbooks.Add(Missing.Value));
    //                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.ActiveSheet;
    //                    string data = null;

    //                    int k = 0;
    //                    for (int i = 0; i < reader.FieldCount; i++)
    //                    {
    //                        data = (reader.GetName(i));
    //                        xlWorkSheet.Cells[1, k + 1] = data;
    //                        k++;
    //                    }
    //                    char lastColumn = (char)(65 + reader.FieldCount - 1);
    //                    xlWorkSheet.get_Range("A1", lastColumn + "1").Font.Bold = true;
    //                    xlWorkSheet.get_Range("A1", lastColumn + "1").VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
    //                    reader.Close();
    //                    System.Data.DataTable dt = new System.Data.DataTable();
    //                    SqlDataAdapter dscmd = new SqlDataAdapter(cmd);
    //                    DataSet ds = new DataSet();
    //                    ds.Fill(dt);
                        
    //                    issuelist = dscmd.AsEnumerable().Select(r => r.Field<string>("ColumnName")).ToList();
    //                    for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
    //                    {
    //                        var newj = 0;
    //                        for (int j = 0; j <= ds.Tables[0].Columns.Count - 1; j++)
    //                        {
    //                            data = ds.Tables[0].Rows[i].ItemArray[j].ToString();

    //                            xlWorkSheet.Cells[i + 2, newj + 1] = data;
    //                            newj++;
    //                        }
    //                    }
    //                    xlWorkBook.Close(true, misValue, misValue);
    //                    xlApp.Quit();
    //                    releaseObject(xlWorkSheet);
    //                    releaseObject(xlWorkBook);
    //                    releaseObject(xlApp);
    //                }
    //                catch (System.Exception Ex)
    //                {
    //                    string m = Ex.Message;

    //                }

    //            }

    //        }
    //        return RedirectToAction("TrackerReport", "ExportData");
    //    }

    //}
    //   private void releaseObject(object obj)
    //    {
    //        try
    //        {
    //            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
    //            obj = null;
    //        }
    //        catch
    //        {
    //            obj = null;
    //        }
    //        finally
    //        {
    //            GC.Collect();
    //        }
    //    }
    
        
        
        //------------------------------------------------------------------------------
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
                using (cmd = DataFactory.CreateCommand("Sp_ListProjectReports", conn))
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
                using (cmd = DataFactory.CreateCommand("Sp_ListEmployeeReports", conn))
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
        public List<Product> TaskList()
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            List<Product> objModuleList = new List<Product>();
            Product ModuleList = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ListModuleMasterReports", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        ModuleList = new Product();
                        ModuleList.ModuleMasterName = DBNull.Value.Equals(reader["ModuleTypeName"]) ? string.Empty : Convert.ToString(reader["ModuleTypeName"]);
                        ModuleList.ModuleMasterID = DBNull.Value.Equals(reader["ModuleTypeId"]) ? 0 : Convert.ToInt32(reader["ModuleTypeId"]);
                        objModuleList.Add(ModuleList);
                    }
                    reader.Close();
                }
                return objModuleList;
            }
        }
        public List<Employee> GetEmployeeContacts(Int32 PageNo, Int32 RowperPage, String SearchText)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            List<Employee> issuelist = new List<Employee>();
            Employee objissue = null;
            Int64 TotalRecords = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_EmployeeContactDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowperPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                        while (reader.Read())
                        {
                            objissue = new Employee();
                            objissue.EmployeeId = Convert.ToInt64(reader["Sno"]);
                            objissue.EmployeeName = DBNull.Value.Equals(reader["EmployeeName"]) ? string.Empty : Convert.ToString(reader["EmployeeName"]);
                            objissue.DesignationName = DBNull.Value.Equals(reader["Designation"]) ? string.Empty : Convert.ToString(reader["Designation"]);
                            objissue.Address = DBNull.Value.Equals(reader["Address"]) ? string.Empty : Convert.ToString(reader["Address"]);
                            objissue.MobileNo = DBNull.Value.Equals(reader["MobileNo"]) ? string.Empty : Convert.ToString(reader["MobileNo"]);
                            objissue.OfficialMailId = DBNull.Value.Equals(reader["OfficialMailId"]) ? string.Empty : Convert.ToString(reader["OfficialMailId"]);
                            objissue.EmergencyContact = DBNull.Value.Equals(reader["EmergencyContact"]) ? string.Empty : Convert.ToString(reader["EmergencyContact"]);
                            objissue.TotalRecords = TotalRecords;
                            issuelist.Add(objissue);
                        }
                }
            }
            reader.Close();
            return issuelist;
        }


    }
}

