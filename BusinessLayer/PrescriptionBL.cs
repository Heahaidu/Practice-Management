using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

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
    }
}
