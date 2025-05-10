using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class AccountDL:DataProvider
    {

        public bool UpdateAccount(string username, string password, string displayName, string email)
        {
            try
            {
                Connect();
                string sql = "UPDATE Users SET password = @password, displayName = @displayName, email = @email WHERE username = @username";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@username", username),
                    new SqlParameter("@password", password),
                    new SqlParameter("@displayName", displayName),
                    new SqlParameter("@email", email)
                };
                int rowsAffected = MyExecuteNonQuerry(sql, CommandType.Text, sqlParameters);
                return rowsAffected > 0;
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

        public List<User> GetUsers()
        {
            try
            {
                List<User> users = new List<User>();
                Connect();
                string sql = "SELECT * FROM Users";
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    User user = new User
                    {
                        username = reader["username"].ToString(),
                        password = "",
                        displayName = reader["displayName"].ToString(),
                        email = reader["email"].ToString()
                    };
                    users.Add(user);
                }
                return users;
            } catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
