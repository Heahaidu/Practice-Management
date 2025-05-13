using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class MedicineTestPrescription
    {

        public int TechnicalCatalogId { set; get; }
        public int quanlity { set; get; }
        public string note { set; get; }

        public MedicineTestPrescription(int technicalCatalogId, int quanlity, string note)
        {
            TechnicalCatalogId = technicalCatalogId;
            this.quanlity = quanlity;
            this.note = note;
        }
    }
}
