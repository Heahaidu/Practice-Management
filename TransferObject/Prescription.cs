using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TransferObject
{
    public class Prescription
    {
        // Thuốc
        [Display(Name = "Thuốc")]
        public Medicine medicine { get; set; }

        // Số lượng
        [Display(Name = "Số lượng")]
        public int quantity { get; set; }
        // Số ngày dùng
        [Display(Name = "Số ngày dùng")]
        public int days { get; set; }
        // Số lượng sử dụng buổi sáng
        [Display(Name = "Số lượng sử dụng buổi sáng")]
        public int morning { get; set; }
        // Số lượng sử dụng buổi trưa
        [Display(Name = "Số lượng sử dụng buổi trưa")]
        public int noon { get; set; }
        // Số lượng sử dụng buổi tối
        [Display(Name = "Số lượng sử dụng buổi tối")]
        public int evening { get; set; }

    }
}
