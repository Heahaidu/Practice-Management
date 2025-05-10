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
    public class IndicationDL : DataProvider
    {
        public ObservableCollection<Indication> GetIndications(int patientId)
        {
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

                    Indication indication = new Indication(id, indicationDate, indicationType, doctorName, diagnosisName, notes, patientId, reader.IsDBNull(reader.GetOrdinal("doctorId")) ? 0 : reader.GetInt32(reader.GetOrdinal("doctorId")), 2);
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
                new SqlParameter("@indicationDate", indication.IndicationDate),
                new SqlParameter("@indicationType", (object)indication.IndicationType),
                new SqlParameter("@doctorName", (object)indication.DoctorName),
                new SqlParameter("@diagnosisName", (object)indication.DiagnosisName),
                new SqlParameter("@notes", (object)indication.Notes),
                new SqlParameter("@patientId", (int)patientId),
                new SqlParameter("@doctorId", indication.DoctorId)
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

        public int GetTotalIndication()
        {
            try
            {
                string sql = "SELECT COUNT(*) FROM Indication";
                return Convert.ToInt32(MyExecuteScalar(sql, CommandType.Text));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}