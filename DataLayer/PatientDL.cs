using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class PatientDL:DataProvider
    {
        public ObservableCollection<Patient> GetPatients()
        {
            string sql = "SELECT * FROM Patient";
            int id;
            string name, address, phone, email, healthInsuranceId, idCard, medicalHistory;
            DateTime dob;
            Gender gender = Gender.MALE;

            ObservableCollection<Patient> patients = new ObservableCollection<Patient>();
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = reader.GetInt32(reader.GetOrdinal("id"));
                    name = reader["namePat"].ToString();
                    dob = reader.GetDateTime(reader.GetOrdinal("dob"));
                    int genderValue = reader.GetInt32(reader.GetOrdinal("gender"));
                    if (genderValue == 0)
                        gender = Gender.MALE;
                    else if (genderValue == 1)
                        gender = Gender.FEMALE;
                    address = reader["addressPat"].ToString();
                    phone = reader["phone"].ToString();
                    email = reader["email"].ToString();
                    healthInsuranceId = reader["healthInsuranceId"].ToString();
                    idCard = reader["idCard"].ToString();
                    medicalHistory = reader["medicalHistory"].ToString();

                    Patient patient = new Patient(id, name, dob, gender, address, phone, email, healthInsuranceId, idCard, medicalHistory);
                    patients.Add(patient);
                }
                reader.Close();
                return patients;
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

        public int Add(Patient patient)
        {
            string sql = "uspAddPatient";
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter("@namePat", (object)patient.name),
                new SqlParameter("@dob", patient.dob),
                new SqlParameter("@gender", (int)patient.gender),
                new SqlParameter("@addressPat", (object)patient.address),
                new SqlParameter("@phone", (object)patient.phone),
                new SqlParameter("@email", (object)patient.email),
                new SqlParameter("@healthInsuranceId", (object)patient.healthInsuranceId),
                new SqlParameter("@idCard", (object)patient.idCard),
                new SqlParameter("@medicalHistory", (object)patient.medicalHistory)
             };
            try
            {
                Connect();

                Console.WriteLine(patient.id);

                return MyExecuteNonQuerry(sql, CommandType.StoredProcedure, sqlParameters);
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

        public int Update(Patient patient) {
            string sql = "uspUpdatePatient";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", patient.id),
                new SqlParameter("@namePat", (object)patient.name),
                new SqlParameter("@dob", patient.dob),
                new SqlParameter("@gender", (int)patient.gender),
                new SqlParameter("@addressPat", (object)patient.address ),
                new SqlParameter("@phone", (object)patient.phone),
                new SqlParameter("@idCard", (object)patient.idCard ?? DBNull.Value),
                new SqlParameter("@medicalHistory", (object)patient.medicalHistory)
            };
            Console.WriteLine(patient);

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
