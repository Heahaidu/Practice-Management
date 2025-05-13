using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;

namespace DataLayer
{
    public class TechCatalogDL:DataProvider
    {
        public ObservableCollection<TechnicalCatalog> GetTechnicalCatalogs(bool isCludingInvisible = false) {
            string sql = "SELECT * FROM TechnicalCatalog" + (!isCludingInvisible? " WHERE NOT(nameTech LIKE '-%')": "");
            int id;
            string typeTech, nameTech, descriptionTech;
            float price, discountPrice;

            ObservableCollection<TechnicalCatalog> technicalCatalogs = new ObservableCollection<TechnicalCatalog>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = reader.GetInt32(reader.GetOrdinal("id"));
                    typeTech = reader["typeTech"].ToString();
                    nameTech = reader["nameTech"].ToString();
                    descriptionTech = reader["descriptionTech"].ToString();
                    price = (float)reader.GetDouble(reader.GetOrdinal("price"));
                    discountPrice = (float)reader.GetDouble(reader.GetOrdinal("discountPrice"));

                    TechnicalCatalog technicalCatalog = new TechnicalCatalog(id, typeTech, nameTech, price, discountPrice, descriptionTech);
                    technicalCatalogs.Add(technicalCatalog);
                }
                reader.Close();
                return technicalCatalogs;
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

        public ObservableCollection<TechnicalCatalog> GetTechnicalCatalogsOfType(string indicationType)
        {
            string sql = "SELECT * FROM TechnicalCatalog WHERE typeTech = @typeTech AND NOT(nameTech LIKE '-%')";
            int id;
            string typeTech, nameTech, descriptionTech;
            float price, discountPrice;
            ObservableCollection<TechnicalCatalog> technicalCatalogs = new ObservableCollection<TechnicalCatalog>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, new List<SqlParameter> { new SqlParameter("@typeTech", indicationType) });
                while (reader.Read())
                {
                    id = reader.GetInt32(reader.GetOrdinal("id"));
                    typeTech = reader["typeTech"].ToString();
                    nameTech = reader["nameTech"].ToString();
                    descriptionTech = reader["descriptionTech"].ToString();
                    price = (float)reader.GetDouble(reader.GetOrdinal("price"));
                    discountPrice = (float)reader.GetDouble(reader.GetOrdinal("discountPrice"));
                    TechnicalCatalog technicalCatalog = new TechnicalCatalog(id, typeTech, nameTech, price, discountPrice, descriptionTech);
                    technicalCatalogs.Add(technicalCatalog);
                }
                reader.Close();
                return technicalCatalogs;
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

        public int Add(TechnicalCatalog technicalCatalog)
        {
            string sql = "uspAddTech";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@nameTech", (object)technicalCatalog.name),
                new SqlParameter("@typeTech", (object)technicalCatalog.type),
                new SqlParameter("@price", (float)technicalCatalog.price),
                new SqlParameter("@discountPrice", (float)technicalCatalog.discountPrice),
                new SqlParameter("@descriptionTech", (object)technicalCatalog.description)
            };

            try
            {
                Connect();

                return MyExecuteNonQuerry(sql, CommandType.StoredProcedure, parameters);
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

        public int Update(TechnicalCatalog technicalCatalog)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>()
            {
                new SqlParameter("@id", (int)technicalCatalog.id),
                new SqlParameter("@nameTech", (object)technicalCatalog.name),
                new SqlParameter("@typeTech", (object)technicalCatalog.type),
                new SqlParameter("@price", technicalCatalog.price),
                new SqlParameter("@discountPrice", technicalCatalog.discountPrice),
                new SqlParameter("@descriptionTech", (object)technicalCatalog.description)
            };
            try
            {
                Connect();
                return MyExecuteNonQuerry("uspUpdateTechnicalCatalog", CommandType.StoredProcedure, sqlParameters);
            } catch (SqlException ex) {
                throw ex;
            } 

        }

        public int Delete(int id)
        {
            try
            {
                Connect();
                return MyExecuteNonQuerry("uspDeleteTech", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id", id) });
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
