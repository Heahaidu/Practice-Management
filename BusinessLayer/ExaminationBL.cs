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
    public class ExaminationBL
    {
        private ExaminationDL examinationDL;

        public ExaminationBL()
        {
            examinationDL = new ExaminationDL();
        }

        public ObservableCollection<Examination> GetExaminations(int patientId)
        {
            try
            {
                return (examinationDL.GetExaminations(patientId));
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }

        public int Add(Examination examination, int patientId)
        {
                return examinationDL.Add(examination, patientId);
        }
    }
}
