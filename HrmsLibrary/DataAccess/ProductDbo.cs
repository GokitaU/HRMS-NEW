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
    public class ProductDbo
    {
        public List<Product> ModuleList()
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
                using (cmd = DataFactory.CreateCommand("Sp_ListModuleMaster", conn))
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
        public List<Product> MainGrid(int PageNo, int RowsPerPage, string SearchText)
        {
            IDbConnection conn = null;
            IDbCommand cmd = null;
            IDataReader reader = null;
            Int64 TotalRecords = 0;
            List<Product> objProduct = new List<Product>();
            Product objlist = null;
            using (conn = DataFactory.CreateConnection())
            {
                conn.Open();
                cmd = conn.CreateCommand();
                using (cmd = DataFactory.CreateCommand("SP_ProductMaster_Search", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@PageNo", PageNo));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@RowsPerPage", RowsPerPage));
                    cmd.Parameters.Add(DataFactory.CreateParameter("@SearchText", SearchText));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        TotalRecords = Convert.ToInt64(reader["TotalRecords"]);
                    }
                    if (reader.NextResult())
                    {
                        while (reader.Read())
                        {
                            objlist = new Product();
                            objlist.ProductID = Convert.ToInt64(reader["ProductID"]);
                            objlist.ProductName = Convert.ToString(reader["ProductName"]);
                            objlist.ProductID = Convert.ToInt64(reader["ProductID"]);
                            objlist.ModuleMasterID = Convert.ToInt64(reader["ModuleMasterID"]);
                            objlist.ModuleMasterName = Convert.ToString(reader["ModuleMasterName"]);
                            objlist.Description = Convert.ToString(reader["Description"]);
                            objlist.ProjectManagerId = Convert.ToInt64(reader["ProjectManagerId"]);
                            objlist.TotalRecords = TotalRecords;
                            objProduct.Add(objlist);

                        }
                    }
                    reader.Close();
                }
                return objProduct;
            }
        }

        public Int32 CheckProductName(string strcode)
        {
            var ProductName = strcode;
            IDbConnection con = null;
            IDbCommand cmd = null;
            IDataReader reader;
            Int32 counts = 0;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                using (cmd = DataFactory.CreateCommand("[Sp_ProductName_Check]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("@ProductName", ProductName));
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        counts = Convert.ToInt32(reader["Activeflag"]);
                    }

                    reader.Close();

                }
                return counts;
            }

        }

        public string Create(Product objProduct)
        {
            string LTypeID = string.Empty;
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("[Sp_ProductMaster_insert]", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", 1));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProductID", DBNull.Value));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProductName", objProduct.ProductName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProjectManagerId", objProduct.ProjectManagerId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleMasterName", objProduct.ModuleMasterName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleMasterID", objProduct.ModuleMasterID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objProduct.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objProduct.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    LTypeID = param.Value.ToString();
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objProduct.ProductID);
            else
                return "Error";

        }

        public string Update(Product objProduct)
        {
            string LTypeID = string.Empty;
            IDbConnection con = null;
            IDbCommand cmd = null;
            int RecordAffected;
            using (con = DataFactory.CreateConnection())
            {
                con.Open();
                cmd = con.CreateCommand();
                using (cmd = DataFactory.CreateCommand("Sp_ProductMaster_insert", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(DataFactory.CreateParameter("IsSave", "0"));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProductID", objProduct.ProductID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProductName", objProduct.ProductName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ProjectManagerId", objProduct.ProjectManagerId));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleMasterName", objProduct.ModuleMasterName));
                    cmd.Parameters.Add(DataFactory.CreateParameter("ModuleMasterID", objProduct.ModuleMasterID));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Description", objProduct.Description));
                    cmd.Parameters.Add(DataFactory.CreateParameter("Createdby", objProduct.CreatedBy));
                    IDbDataParameter param = DataFactory.CreateParameter("@@guid", DBNull.Value);
                    param.DbType = DbType.Int64;
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    RecordAffected = cmd.ExecuteNonQuery();
                    LTypeID = param.Value.ToString();
                }
            }
            if (RecordAffected > 0)
                return Convert.ToString(objProduct.ProductID);
            else
                return "Error";

        }
    }
}
