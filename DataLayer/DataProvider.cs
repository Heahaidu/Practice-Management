using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Policy;

namespace DataLayer
{
    public class DataProvider
    {
        private SqlConnection cn;
        private SqlCommand cmd;

        public DataProvider()
        {
            string cnStr = "Data Source=db-programming.database.windows.net;Initial Catalog=Prescription;User ID=administrator_;Password=123456789A1@";
            this.cn = new SqlConnection(cnStr);
        }

        public void Connect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Closed)
                {
                    cn.Open();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public void DisConnect()
        {
            try
            {
                if (cn != null && cn.State == ConnectionState.Open)
                {
                    cn.Close();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public object MyExecuteScalar(string sql, CommandType type)
        {
            try
            {
                Connect();
                cmd = new SqlCommand(sql, cn);
                cmd.CommandType = type;

                return cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public SqlDataReader MyExecuteReader(string sql, CommandType type) { 
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            try
            {
                return (cmd.ExecuteReader());
            }
            catch (SqlException ex){ 
                throw ex;
            }
        }


        public int MyExecuteNonQuerry(string sql, CommandType type, List<SqlParameter> parameters = null)
        {
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.CommandType = type;
            try
            {
                if (type == CommandType.StoredProcedure)
                {
                    cmd.CommandText = sql;
                    foreach (SqlParameter param in parameters)
                    {
                        cmd.Parameters.Add(param);
                    }
                    return cmd.ExecuteNonQuery();
                }
                Console.WriteLine("Add");
                return (cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
