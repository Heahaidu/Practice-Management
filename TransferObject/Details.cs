using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Details
    {
        [Browsable(false)]
        public int Id { get; set; }

        // Mã thuốc
        [Display(Name = "Mã thuốc")]
        public int MedicineId { get; set; }

        // Mã đơn thuốc
        [Browsable(false)]
        public int PrescriptionId { get; set; }

        // Thuốc
        [Display(Name = "Thuốc")]
        public Medicine Medicine { get; set; }

        // Số lượng
        [Display(Name = "Số lượng")]
        public int Quantity { get; set; }

        // Số ngày dùng
        [Display(Name = "Số ngày dùng")]
        public int DaysUse { get; set; }

        // Số lượng sử dụng buổi sáng
        [Display(Name = "Số lượng sử dụng buổi sáng")]
        public int Morning { get; set; }

        // Số lượng sử dụng buổi trưa
        [Display(Name = "Số lượng sử dụng buổi trưa")]
        public int Noon { get; set; }

        // Số lượng sử dụng buổi tối
        [Display(Name = "Số lượng sử dụng buổi tối")]
        public int Evening { get; set; }

        public Details()
        {
            Medicine = new Medicine();
        }

        public Details(int id, int medicineId, int prescriptionId, int quantity, int daysUse, int morning, int noon, int evening, Medicine medicine)
        {
            Id = id;
            MedicineId = medicineId;
            PrescriptionId = prescriptionId;
            Quantity = quantity;
            DaysUse = daysUse;
            Morning = morning;
            Noon = noon;
            Evening = evening;
            Medicine = medicine ?? new Medicine();
        }

        public Details(int medicineId, int prescriptionId, int quantity, int daysUse, int morning, int noon, int evening, Medicine medicine)
        {
            MedicineId = medicineId;
            PrescriptionId = prescriptionId;
            Quantity = quantity;
            DaysUse = daysUse;
            Morning = morning;
            Noon = noon;
            Evening = evening;
            Medicine = medicine ?? new Medicine();
        }
    }
}