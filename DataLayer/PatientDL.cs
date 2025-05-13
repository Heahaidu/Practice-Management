using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace DataLayer
{
    public class PatientDL : DataProvider
    {
        public ObservableCollection<Patient> GetPatients()
        {
            string sql = "SELECT * FROM Patient WHERE NOT (namePat LIKE '-%')";
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
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                DisConnect();
            }
        }

        public int Update(Patient patient)
        {
            string sql = "uspUpdatePatient";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", patient.id),
                new SqlParameter("@namePat", (object)patient.name),
                new SqlParameter("@dob", patient.dob),
                new SqlParameter("@gender", (int)patient.gender),
                new SqlParameter("@addressPat", (object)patient.address ),
                new SqlParameter("@email", patient.email),
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

        public int Delete(int id)
        {
            string sql = "uspDeletePatient";
            List<SqlParameter> parameters = new List<SqlParameter>
            {
                new SqlParameter("@id", id)
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

        public (List<double>, List<double>, List<float>) GetWeekStaistics()
        {
            try
            {
                List<double> patientsQuality = new List<double>();
                List<double> newPatientsQuality = new List<double>();
                List<float> totalCost = new List<float>();

                Connect();
                SqlDataReader reader = MyExecuteReader("SELECT * FROM WEEKSTATISTIC()", CommandType.Text);
                while (reader.Read())
                {
                    patientsQuality.Add(reader.GetInt32(reader.GetOrdinal("patient_quality")));
                    newPatientsQuality.Add(reader.GetInt32(reader.GetOrdinal("new_patient_quality")));
                    totalCost.Add(reader.IsDBNull(reader.GetOrdinal("total_cost")) ? 0.0f : (float)reader.GetDouble(reader.GetOrdinal("total_cost")));
                }
                return (patientsQuality, newPatientsQuality, totalCost);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public Patient GetPatientById(int patientId)
        {
            try
            {
                string sql = "SELECT * FROM Patient WHERE = @patientId";
                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@patientId", patientId)
                };
                Connect();
                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text, parameters);
                Gender gender = Gender.MALE;
                while (reader.Read())
                {
                    int genderValue = reader.GetInt32(reader.GetOrdinal("gender"));
                    if (genderValue == 0)
                        gender = Gender.MALE;
                    else if (genderValue == 1) gender = Gender.FEMALE;
                    return new Patient
                    {
                        id = reader.GetInt32(reader.GetOrdinal("id")),
                        name = reader["namePat"].ToString(),
                        dob = reader.GetDateTime(reader.GetOrdinal("dob")),
                        gender = gender,
                        address = reader["addressPat"].ToString(),
                        phone = reader["phone"].ToString(),
                        email = reader["email"].ToString(),
                        healthInsuranceId = reader["healthInsuranceId"].ToString(),
                        idCard = reader["idCard"].ToString(),
                        medicalHistory = reader["medicalHistory"].ToString(),
                    };
                }
                return null;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public List<double> GetNewPatientsByWeek()
        {
            try
            {
                List<double> newPatients = new List<double>(7); // 7 ngày: T2 -> CN
                DateTime today = DateTime.Today;
                int daysUntilMonday = ((int)today.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
                DateTime monday = today.AddDays(-daysUntilMonday);

                for (int i = 0; i < 7; i++)
                {
                    DateTime day = monday.AddDays(i);
                    string query = "SELECT COUNT(*) FROM Patient WHERE CAST(createDate AS DATE) = @day";
                    List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@day", day)
                };
                    object result = MyExecuteScalar(query, System.Data.CommandType.Text, parameters);
                    int count = Convert.ToInt32(result);
                    newPatients.Add(count);
                }

                return newPatients;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public List<double> GetTotalPatientsByWeek()
        {
            try
            {
                List<double> totalPatients = new List<double>(7);
                DateTime today = DateTime.Today;
                int daysUntilMonday = ((int)today.DayOfWeek - (int)DayOfWeek.Monday + 7) % 7;
                DateTime monday = today.AddDays(-daysUntilMonday);

                for (int i = 0; i < 7; i++)
                {
                    DateTime day = monday.AddDays(i);
                    string query = "SELECT COUNT(*) FROM Patient WHERE CAST(createDate AS DATE) <= @day";
                    List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@day", day)
                };
                    object result = MyExecuteScalar(query, System.Data.CommandType.Text, parameters);
                    int count = Convert.ToInt32(result);
                    totalPatients.Add(count);
                }

                return totalPatients;
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }

        public (int, int, int, int, int) GetDashboardData()
        {
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader("SELECT * FROM dayStatistic()", CommandType.Text);
                int patientQuality = 0;
                int newPatientQuality = 0;
                int prescriptionQuality = 0;
                int indicationQuality = 0;
                int examinationQuality = 0;

                while (reader.Read())
                {
                    patientQuality = reader.GetInt32(reader.GetOrdinal("patient_quality"));
                    newPatientQuality = reader.GetInt32(reader.GetOrdinal("new_patient_quality"));
                    prescriptionQuality = reader.GetInt32(reader.GetOrdinal("prescription_quality"));
                    indicationQuality = reader.GetInt32(reader.GetOrdinal("indication_quality"));
                    examinationQuality =reader.GetInt32(reader.GetOrdinal("examination_quality"));
                }
                reader.Close();

                List<double> patientsQuality = new List<double>();
                List<double> newPatientsQuality = new List<double>();
                List<float> totalCost = new List<float>();

                Connect();
                reader = MyExecuteReader("SELECT * FROM WEEKSTATISTIC()", CommandType.Text);
                while (reader.Read())
                {
                    patientsQuality.Add(reader.GetInt32(reader.GetOrdinal("patient_quality")));
                    newPatientsQuality.Add(reader.GetInt32(reader.GetOrdinal("new_patient_quality")));
                    totalCost.Add(reader.IsDBNull(reader.GetOrdinal("total_cost")) ? 0.0f : (float)reader.GetDouble(reader.GetOrdinal("total_cost")));
                }

                return (patientQuality, newPatientQuality, prescriptionQuality, indicationQuality, examinationQuality);
            } catch
            {
                return (0, 0, 0, 0, 0);
            }
        }

        public (List<double>, List<double>) GetGenderStatistics()
        {
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader("SELECT * FROM AGE_STATISTIC()", CommandType.Text);
                List<double> maleQuality = new List<double>();
                List<double> femaleQuality = new List<double>();

                while (reader.Read())
                {
                    maleQuality.Add(reader.GetDouble(reader.GetOrdinal("male")));
                    femaleQuality.Add(reader.GetDouble(reader.GetOrdinal("female")));
                }
                reader.Close();
                return (maleQuality, femaleQuality);
            }
            catch
            {
                return (new List<double>(), new List<double>());
            }
        }

        public (List<double>, List<double>, List<float>, List<double>, List<double>) GetChartsData()
        {
            try
            {
                List<double> patientsQuality = new List<double>();
                List<double> newPatientsQuality = new List<double>();
                List<float> totalCost = new List<float>();

                Connect();
                MyExecuteNonQuerry("SET DATEFIRST 1;", CommandType.Text);
                SqlDataReader reader = MyExecuteReader("SELECT * FROM WEEKSTATISTIC() ORDER BY weekday", CommandType.Text);
                while (reader.Read())
                {
                    patientsQuality.Add(reader.GetInt32(reader.GetOrdinal("patient_quality")));
                    newPatientsQuality.Add(reader.GetInt32(reader.GetOrdinal("new_patient_quality")));
                    totalCost.Add(reader.IsDBNull(reader.GetOrdinal("total_cost")) ? 0.0f : (float)reader.GetDouble(reader.GetOrdinal("total_cost")));
                    Console.WriteLine(reader["weekday"]);
                }

                reader = MyExecuteReader("SELECT * FROM AGE_STATISTIC()", CommandType.Text);
                List<double> maleQuality = new List<double>();
                List<double> femaleQuality = new List<double>();

                while (reader.Read())
                {
                    maleQuality.Add(reader.GetInt32(reader.GetOrdinal("male")));
                    femaleQuality.Add(reader.GetInt32(reader.GetOrdinal("female")));
                }
                reader.Close();
                return (patientsQuality, newPatientsQuality, totalCost, maleQuality, femaleQuality);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
