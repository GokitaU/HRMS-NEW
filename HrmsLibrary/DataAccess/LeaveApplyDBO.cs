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
    public class LeaveApplyDBO
    {
        public List<LeaveForm> Leavelist(int PageNo, int RowPerPage, string SearchText, int leaveEmployeeID)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int TotalRecord = 0;
            LeaveForm objLeave;
            List<LeaveForm> objlist = new List<LeaveForm>();

            IDataReader reader;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ApplyFormGrid", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@leaveEmployeeid", leaveEmployeeID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecord = Convert.ToInt32(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {

                        while (reader.Read())
                        {
                            objLeave = new LeaveForm();
                            objLeave.empCode = Convert.ToString(reader["empCode"]);
                            objLeave.empName = Convert.ToString(reader["empName"]);
                            objLeave.fromDate = Convert.ToString(reader["fromDate"]);
                            objLeave.toDate = Convert.ToString(reader["toDate"]);
                            objLeave.days = Convert.ToDecimal(reader["days"]);
                            objLeave.leaveTpye = Convert.ToString(reader["LeaveType"]);
                            objLeave.LeaveStatus = Convert.ToString(reader["LeaveStatus"]);

                            //objLeave.reason = Convert.ToString(reader["reason"]);



                            objLeave.totalRecords = TotalRecord;

                            objlist.Add(objLeave);
                        }

                    }
                    reader.Close();
                    return objlist;
                }
            }
        }
        //Search text box
        public List<LeaveForm> autoList(string SEARCHTEXT)
        {
            List<LeaveForm> objlist = new List<LeaveForm>();
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ParameterWiseStateList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SEARCHTEXT));
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {

                        LeaveForm obj = new LeaveForm();
                        obj.stateName = Convert.ToString(reader["ParameterName"]);
                        objlist.Add(obj);




                    }
                    return objlist;

                }
            }
        }
        public string insert(LeaveForm objint)
        {

            IDbConnection conn = null;
            IDbCommand cmd = null;
            string i;
            i = "success";
            int RecordsAffected;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Applyform_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("leaveEmployeeID", objint.ID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("empCode", objint.empCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("empName", objint.empName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("fromDate", objint.fromDate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("toDate", objint.toDate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Days", objint.days));
                    cmd.Parameters.Add(DataFactory.CreateParameter("leaveType", objint.leaveTpye));
                    cmd.Parameters.Add(DataFactory.CreateParameter("reason", objint.reason));
                    cmd.Parameters.Add(DataFactory.CreateParameter("timPeriodId", objint.timePeriod));
                    cmd.Parameters.Add(DataFactory.CreateParameter("leaveMgmtId", objint.ReportingManagerId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("LeaveStatus", objint.LeaveStatus));
                }
                RecordsAffected = cmd.ExecuteNonQuery();

                conn.Close();
                return i;
            }

        }
        //------------------------------------------------------------------------------
        public List<LeaveForm> RemainingDaysAvailable(int PageNo, int RowPerPage, string SearchText, int EmployeeID)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int TotalRecord = 0;
            LeaveForm objLeave;
            List<LeaveForm> objlist = new List<LeaveForm>();

            IDataReader reader;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("SP_RemainingDays", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeID));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecord = Convert.ToInt32(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {

                        while (reader.Read())
                        {
                            objLeave = new LeaveForm();
                            objLeave.leaveTpye = Convert.ToString(reader["LeaveType"]);
                            objLeave.RemainingDays = Convert.ToDecimal(reader["RemainingDays"]);
                            objLeave.totalRecords = TotalRecord;
                            objlist.Add(objLeave);
                        }

                    }
                    reader.Close();
                    return objlist;
                }
            }
        }
    }
}
    //------------------------------------------------------------------------------
    //public string Updated(LeaveForm objint1)
    //{
    //    IDbConnection conn = null;
    //    IDbCommand cmd = null;
    //    string i;
    //    i = "success";
    //    int RecordsAffected = 0;
    //    using (conn = DataFactory.CreateConnection())
    //    {
    //        conn.Open();
    //        cmd = conn.CreateCommand();
    //        using (cmd = DataFactory.CreateCommand("sp_Applyform_Update", conn))
    //        {
    //            cmd.CommandType = CommandType.StoredProcedure;
    //            cmd.Parameters.Add(DataFactory.CreateParameter("empCode", objint1.empCode));
    //            cmd.Parameters.Add(DataFactory.CreateParameter("empName", objint1.empName));
    //            cmd.Parameters.Add(DataFactory.CreateParameter("fromDate", objint1.fromDate));
    //            cmd.Parameters.Add(DataFactory.CreateParameter("toDate", objint1.toDate));
    //            cmd.Parameters.Add(DataFactory.CreateParameter("Days", objint1.days));
    //            cmd.Parameters.Add(DataFactory.CreateParameter("leaveType", objint1.leaveTpye));
    //            cmd.Parameters.Add(DataFactory.CreateParameter("reason", objint1.reason));
    //            cmd.Parameters.Add(DataFactory.CreateParameter("timPeriodId", objint1.timePeriod));

//        }
//        RecordsAffected = cmd.ExecuteNonQuery();

//        conn.Close();
//        return i;

//    }


