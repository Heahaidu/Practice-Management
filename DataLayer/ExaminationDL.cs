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
    public class ExaminationDL : DataProvider
    {
        public ObservableCollection<Examination> GetExaminations(int patientId)
        {
            string sql = "SELECT * FROM Examination WHERE patientId = " + patientId;
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
    }
}