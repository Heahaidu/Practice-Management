using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Examination
    {
        [Browsable(false)]
        public int id { get; set; }
        // Ngày khám
        [Display(Name="Ngày khám")]
        public DateTime ExaminationDate { get; set; }
        // B.Sĩ điều trị
        [Display(Name="B.Sĩ điều trị")]
        public string DoctorName { get; set; }
        // Lịch sử bệnh
        [Display(Name="Lịch sử bệnh")]
        public string MedicalHistory { get; set; }
        // Tên chuẩn đoán
        [Display(Name="Tên chuẩn đoán")]
        public string DiagnosisName { get; set; }
        // Ghi chú
        [Display(Name = "Ghi chú")]
        public string notes { get; set; }
        // Mã bệnh nhân
        [Display(Name ="Mã bệnh nhân")]
        public int patientId {  get; set; }

        public Examination(DateTime examinationDate, string doctorName, string medicalHistory, string diagnosisName, string notes, int patientId)
        {
            this.ExaminationDate = examinationDate;
            this.DoctorName = doctorName;
            this.MedicalHistory = medicalHistory;
            this.DiagnosisName = diagnosisName;
            this.notes = notes;
            this.patientId = patientId;
        }

        public Examination(int id, DateTime examinationDate, string doctorName, string medicalHistory, string diagnosisName, string notes)
        {
            this.id = id;
            this.ExaminationDate = examinationDate;
            this.DoctorName = doctorName;
            this.MedicalHistory = medicalHistory;
            this.DiagnosisName = diagnosisName;
            this.notes = notes;
        }

    }
}
