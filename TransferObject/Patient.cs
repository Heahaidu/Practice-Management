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
        [Display(Name = "ID")]
        public int id { get; set; }
        // Tên bệnh nhân
        [Display(Name = "Họ tên")]
        public string name { get; set; }
        // Ngày sinh
        [Display(Name = "Ngày sinh")]
        public DateTime dob { get; set; }
        // Giới tính
        [Display(Name = "Giới tính")]
        public Gender Gender { get; set; }
        // Địa chỉ
        [Display(Name = "Địa chỉ")]
        public string address { get; set; }
        // Số điện thoại
        [Display(Name = "Số điện thoại")]
        public string phone { get; set; }
        // Email
        [Display(Name = "Email")]
        public string email { get; set; }
        // Bảo hiểm y tế
        [Display(Name = "Bảo hiểm y tế")]
        public string healthInsurance { get; set; }
        // CMND/CCCD
        [Display(Name = "CMND/CCCD")]
        public string idCard { get; set; }
        // Tiền căn
        [Display(Name = "Tiền căn")]
        public float roomFee { get; set; }
    }
}
