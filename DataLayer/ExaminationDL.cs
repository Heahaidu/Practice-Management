using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;
using System.Data;
using System.CodeDom;

namespace DataLayer
{
    public class ExaminationDL : DataProvider
    {
        public ObservableCollection<Examination> GetExaminations(int patientId)
        {
            string sql = "SELECT * FROM Examination WHERE patientId = " + patientId + " AND NOT(diagnosisName LIKE '-%')";
            int id;
            DateTime examinationDate;
            string doctorName, medicalHistory, diagnosisName, notes;

            ObservableCollection<Examination> examinations = new ObservableCollection<Examination>();
            try
            {
                Connect();

                SqlDataReader reader = MyExecuteReader(sql, CommandType.Text);
                while (reader.Read())
                {
                    id = reader.GetInt32(reader.GetOrdinal("id"));
                    examinationDate = reader.GetDateTime(reader.GetOrdinal("examinationDate"));
                    doctorName = reader["doctorName"].ToString();
                    medicalHistory = reader["medicalHistory"].ToString();
                    diagnosisName = reader["diagnosisName"].ToString();
                    notes = reader["notes"].ToString();

                    Examination examination = new Examination(id, examinationDate, doctorName, medicalHistory, diagnosisName, notes, patientId, reader.IsDBNull(reader.GetOrdinal("doctorId")) ? 0 : reader.GetInt32(reader.GetOrdinal("doctorId")));
                    examinations.Add(examination);
                }
                reader.Close();
                return examinations;

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

        public int Add(Examination examination, int patientId)
        {
            string sql = "uspAddExam";
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@examinationDate", examination.ExaminationDate),
                new SqlParameter("@doctorName", (object)examination.DoctorName),
                new SqlParameter("@medicalHistory", (object)examination.MedicalHistory),
                new SqlParameter("@diagnosisName", (object)examination.DiagnosisName),
                new SqlParameter("@notes", (object)examination.Notes),
                new SqlParameter("@patientId", (int)patientId),
                new SqlParameter("@doctorId", examination.DoctorId)
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
            string sql = "uspDeleteExam";
            List<SqlParameter> parameters = new List<SqlParameter>()
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
        }

        public int AddPrescription(int examinationId, Prescription prescription)
        {
            try
            {
                Connect();
                string sql = "uspAddPrescriptionDetail";
                List<SqlParameter> parameters = new List<SqlParameter>()
                    {
                        new SqlParameter("@examination_id", examinationId),
                        new SqlParameter("@medicine_id", prescription.MedicineId),
                        new SqlParameter("@daysUse", prescription.DateUses),
                        new SqlParameter("@morning", prescription.Moring),
                        new SqlParameter("@noon", prescription.Noon),
                        new SqlParameter("@evening", prescription.Evening),
                    };
                return MyExecuteNonQuerry(sql, CommandType.StoredProcedure, parameters);

            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Prescription> GetPrescription(int id)
        {
            try
            {
                Connect();
                SqlDataReader reader = MyExecuteReader("SELECT * FROM Details_Examination WHERE examination_id = " + id, CommandType.Text);
                List<Prescription> prescriptions = new List<Prescription>();
                while (reader.Read())
                {
                    int medicineId = reader.GetInt32(reader.GetOrdinal("medicine_id"));
                    int dayUse = reader.GetInt32(reader.GetOrdinal("daysUse"));
                    string note = "";//reader["note"].ToString() ?? "";
                    int morning = reader.GetInt32(reader.GetOrdinal("morning"));
                    int noon = reader.GetInt32(reader.GetOrdinal("noon"));
                    int evening = reader.GetInt32(reader.GetOrdinal("evening"));
                    Prescription prescription = new Prescription(medicineId, dayUse, morning, noon, evening, note);
                    prescriptions.Add(prescription);
                }
                return prescriptions;
            } catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}