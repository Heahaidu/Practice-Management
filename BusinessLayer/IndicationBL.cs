using DataLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransferObject;

namespace BusinessLayer
{
    public class IndicationBL
    {
        private IndicationDL IndicationDL;

        public IndicationBL()
        {
            IndicationDL = new IndicationDL();
        }

        public ObservableCollection<Indication> GetIndications(int patientId)
        {
            try
            {
                return IndicationDL.GetIndications(patientId);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Add(Indication indication, int patientId)
        {
            try
            {
                return IndicationDL.Add(indication, patientId);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Delete(int id)
        {
            try
            {
                return IndicationDL.Delete(id);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int GetTotalIndications()
        {
            try
            {
                return IndicationDL.GetTotalIndication();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int AddTestsScription(Indication indication, List<MedicineTestPrescription> medicineTestPrescriptions)
        {
            try
            {
                foreach (MedicineTestPrescription medicineTestPrescription in medicineTestPrescriptions)
                {
                    new IndicationDL().AddTestsScription(indication.Id, medicineTestPrescription);
                }
            } catch (SqlException ex)
            {
                Console.WriteLine(ex);
                return 0;
            }
            return 1;
        }

        public List<MedicineTestPrescription> GetTestsPrescription(int id)
        {
            return new IndicationDL().GetTestsPrescription(id);
        }
    }
}