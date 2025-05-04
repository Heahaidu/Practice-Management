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

        public int Add(Medicine medicine) { 
            return medicineDL.Add(medicine);
        }
    }
}
