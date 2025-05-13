using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;
using System.Runtime.InteropServices.ComTypes;

namespace DataLayer
{
    public class MedicineDL:DataProvider
    {
        public ObservableCollection<Medicine> GetMedicines(bool isCludingInvisible = false)
        {
            string sql = "SELECT * FROM Medicine" + (!isCludingInvisible? " WHERE NOT(nameMed LIKE '-%')": "");
            int id, quantity;
            string name, manufacturer, type, description, usage, dosage;
            float discountPrice, price;
            DateTime manufacturingDate, expiryDate, importDate; 

            ObservableCollection<Medicine> medicines = new ObservableCollection<Medicine>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);

                while (reader.Read())
                {
                    id = reader.GetInt32(reader.GetOrdinal("id"));
                    name = reader["nameMed"].ToString();
                    manufacturer = reader["manufacturer"].ToString();
                    type = reader["typeMed"].ToString();
                    description = reader["descriptionMed"].ToString();
                    discountPrice = (float)reader.GetDouble(reader.GetOrdinal("discountPrice"));
                    price = (float)reader.GetDouble(reader.GetOrdinal("price"));
                    quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
                    manufacturingDate = reader.GetDateTime(reader.GetOrdinal("manufacturingDate"));
                    expiryDate = reader.GetDateTime(reader.GetOrdinal("expiryDate"));
                    importDate = reader.GetDateTime(reader.GetOrdinal("importDate"));
                    usage = reader["usage"].ToString();
                    dosage = reader["dosage"].ToString();

                    Medicine medicine = new Medicine(id, name, manufacturer, type, description, discountPrice, price, quantity, manufacturingDate, expiryDate, importDate, usage, dosage);
                    medicines.Add(medicine);
                }
                reader.Close();
                return medicines;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public int Add(Medicine medicine)
        {
            string sql = "uspAddMedicine";

            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@nameMed", (object)medicine.name),
                new SqlParameter("@manufacturer", (object)medicine.manufacturer),
                new SqlParameter("@typeMed", (object)(medicine.type)),
                new SqlParameter("@descriptionMed", (object)medicine.description),
                new SqlParameter("@discountPrice", (float)medicine.discountPrice),
                new SqlParameter("@price", (float)(medicine.price)),
                new SqlParameter("@quantity", (int)medicine.quantity),
                new SqlParameter("@manufacturingDate", medicine.manufacturingDate),
                new SqlParameter("@expiryDate", medicine.expiryDate),
                new SqlParameter("@importDate", medicine.importDate),
                new SqlParameter("@usage", (object)medicine.usage),
                new SqlParameter("@dosage", (object)medicine.dosage)
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
    
        public int Update(Medicine medicine)
        {
            string sql = "uspUpdateMedicine";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", (int)medicine.id),
                new SqlParameter("@nameMed", (object)medicine.name),
                new SqlParameter("@manufacturer", (object)medicine.manufacturer),
                new SqlParameter("@typeMed", (object)(medicine.type)),
                new SqlParameter("@descriptionMed", (object)medicine.description),
                new SqlParameter("@discountPrice", (float)medicine.discountPrice),
                new SqlParameter("@price", (float)(medicine.price)),
                new SqlParameter("@quantity", (int)medicine.quantity),
                new SqlParameter("@manufacturingDate", medicine.manufacturingDate),
                new SqlParameter("@expiryDate", medicine.expiryDate),
                new SqlParameter("@importDate", medicine.importDate),
                new SqlParameter("@usage", (object)medicine.usage),
                new SqlParameter("@dosage", (object)medicine.dosage)
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

        public int Delete(int id)
        {
            try
            {
                Connect();
                int a = MyExecuteNonQuerry("uspDeleteMedicine", CommandType.StoredProcedure, new List<SqlParameter> { new SqlParameter("@id", id) });
                Console.WriteLine(a + " " + id);
                return a;
            } catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
