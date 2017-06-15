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
    public class BranchDBops
    {
        public List<Branch> ListClientInfoMainPage(int PageNo, int RowsPerPage, string SearchText)
        {
            List<Branch> objclientInfoList = new List<Branch>();
            Branch objclient = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            int TotalRecords = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Branch_List", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowsPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt32(reader["TotalRecords"]);

                    }
                    if (reader.NextResult())
                    {

                        while (reader.Read())
                        {
                            objclient = new Branch();
                            objclient.BranchID = Convert.ToInt64(reader["BranchID"]);
                            objclient.BranchName = Convert.ToString(reader["BranchName"]);
                            objclient.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                            objclient.OrganizationCode = Convert.ToString(reader["OrganizationCode"]);
                            objclient.Orgid = Convert.ToInt64(reader["Orgid"]);
                            objclient.Address = DBNull.Value.Equals(reader["Address"]) ? string.Empty : Convert.ToString(reader["Address"]);
                            objclient.AreaID = Convert.ToInt64(reader["AreaID"]);
                            objclient.AreaName = DBNull.Value.Equals(reader["AreaName"]) ? string.Empty : Convert.ToString(reader["AreaName"]);
                            objclient.CityName = DBNull.Value.Equals(reader["CityName"]) ? string.Empty : Convert.ToString(reader["CityName"]);
                            objclient.StateName = DBNull.Value.Equals(reader["StateName"]) ? string.Empty : Convert.ToString(reader["StateName"]);
                            objclient.CountryName = DBNull.Value.Equals(reader["CountryName"]) ? string.Empty : Convert.ToString(reader["CountryName"]);
                            objclient.Phone = DBNull.Value.Equals(reader["PhoneNo"]) ? string.Empty : Convert.ToString(reader["PhoneNo"]);
                            objclient.Website = DBNull.Value.Equals(reader["WebSite"]) ? string.Empty : Convert.ToString(reader["WebSite"]);
                            objclient.EmailID = DBNull.Value.Equals(reader["EmailId"]) ? string.Empty : Convert.ToString(reader["EmailId"]);
                            objclient.Description = DBNull.Value.Equals(reader["Description"]) ? string.Empty : Convert.ToString(reader["Description"]);
                            objclientInfoList.Add(objclient);
                        }
                        reader.Close();


                    }
                    return objclientInfoList;
                }
            }

        }
        public string Create(Branch objBranch)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Branch_insert", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BranchID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BranchName", objBranch.BranchName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationName", objBranch.OrganizationName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationCode", objBranch.OrganizationCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrgID", objBranch.Orgid));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AreaID", objBranch.AreaID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PhoneNo", objBranch.Phone));
                    cmd.Parameters.Add(DataFactory.CreateParameter("WebSite", objBranch.Website));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmailId", objBranch.EmailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Address", objBranch.Address));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objBranch.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objBranch.Createdby));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                }
                if (RecordAffected > 0)
                    return Convert.ToString(objBranch.BranchID);
                else
                    return "Error";
            }
        }

        public string Update(Branch objBranch)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Branch_insert", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", false));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BranchID", objBranch.BranchID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("BranchName", objBranch.BranchName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationName", objBranch.OrganizationName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationCode", objBranch.OrganizationCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrgID", objBranch.Orgid));
                    cmd.Parameters.Add(DataFactory.CreateParameter("AreaID", objBranch.AreaID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PhoneNo", objBranch.Phone));
                    cmd.Parameters.Add(DataFactory.CreateParameter("WebSite", objBranch.Website));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmailId", objBranch.EmailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Address", objBranch.Address));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objBranch.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objBranch.Createdby));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                }
                if (RecordAffected > 0)
                    return Convert.ToString(objBranch.BranchID);
                else
                    return "Error";
            }
        }

        public List<Area> AreaList(string SearchText)
        {
            List<Area> objclientInfoList = new List<Area>();
            Area objclient = null;
            IDbConnection con = null;
            IDbCommand cmd = null;
            IDataReader reader;
            string ID = string.Empty;
            // int RecordsAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("[Sp_AutoCityList]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objclient = new Area();
                        objclient.AreaID = Convert.ToInt64(reader["AreaID"]);
                        objclient.AreaName = Convert.ToString(reader["AreaName"]);
                        objclient.CityName = Convert.ToString(reader["Cityname"]);
                        objclient.StateName = Convert.ToString(reader["Statename"]);
                        objclient.CountryName = Convert.ToString(reader["Countryname"]);
                        objclientInfoList.Add(objclient);
                    }
                    reader.Close();
                    return objclientInfoList;
                }
            }
        }

        public List<Branch> OrgAuto(string SearchText)
        {
            List<Branch> objclientInfoList = new List<Branch>();
            Branch objclient = null;
            IDbCommand cmd = null;
            IDbConnection con = null;
            IDataReader reader = null;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_OrgAuto", con))
                {

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        objclient = new Branch();


                        objclient.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                        objclient.OrganizationCode = Convert.ToString(reader["OrganizationCode"]);
                        objclient.Orgid = Convert.ToInt64(reader["OrganizationID"]);
                        objclientInfoList.Add(objclient);
                    }
                    reader.Close();

                    return objclientInfoList;
                }
            }

        }
    }
}
