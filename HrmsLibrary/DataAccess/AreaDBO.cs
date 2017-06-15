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
    public class AreaDBO
    {
        public List<Area> Arealist(int PageNo, int RowPerPage, string SearchText)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int TotalRecord = 0;
            Area objarea;
            List<Area> objlist = new List<Area>();
            IDataReader reader;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Areagrid", con))
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
                            objarea = new Area();
                            objarea.AreaID = DBNull.Value.Equals(reader["AreaID"]) ? 0 : Convert.ToInt64(reader["AreaID"]);
                            objarea.AreaName = Convert.ToString(reader["AreaName"]);
                            objarea.CityName = Convert.ToString(reader["CityName"]);
                            objarea.StateName = Convert.ToString(reader["StateName"]);
                            objarea.CountryName = Convert.ToString(reader["CountryName"]);


                            objarea.TotalRecords = TotalRecord;

                            objlist.Add(objarea);
                        }

                    }
                    reader.Close();
                    return objlist;
                }
            }
        }

        public List<Area> autoList(string SEARCHTEXT)
        {
            List<Area> objarea = new List<Area>();
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

                        Area obj = new Area();
                        obj.StateName = Convert.ToString(reader["ParameterName"]);
                        objarea.Add(obj);




                    }
                    return objarea;

                }
            }
        }

        public string insert(Area objint)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected;
            //Int64 EmpolyeeId = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Area_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AreaID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AreaName", objint.AreaName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CityName", objint.CityName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("StateName", objint.StateName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CountryName", objint.CountryName));
                 }
                IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                param.DbType = DbType.Int64;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                RecordsAffected = cmd.ExecuteNonQuery();

                objint.AreaID = Convert.ToInt16(param.Value);
                return Convert.ToString(param.Value);

            }

        }

        public Boolean Updated(Area objint)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            int RecordsAffected = 0;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Area_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", false));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AreaID", objint.AreaID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AreaName", objint.AreaName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CityName", objint.CityName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("StateName", objint.StateName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CountryName", objint.CountryName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Creadtedby", objint.Creadtedby));
                }
                IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                param.DbType = DbType.Int64;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);
                RecordsAffected = cmd.ExecuteNonQuery();

                if (RecordsAffected == -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
