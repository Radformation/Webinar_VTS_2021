using System.Windows;
using WrapperExample.TpsService;

namespace WrapperExample.Script
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Initialize(Patient patient, Plan plan)
        {
            PatientTextBlock.Text = $"{patient.FirstName} {patient.LastName} ({patient.Id})";
            PlanTextBlock.Text = plan.Id;
            RxTextBlock.Text = $"{plan.DosePerFractionGy:f1} Gy x {plan.Fractions} fx = {plan.TotalDoseGy} Gy";
        }
    }
}
