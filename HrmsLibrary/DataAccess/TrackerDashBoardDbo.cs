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
    public class TrackerDashBoardDbo
    {
        public List<DashBoard> MainGrid(Int64 ProjectId, int Date, Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            Int64 TotalRecords = 0;
            List<DashBoard> TrackerDashBoardList = new List<DashBoard>();
            DashBoard objTrackerDashBoard = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_TrackerDashBoardMain", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProjectId", ProjectId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Date", Date));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                        while (reader.Read())
                        {
                            objTrackerDashBoard = new DashBoard();
                            objTrackerDashBoard.ProjectName = Convert.ToString(reader["ProjectName"]);
                            objTrackerDashBoard.AssignedHours = Convert.ToInt16(reader["AssignedHours"]);
                            objTrackerDashBoard.ActiveHours = DBNull.Value.Equals(reader["ActiveHours"]) ? 0 : Convert.ToInt16(reader["ActiveHours"]);
                            objTrackerDashBoard.CompletedHours = DBNull.Value.Equals(reader["CompletedHours"]) ? 0 : Convert.ToInt16(reader["CompletedHours"]);
                            objTrackerDashBoard.PendingHours = DBNull.Value.Equals(reader["PendingHours"]) ? 0 : Convert.ToInt16(reader["PendingHours"]);
                            objTrackerDashBoard.EmployeeName = DBNull.Value.Equals(reader["EmployeeName"]) ? "All" : Convert.ToString(reader["EmployeeName"]);
                            objTrackerDashBoard.TotalRecords = TotalRecords;
                            TrackerDashBoardList.Add(objTrackerDashBoard);
                        }
                    reader.Close();
                    return TrackerDashBoardList;
                }
            }
        }

        public DashBoard Count(Int64 ProjectId, int Date, Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            DashBoard objTrackerDashBoard = new DashBoard();
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_TrackerDashBoardMainCount", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProjectId", ProjectId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Date", Date));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();
                    
                    while (reader.Read())
                    {
                        objTrackerDashBoard.AssignedHours = DBNull.Value.Equals(reader["AssignedHours"]) ? 0 : Convert.ToInt32(reader["AssignedHours"]);
                        objTrackerDashBoard.ActiveHours = DBNull.Value.Equals(reader["ActiveHours"]) ? 0 : Convert.ToInt32(reader["ActiveHours"]);
                        objTrackerDashBoard.CompletedHours = DBNull.Value.Equals(reader["CompletedHours"]) ? 0 : Convert.ToInt32(reader["CompletedHours"]);
                        objTrackerDashBoard.PendingHours = DBNull.Value.Equals(reader["PendingHours"]) ? 0 : Convert.ToInt32(reader["PendingHours"]);
                    }
                    reader.Close();
                    return objTrackerDashBoard;
                }
            }
        }


        public List<ChartObj> Chart(Int64 EmployeeId)
        {
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader;
            List<ChartObj> listchart = new List<ChartObj>();
            ChartObj objTrackerDashBoard = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("Sp_TrackerDashBoardMainChart", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmployeeId", EmployeeId));
                    reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        objTrackerDashBoard = new ChartObj();
                        objTrackerDashBoard.Name = DBNull.Value.Equals(reader["Name"]) ? "" : Convert.ToString(reader["Name"]);
                        objTrackerDashBoard.Count = DBNull.Value.Equals(reader["Count"]) ? 0 : Convert.ToInt32(reader["Count"]);
                        listchart.Add(objTrackerDashBoard);
                    }
                    reader.Close();
                    return listchart;
                }
            }
        }

    }
}
