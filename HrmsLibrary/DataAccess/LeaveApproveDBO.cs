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
    [Serializable]
    public class LeaveApproveDBO
    {
        public List<LeaveApprove> LeaveApprovelist(int PageNo, int RowPerPage, string SearchText, int leaveEmployeeID)
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
                using (cmd = DataFactory.CreateCommand("Sp_ApplyFormGrid1", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Employeeid", leaveEmployeeID));
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
                            objLeaveApprove.empCode = Convert.ToString(reader["empCode"]);
                            objLeaveApprove.empName = Convert.ToString(reader["empName"]);
                            objLeaveApprove.fromDate = Convert.ToString(reader["fromDate"]);
                            objLeaveApprove.toDate = Convert.ToString(reader["toDate"]);
                            objLeaveApprove.days = Convert.ToDecimal(reader["days"]);
                            objLeaveApprove.leaveTpye = Convert.ToString(reader["LeaveType"]);
                            objLeaveApprove.reason = Convert.ToString(reader["reason"]);
                            objLeaveApprove.ID = Convert.ToInt32(reader["Applyleaveid"]);
                            objLeaveApprove.leaveTpyeId = Convert.ToInt32(reader["leaveTypeid"]);
                            objLeaveApprove.ApproveId = Convert.ToInt32(reader["ApproveID"]);
                            objLeaveApprove.OfficialMailId= Convert.ToString(reader["OfficialMailId"]);
                            objLeaveApprove.EmployeeId = Convert.ToInt32(reader["leaveEmployeeID"]);
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
        //Search text box
        public List<LeaveApprove> autoList(string SEARCHTEXT)
        {
            List<LeaveApprove> objlist = new List<LeaveApprove>();
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

                        LeaveApprove obj = new LeaveApprove();
                        obj.stateName = Convert.ToString(reader["ParameterName"]);
                        objlist.Add(obj);

                    }
                    return objlist;

                }
            }
        }
        public List<LeaveApprove> Approval(int leaveEmployeeId, string fromdate, string todate, decimal days, int leavetypeid, int ApprovedId, string OfficialMailId, string empName,int EmployeeId)
        {
            //var conform = "Approved";
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            int DBResult = 0;
            LeaveApprove objLeaveApproval;
            List<LeaveApprove> objlist = new List<LeaveApprove>();
            //Int64 EmpolyeeId = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CheckLeaveEligibility", conn))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@LeaveEmpid", EmployeeId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@fromdate", fromdate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@toDate", todate));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@LeaveTypId", leavetypeid));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@Days", days));
                  //  cmd.ExecuteNonQuery();
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objLeaveApproval = new LeaveApprove();
                        DBResult = Convert.ToInt32(reader["result"]);

                    }
                }
                    reader.Close();
                    if (DBResult == 1)
                    {
                        using (cmd = DataFactory.CreateCommand("SP_LeaveFormUpdated", conn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(DataFactory.CreateParameter("@id", ApprovedId));
                            cmd.Parameters.Add(DataFactory.CreateParameter("@days", days));
                            //cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeID", leaveEmployeeId));
                            cmd.Parameters.Add(DataFactory.CreateParameter("@LeaveTypeId", leavetypeid));
                            cmd.Parameters.Add(DataFactory.CreateParameter("@EmployeeId", EmployeeId));
                            cmd.ExecuteNonQuery();
                            Acceptmail(OfficialMailId, empName,fromdate,todate,days);
                        }
                        
                     }
              

                conn.Close();
                    return objlist;
                }

            }
        public string Acceptmail(string OfficialMailId,string empName,string fromdate,string todate,decimal days)
        {
            string i="success";
            SmtpClient client = new SmtpClient();
            MailMessage msg = new MailMessage();
            NetworkCredential smtpCredential = new NetworkCredential("utiliplushrms@gmail.com", "Test@123");
            client.Host = "smtp.gmail.com";
            client.Port = 587; ;
            client.UseDefaultCredentials = false;
            client.Credentials = smtpCredential;
            client.EnableSsl = true;

            MailAddress from = new MailAddress("utiliplushrms@gmail.com");
            MailAddress to = new MailAddress(OfficialMailId);
            msg.Subject = "Leave Conformation Mail";
            var conform = "Approved";
            msg.Body = "Dear  " + empName + ","+Environment.NewLine + "Your Leave Application is " +"<b>"+conform+"</b>"+Environment.NewLine+Environment.NewLine +"FromDate  :"+fromdate+Environment.NewLine+"ToDate  :"   +todate+Environment.NewLine+"No of Days:   "   +days+Environment.NewLine+Environment.NewLine+" Applied On:"+ DateTime.Now+Environment.NewLine+ "This is System Generated Mail. Please Don't Reply This Mail!";
            msg.From = from;
            msg.To.Add(to);
           client.Send(msg);
            return i;
        }
        
        

        public List<LeaveApprove> leaveReject(int ApprovedId,string OfficialMailId,string empName)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            List<LeaveApprove> objlist = new List<LeaveApprove>();
            int DBResult = 2;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();


                if (DBResult == 2)
                {
                    using (cmd = DataFactory.CreateCommand("SP_LeaveFormReject", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(DataFactory.CreateParameter("@id", ApprovedId));
                        cmd.ExecuteNonQuery();
                        Rejectmail(OfficialMailId,empName);
                    }
                  
                }
                conn.Close();
                return objlist;
            }


        }
        public string Rejectmail(string OfficialMailId, string empName)
        {
            string i = "success";
            SmtpClient client = new SmtpClient();
            MailMessage msg = new MailMessage();
            NetworkCredential smtpCredential = new NetworkCredential("utiliplushrms@gmail.com", "Test@123");
            client.Host = "smtp.gmail.com";
            client.Port = 587; ;
            client.UseDefaultCredentials = false;
            client.Credentials = smtpCredential;
            client.EnableSsl = true;

            MailAddress from = new MailAddress("utiliplushrms@gmail.com");
            MailAddress to = new MailAddress(OfficialMailId);
            msg.Subject = "Leave Conformation Mail";
            var conform = "Rejected";
            msg.Body = "Dear  " + empName + "," + Environment.NewLine + "Your Leave Application is " + conform + Environment.NewLine + Environment.NewLine +" Applied On    :" + DateTime.Now + Environment.NewLine + "This is System Generated Mail. Please Don't Reply This Mail!";
            msg.From = from;
            msg.To.Add(to);
           client.Send(msg);
           return i;
        }
        }
    }

