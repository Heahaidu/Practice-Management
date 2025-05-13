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
    public class MedicineBL
    {
        private MedicineDL medicineDL;

        public MedicineBL()
        {
            medicineDL = new MedicineDL();
        }

        public ObservableCollection<Medicine> GetMedicines()
        {
            try
            {
                return (medicineDL.GetMedicines());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public List<Medicine> GetMedicines(List<Prescription> prescriptions)
        {
            List<Medicine> medicines = new List<Medicine>();
            ObservableCollection<Medicine> medicines_ = medicineDL.GetMedicines(true);
            foreach (var prescription in prescriptions)
            {
                var medicine = medicines_.FirstOrDefault(m => m.id == prescription.MedicineId);
                if (medicine != null)
                {
                    medicines.Add(medicine);
                }
            }
            return medicines;
        }

        public int Add(Medicine medicine) { 
            return medicineDL.Add(medicine);
        }

        public int Delete(int id)
        {
            return medicineDL.Delete(id);
        }

        public bool MedicineUpdate(Medicine medicine)
        {
            return medicineDL.Update(medicine) == 1;
        }

    }
}
