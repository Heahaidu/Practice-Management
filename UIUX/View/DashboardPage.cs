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

namespace UIUX.View
{
    public partial class DashboardPage : Form
    {
        public DashboardPage()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            lbPatient.Text = new PatientBL().GetTotalPatients().ToString();
            lbNewPatient.Text = new PatientBL().GetPatientsCreatedToday().ToString();
            lbPrescription.Text = new PrescriptionBL().GetTotalPrescriptionsToday().ToString();
            lbIndication.Text = new IndicationBL().GetTotalIndications().ToString();
        }

        private void DashForm_Load(object sender, EventArgs e)
        {
            bunifuChartCanvas1.Labels = new[] { "T2", "T3", "T4", "T5", "T6", "T7", "CN" };
            bunifuChartCanvas1.AnimationDuration = 1000;

            bunifuBarChart1.TargetCanvas = bunifuChartCanvas1;
            bunifuBarChart1.Label = "Bệnh nhân mới";
            bunifuBarChart1.Data = new List<double> { 20, 25, 30, 35, 40, 50, 45 };
            bunifuBarChart1.BorderWidth = 2;
            bunifuBarChart1.BackgroundColor = new List<Color>() {
                Color.FromArgb(0,163,137),
                Color.FromArgb(0,163,137),
                Color.FromArgb(0,163,137),
                Color.FromArgb(0,163,137),
                Color.FromArgb(0,163,137),
                Color.FromArgb(0,163,137),
                Color.FromArgb(0,163,137)
            };

            bunifuBarChart2.TargetCanvas = bunifuChartCanvas1;
            bunifuBarChart2.Label = "Tổng số bệnh nhân";
            bunifuBarChart2.Data = new List<double> {
                100, 
                120,
                145,
                175,
                210,
                260,
                300 
            };
            bunifuBarChart2.BackgroundColor = new List<Color>() {
                Color.FromArgb(170,84,218), 
                Color.FromArgb(170,84,218), 
                Color.FromArgb(170,84,218), 
                Color.FromArgb(170,84,218), 
                Color.FromArgb(170,84,218), 
                Color.FromArgb(170,84,218), 
                Color.FromArgb(170,84,218)
            };

            // Cấu hình nhãn trục Y phụ
            //lblYAuxiliary.Text = "Tổng số khách";
            //lblYAuxiliary.Font = new Font("Segoe UI", 10);
            //lblYAuxiliary.ForeColor = Color.Black;
            //lblYAuxiliary.Location = new Point(bunifuChartCanvas1.Location.X + bunifuChartCanvas1.Width + 10, bunifuChartCanvas1.Location.Y);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }

}
