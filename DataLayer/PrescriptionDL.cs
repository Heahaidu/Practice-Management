using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DataLayer
{
    public  class PrescriptionDL:DataProvider
    {
        public int GetTotalPrescriptionsToday()
        {
            try {
                string sql = "SELECT COUNT(*) FROM Prescription WHERE CAST(createDate AS DATE) = CAST(GETDATE() AS DATE)";
                object result = MyExecuteScalar(sql, CommandType.Text);

                return Convert.ToInt32(result);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
