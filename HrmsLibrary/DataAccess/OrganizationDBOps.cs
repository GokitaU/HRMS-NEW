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
    public class OrganizationDBOps
    {
        public List<Organization> SearchPage(int PageNo, int RowsPerPage, string SearchText, Int64 OrganizationID)
        {
            int TotalRecords = 0;
            List<Organization> OrgList = new List<Organization>();
            Organization objOrganization;
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("sp_Organization_Grid", conn))
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
                            objOrganization = new Organization();
                            objOrganization.OrganizationID = Convert.ToInt64(reader["OrganizationID"]);
                            objOrganization.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                            objOrganization.OrganizationCode = Convert.ToString(reader["OrganizationCode"]);
                            objOrganization.PrimaryPhoneNo = Convert.ToString(reader["PhoneNo"]);
                            objOrganization.Address = DBNull.Value.Equals(reader["Address"]) ? string.Empty : Convert.ToString(reader["Address"]);
                            objOrganization.EmailID = DBNull.Value.Equals(reader["EmailID"]) ? string.Empty : Convert.ToString(reader["EmailID"]);
                            objOrganization.Description = DBNull.Value.Equals(reader["Description"]) ? string.Empty : Convert.ToString(reader["Description"]);
                            objOrganization.TotalRecords = TotalRecords;
                            OrgList.Add(objOrganization);
                        }

                    }
                    reader.Close();
                    return OrgList;
                }
            }

        }
        public string Create(Organization objOrganization)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateOrganization", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", true));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationName", objOrganization.OrganizationName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationCode", objOrganization.OrganizationCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Address", objOrganization.Address));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PhoneNo", objOrganization.PrimaryPhoneNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmailID", objOrganization.EmailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objOrganization.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", objOrganization.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    objOrganization.OrganizationID = Convert.ToInt64(param.Value);
                }
            }
            if (RecordAffected < 0)
                return Convert.ToString(objOrganization.OrganizationID);
            else
                return "Error";

        }

        public Boolean Update(Organization objOrganization)
        {
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_CreateOrganization", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", false));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationID", objOrganization.OrganizationID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationName", objOrganization.OrganizationName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("OrganizationCode", objOrganization.OrganizationCode));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Address", objOrganization.Address));
                    cmd.Parameters.Add(DataFactory.CreateParameter("PhoneNo", objOrganization.PrimaryPhoneNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("EmailID", objOrganization.EmailID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objOrganization.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("CreatedBy", objOrganization.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                }
            }
            if (RecordAffected > 0)
                return true;
            else
                return false;
        }
    }
}
