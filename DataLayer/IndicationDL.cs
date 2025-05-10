using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;

namespace DataLayer
{
    public class IndicationDL:DataProvider
    {
        public ObservableCollection<Indication> GetIndications(int patientId) {
            string sql = "SELECT * FROM indication WHERE patientId = " + patientId;
            int id;
            DateTime indicationDate;
            string indicationType, doctorName, diagnosisName, notes;

            ObservableCollection<Indication> indications = new ObservableCollection<Indication>();
            try
            {
                Connect();

                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = reader.GetInt32(reader.GetOrdinal("id"));
                    indicationDate = reader.GetDateTime(reader.GetOrdinal("indicationDate"));
                    indicationType = reader["indicationType"].ToString();
                    doctorName = reader["doctorName"].ToString();
                    diagnosisName = reader["diagnosisName"].ToString();
                    notes = reader["notes"].ToString();

                    Indication indication = new Indication(id, indicationDate, indicationType, doctorName, diagnosisName, notes);
                    indications.Add(indication);
                }
                reader.Close();
                return indications;
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

        public int Add(Indication indication, int patientId)
        {
            string sql = "uspAddIndication";


            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@indicationDate", indication.indicationDate),
                new SqlParameter("@indicationType", (object)indication.indicationType),
                new SqlParameter("@doctorName", (object)indication.doctorName),
                new SqlParameter("@diagnosisName", (object)indication.diagnosisName),
                new SqlParameter("@notes", (object)indication.notes),
                new SqlParameter("@patientId", (int)patientId)
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
    }
}
