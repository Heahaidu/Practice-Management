using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class PatientBL
    {
        private PatientDL patientDL;

        public PatientBL()
        {
            patientDL = new PatientDL();
        }

        public ObservableCollection<Patient> GetPatients()
        {
            try
            {
                return (patientDL.GetPatients());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Add(Patient patient)
        {
            return patientDL.Add(patient);
        }

        public int Update(Patient patient)
        {
            return patientDL.Update(patient);
        }

        public int Delete(int id)
        {
            return patientDL.Delete(id);
        }

        public int GetTotalPatients()
        {
            try
            {
                return patientDL.GetTotalPatients();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int GetPatientsCreatedToday()
        {
            try
            {
                return patientDL.GetPatientsCreatedToday();
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
                return patientDL.GetNewPatientsByWeek();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<double> GetTotalPatientsByWeek()
        {
            try
            {
                return patientDL.GetTotalPatientsByWeek();
            }
            catch(SqlException ex)
            {
                throw ex;
            }
        }
    }
}
