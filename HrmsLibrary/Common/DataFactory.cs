using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data.Common;
using System.Data;
using System.Configuration;

namespace HrmsLibrary.Common
{
    public enum DatabaseType
    {
        Access,
        SQLServer,
        Oracle
    }
    public enum DataType
    {
        Integer,
        Char,
        VarChar
    }
    public class DataFactory
    {

        private static DatabaseType _dbType;
        //private static DataType _dataType;

        static DataFactory()
        {
            string dbType = ConfigurationManager.AppSettings["DatabaseType"].ToString();

            if (dbType.Equals("SqlServer"))
                _dbType = DatabaseType.SQLServer;
            else if (dbType.Equals("Oracle"))
                _dbType = DatabaseType.Oracle;
            else if (dbType.Equals("Access"))
                _dbType = DatabaseType.Access;
        }

        public static IDbConnection CreateConnection()
        {
            System.Data.IDbConnection cnn;
            string ConnectionString;
            switch (_dbType)
            {
                case DatabaseType.Access:

                    ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                    cnn = new SqlConnection(ConnectionString);
                    break;
                case DatabaseType.SQLServer:
                    ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                    cnn = new SqlConnection(ConnectionString);
                    break;
                default:
                    ConnectionString = ConfigurationManager.AppSettings["ConnectionString"];
                    cnn = new SqlConnection(ConnectionString);
                    break;
            }

            return cnn;
        }

        public static System.Data.IDbCommand CreateCommand(string CommandText, System.Data.IDbConnection cnn)
        {
            System.Data.IDbCommand cmd;
            switch (_dbType)
            {
                case DatabaseType.Access:
                    cmd = new OleDbCommand(CommandText, (OleDbConnection)cnn);
                    break;
                case DatabaseType.SQLServer:
                    cmd = new SqlCommand(CommandText, (SqlConnection)cnn);
                    break;
                default:
                    cmd = new SqlCommand(CommandText, (SqlConnection)cnn);
                    break;
            }
            return cmd;
        }

        public static DbDataAdapter CreateAdapter(System.Data.IDbCommand cmd, DatabaseType dbtype)
        {
            DbDataAdapter da;
            switch (_dbType)
            {
                case DatabaseType.Access:
                    da = new OleDbDataAdapter((OleDbCommand)cmd);
                    break;
                case DatabaseType.SQLServer:
                    da = new SqlDataAdapter((SqlCommand)cmd);
                    break;
                default:
                    da = new SqlDataAdapter((SqlCommand)cmd);
                    break;
            }
            return da;
        }

        public static DbParameter CreateParameter(string paramName, object paramValue)
        {
            switch (_dbType)
            {
                case DatabaseType.SQLServer:
                    return new SqlParameter(paramName, paramValue);
            }
            return new SqlParameter(paramName, paramValue);
        }


        public static string GetEncryptedData(string sourceData)
        {
            if (!string.IsNullOrEmpty(sourceData))
            {
                byte[] sourceBytes = ASCIIEncoding.ASCII.GetBytes(sourceData);
                return Convert.ToBase64String(sourceBytes);
            }
            return string.Empty;
        }

        public static string GetDecryptedData(string sourceData)
        {
            if (!string.IsNullOrEmpty(sourceData))
            {
                byte[] targetBytes = Convert.FromBase64String(sourceData);
                return ASCIIEncoding.ASCII.GetString(targetBytes);
            }

            return string.Empty;
        }

    }


}
