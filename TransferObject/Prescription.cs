using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Prescription
    {
        public int MedicineId { get; set; }
        public int DateUses { get; set; }

        public int Moring { get; set; }
        public int Noon { get; set; }
        public int Evening { get; set; }

        public string Description { get; set; }

        public Prescription(int medicineId, int dateUses, int moring, int noon, int evening, string description)
        {
            MedicineId = medicineId;
            DateUses = dateUses;
            Moring = moring;
            Noon = noon;
            Evening = evening;
            Description = description;
        }
    }
}