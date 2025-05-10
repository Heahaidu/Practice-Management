using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DataLayer
{
    public class LoginDL:DataProvider
    {

        public (bool, TransferObject.User) Login(string username, string password)
        {
            try
            {
                Connect();
                string sql = "SELECT * FROM Users WHERE username = @username AND password = @password";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password)
                };

                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, sqlParameters);
                if (reader.HasRows)
                {
                    reader.Read();
                    TransferObject.User user = new TransferObject.User
                    {
                        username = reader["username"].ToString(),
                        password = reader["password"].ToString(),
                        displayName = reader["displayName"].ToString(),
                        email = reader["email"].ToString(),
                        level = reader.GetByte(reader.GetOrdinal("authority_level"))
                    };
                    reader.Close();
                    return (true, user);
                }
                else
                {
                    reader.Close();
                    return (false, null);
                }
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

    }
}
