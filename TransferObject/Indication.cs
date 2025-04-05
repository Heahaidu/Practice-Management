using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Indication
    {
        // Ngày chỉ định
        [Display(Name = "Ngày chỉ định")]
        public DateTime indicationDate { get; set; }
        // Loại chỉ định
        [Display(Name = "Loại chỉ định")]
        public string indicationType { get; set; }
        // B.sĩ chỉ định
        [Display(Name = "B.sĩ chỉ định")]
        public string doctorName { get; set; }
        // Chuẩn đoán
        [Display(Name = "Tên chuẩn đoán")]
        public string diagnosisName { get; set; }
        // Ghi chú
        [Display(Name = "Ghi chú")]
        public string notes { get; set; }

        public Indication(DateTime indicationDate, string indicationType, string doctorName, string diagnosisName, string notes)
        {
            this.indicationDate = indicationDate;
            this.indicationType = indicationType;
            this.doctorName = doctorName;
            this.diagnosisName = diagnosisName;
            this.notes = notes;
        }
    }
}
