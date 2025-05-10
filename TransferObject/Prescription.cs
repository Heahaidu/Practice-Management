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
        public int Id { get; set; }

        // Tổng giá
        [Display(Name = "Tổng giá")]
        public double TotalPrice { get; set; }

        // Mã bác sĩ
        [Display(Name = "Mã bác sĩ")]
        public int DoctorId { get; set; }

        // Danh sách chi tiết đơn thuốc
        [Display(Name = "Chi tiết đơn thuốc")]
        public List<Details> PrescriptionDetails { get; set; }

        public Prescription()
        {
            PrescriptionDetails = new List<Details>();
        }

        public Prescription(int id, double totalPrice, int doctorId, List<Details> prescriptionDetails)
        {
            Id = id;
            TotalPrice = totalPrice;
            DoctorId = doctorId;
            PrescriptionDetails = prescriptionDetails ?? new List<Details>();
        }

        public Prescription(double totalPrice, int doctorId, List<Details> prescriptionDetails)
        {
            TotalPrice = totalPrice;
            DoctorId = doctorId;
            PrescriptionDetails = prescriptionDetails ?? new List<Details>();
        }
    }
}