using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransferObject
{
    public class Indication
    {
        [Browsable(false)]
        public int Id { get; set; }

        // Ngày chỉ định
        [Display(Name = "Ngày chỉ định")]
        public DateTime IndicationDate { get; set; }

        // Loại chỉ định
        [Display(Name = "Loại chỉ định")]
        public string IndicationType { get; set; }

        // B.sĩ chỉ định
        [Display(Name = "B.sĩ chỉ định")]
        public string DoctorName { get; set; }

        // Chuẩn đoán
        [Display(Name = "Tên chuẩn đoán")]
        public string DiagnosisName { get; set; }

        // Ghi chú
        [Display(Name = "Ghi chú")]
        public string Notes { get; set; }

        // Mã bệnh nhân
        [Display(Name = "Mã bệnh nhân")]
        public int PatientId { get; set; }

        // Mã bác sĩ
        [Display(Name = "Mã bác sĩ")]
        public int DoctorId { get; set; }


        public Indication(DateTime indicationDate, string indicationType, string doctorName, string diagnosisName, string notes, int patientId, int doctorId)
        {
            this.IndicationDate = indicationDate;
            this.IndicationType = indicationType;
            this.DoctorName = doctorName;
            this.DiagnosisName = diagnosisName;
            this.Notes = notes;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
        }

        public Indication(int id, DateTime indicationDate, string indicationType, string doctorName, string diagnosisName, string notes, int patientId, int doctorId)
        {
            this.Id = id;
            this.IndicationDate = indicationDate;
            this.IndicationType = indicationType;
            this.DoctorName = doctorName;
            this.DiagnosisName = diagnosisName;
            this.Notes = notes;
            this.PatientId = patientId;
            this.DoctorId = doctorId;
        }
    }
}