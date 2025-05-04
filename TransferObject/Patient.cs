using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransferObject
{
    // System.ComponentModel.DataAnnotations
    public class Patient
    {

        // ID
        public int id { get; set; }
        // Tên bệnh nhân
        [Display(Name = "Họ tên")]
        public string name { get; set; }
        // Ngày sinh
        [Display(Name = "Ngày sinh")]
        public DateTime dob { get; set; }
        // Giới tính
        [Display(Name = "Giới tính")]
        public Gender gender { get; set; }
        // Địa chỉ
        [Display(Name = "Địa chỉ")]
        public string address { get; set; }
        // Số điện thoại
        [Display(Name = "Số điện thoại")]
        public string phone { get; set; }
        // Email
        [Display(Name = "Email")]
        public string email { get; set; }
        // Mã bảo hiểm y tế
        [Display(Name = "Mã bảo hiểm y tế")]
        public string healthInsuranceId { get; set; }
        // CMND/CCCD
        [Display(Name = "CMND/CCCD")]
        public string idCard { get; set; }
        // Tiền căn
        [Display(Name = "Tiền căn")]
        public string medicalHistory { get; set; }

        public Patient(int id, string name, DateTime dob, Gender gender, string address, string phone, string email, string healthInsuranceId, string idCard, string medicalHistory)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
            this.gender = gender;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.healthInsuranceId = healthInsuranceId;
            this.idCard = idCard;
            this.medicalHistory = medicalHistory;
        }

        public Patient(string name, DateTime dob, Gender gender, string address, string phone, string email, string healthInsuranceId, string idCard, string medicalHistory)
        {
            this.name = name;
            this.dob = dob;
            this.gender = gender;
            this.address = address;
            this.phone = phone;
            this.email = email;
            this.healthInsuranceId = healthInsuranceId;
            this.idCard = idCard;
            this.medicalHistory = medicalHistory;
        }

        public Patient(int id, string name, DateTime dob, Gender gender, string address, string phone, string idCard, string medicalHistory)
        {
            this.id = id;
            this.name = name;
            this.dob = dob;
            this.gender = gender;
            this.address = address;
            this.phone = phone;
            this.idCard = idCard;
            this.medicalHistory = medicalHistory;
        }

        public override string ToString()
        {
            return String.Format("ID: {0} Name: {1} Dob: {2} Gender: {3} Address: {4} Phone: {5} Email: {6} HealthInsuranceId: {7} IdCard: {8} MedicalHistory",
                                    id, name, dob.ToString(), gender, address, phone, email, healthInsuranceId, idCard, medicalHistory);
        }

    }
}
