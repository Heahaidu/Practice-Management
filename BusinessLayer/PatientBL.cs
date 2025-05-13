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
        
        public (int,int,int,int,int) GetDashboardData()
        {
            try
            {
                return patientDL.GetDashboardData();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public (List<double>, List<double>, List<float>) GetWeekStaistics()
        {
            try
            {
                return patientDL.GetWeekStaistics();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public (List<double>, List<double>) GetGenderStatistics()
        {
            try
            {
                return patientDL.GetGenderStatistics();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        public (List<double>, List<double>, List<float>, List<double>, List<double>) GetChartsData()
        {
            try
            {
                return patientDL.GetChartsData();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
