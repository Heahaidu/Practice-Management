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
                string sql = "SELECT * FROM Users WHERE NOT(username LIKE '-%')";
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    User user = new User
                    {
                        username = reader["username"].ToString(),
                        password = "",
                        level =  int.Parse( reader["authority_level"].ToString()),
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

        public int NewAccount(User user)
        {
            try
            {
                Connect();
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@username", user.username),
                    new SqlParameter("@password", user.password),
                    new SqlParameter("@displayName", user.displayName),
                    new SqlParameter("@email", user.email),
                    new SqlParameter("@authority_level", user.level)
                };
                int rowsAffected = MyExecuteNonQuerry("uspCreateAccount", CommandType.StoredProcedure, sqlParameters);
                return rowsAffected;
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

        public int Delete(string username)
        {
            try
            {
                Connect();
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter("@username", username)
                };
                int rowsAffected = MyExecuteNonQuerry("uspDeleteAccount", CommandType.StoredProcedure, sqlParameters);
                return rowsAffected;
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
