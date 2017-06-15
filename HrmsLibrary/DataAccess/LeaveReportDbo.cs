using HrmsLibrary.Common;
using HrmsObjects.Master;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace HrmsLibrary.DataAccess
{
    class LeaveReportDbo
    {
        public List<LeaveApprove> FullListTable(int PageNo, int RowPerPage, string SearchText)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int TotalRecord = 0;
            LeaveApprove objLeaveApprove;
            List<LeaveApprove> objlist = new List<LeaveApprove>();

            IDataReader reader;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_LeaveFullList", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecord = Convert.ToInt32(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {

                        while (reader.Read())
                        {
                            objLeaveApprove = new LeaveApprove();
                            objLeaveApprove.empCode = Convert.ToString(reader["EmployeeCode"]);
                            objLeaveApprove.empName = Convert.ToString(reader["UserName"]);
                            objLeaveApprove.fromDate = Convert.ToString(reader["LeavefromDate"]);
                            objLeaveApprove.toDate = Convert.ToString(reader["LeavetoDate"]);
                            objLeaveApprove.days = Convert.ToDecimal(reader["days"]);
                            objLeaveApprove.leaveTpye = Convert.ToString(reader["LeaveType"]);
                            objLeaveApprove.RemainingDays = Convert.ToDecimal(reader["RemainingDays"]);
                            //objLeave.reason = Convert.ToString(reader["reason"]);



                            objLeaveApprove.totalRecords = TotalRecord;

                            objlist.Add(objLeaveApprove);
                        }

                    }
                    reader.Close();
                    return objlist;
                }
            }

        }
    }
}
