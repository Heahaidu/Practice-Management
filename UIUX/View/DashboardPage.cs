using Bunifu.Charts.WinForms;
using Bunifu.Charts.WinForms.ChartTypes;
using Bunifu.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;
using TransferObject;

namespace UIUX.View
{
    public partial class DashboardPage : Form
    {

        List<double> patientsQuality;
        List<double> newPatientsQuality;
        List<float> totalCost;
        List<double> maleQuality;
        List<double> femaleQuality;

        public DashboardPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            PatientBL patientBL = new PatientBL();
            (int patientQuality, int newPatientQuality, int prescriptionQuality, int indicationQuality, int examinationQuality)  = patientBL.GetDashboardData();
            lbPatient.Text = patientQuality.ToString() ?? "--";
            lbNewPatient.Text = newPatientQuality.ToString() ?? "--";
            lbPrescription.Text = prescriptionQuality.ToString() ?? "--";
            lbIndication.Text = indicationQuality.ToString() ?? "--";
            lbExamination.Text = examinationQuality.ToString() ?? "--";

            //() = patientBL.GetWeekStaistics();
            (patientsQuality, newPatientsQuality, totalCost, maleQuality, femaleQuality) = patientBL.GetChartsData();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            List<double> gender = new List<double>();
            List<double> age = new List<double>();
            for (int i = 0; i < maleQuality.Count; i++)
            {
                Console.WriteLine(maleQuality[i]);
                gender.Add(maleQuality[i]);
                gender.Add(femaleQuality[i]);
                age.Add(maleQuality[i] + femaleQuality[i]);
            }
            doughnutAge.TargetCanvas = bunifuChartCanvas2;
            doughnutAge.Data = age;
            doughnutGender.TargetCanvas = bunifuChartCanvas2;
            doughnutGender.Data = gender;

            doughnutGender.BackgroundColor = new List<Color>()
            {
                Color.FromArgb(241,91,181),
                Color.FromArgb(174,114,238),
                Color.FromArgb(241,91,181),
                Color.FromArgb(174,114,238),
                Color.FromArgb(241,91,181),
                Color.FromArgb(174,114,238),
                Color.FromArgb(241,91,181),
                Color.FromArgb(174,114,238),
                Color.FromArgb(241,91,181),
                Color.FromArgb(174,114,238),
                Color.FromArgb(241,91,181),
                Color.FromArgb(174,114,238),
                Color.FromArgb(241,91,181),
                Color.FromArgb(174,114,238),
            };

            doughnutAge.BackgroundColor = new List<Color>
            {
                Color.FromArgb(0,60,141),
                Color.FromArgb(127,62,156),
                Color.FromArgb(205,58,146),
                Color.FromArgb(255,77,115),
                Color.FromArgb(255,125,76),
                Color.FromArgb(255,184,24),
                Color.FromArgb(249,243,0),
            };
        }

        private void bunifuChartCanvas1_Load(object sender, EventArgs e)
        {
            bunifuChartCanvas1.Labels = new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            bunifuChartCanvas1.AnimationDuration = 1000;

            bunifuBarChart1.TargetCanvas = bunifuChartCanvas1;
            bunifuBarChart1.Label = "Bệnh nhân mới";
            bunifuBarChart1.Data = newPatientsQuality;
            bunifuBarChart1.BorderWidth = 2;
            bunifuBarChart1.BackgroundColor = new List<Color>()
            {
                Color.FromArgb(0, 163, 137),
                Color.FromArgb(0, 163, 137),
                Color.FromArgb(0, 163, 137),
                Color.FromArgb(0, 163, 137),
                Color.FromArgb(0, 163, 137),
                Color.FromArgb(0, 163, 137),
                Color.FromArgb(0, 163, 137)
            };

            bunifuBarChart2.TargetCanvas = bunifuChartCanvas1;
            bunifuBarChart2.Label = "Số bệnh nhân";
            bunifuBarChart2.Data = newPatientsQuality;
            bunifuBarChart2.BackgroundColor = new List<Color>()
            {
                Color.FromArgb(170, 84, 218),
                Color.FromArgb(170, 84, 218),
                Color.FromArgb(170, 84, 218),
                Color.FromArgb(170, 84, 218),
                Color.FromArgb(170, 84, 218),
                Color.FromArgb(170, 84, 218),
                Color.FromArgb(170, 84, 218)
            };
        }

        private void bunifuChartCanvas3_Load(object sender, EventArgs e)
        {
            bunifuChartCanvas3.Labels = new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            bunifuChartCanvas3.AnimationDuration = 1000;
            bunifuLineChart1.TargetCanvas = bunifuChartCanvas3;
            bunifuLineChart1.Data = totalCost.ConvertAll(x => (double)x);
        }
    }

}
