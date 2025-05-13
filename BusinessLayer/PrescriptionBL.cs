using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using TransferObject;

namespace BusinessLayer
{
    public class PrescriptionBL
    {
        private PrescriptionDL prescriptionDL;

        public PrescriptionBL()
        {
            prescriptionDL = new PrescriptionDL();
        }

        public int GetTotalPrescriptionsToday()
        {
            return prescriptionDL.GetTotalPrescriptionsToday();
        }

        public string GetMedicineName(Prescription prescription, List<Medicine> medicines) {
            Console.WriteLine("Name: " + prescription.MedicineId + ";");
            foreach(Medicine m in medicines)
            {
                Console.WriteLine(m.id + " ", m.name);
            }
            return medicines.Where(m => m.id == prescription.MedicineId).FirstOrDefault().name ?? "Error";
        }

        public string GetTechnicalName(MedicineTestPrescription prescription, List<TechnicalCatalog> technicalCatalogs)
        {
            return technicalCatalogs.Where(t => t.id == prescription.TechnicalCatalogId).FirstOrDefault().name ?? "Error";
        }

        public string MedicinesBill(List<Prescription> prescriptions, List<Medicine> medicines, bool isHealthInsuranceId = false)
        {
            float cost = 0;
            foreach (Prescription m in prescriptions)
            {
                cost += (m.Moring + m.Noon + m.Evening) * m.DateUses * (
                    isHealthInsuranceId ?
                    medicines.Where(medicine => medicine.id == m.MedicineId).FirstOrDefault().discountPrice :
                    medicines.Where(medicine => medicine.id == m.MedicineId).FirstOrDefault().price
                    );
            }
            Console.WriteLine( cost );
            return $"{cost:#,##0}";
        }

        public string TechnicalBill(List<MedicineTestPrescription> prescriptions, List<TechnicalCatalog> technicalCatalogs, bool isHealthInsuranceId = false)
        {
            float cost = 0;
            foreach (MedicineTestPrescription m in prescriptions)
            {
                cost += m.quanlity * (
                    isHealthInsuranceId? 
                    technicalCatalogs.Where(technicalCatalog => technicalCatalog.id == m.TechnicalCatalogId).FirstOrDefault().discountPrice:
                    technicalCatalogs.Where(technicalCatalog => technicalCatalog.id == m.TechnicalCatalogId).FirstOrDefault().price
                    );
            }
            return $"{cost:#,##0}";
        }
    }
}
