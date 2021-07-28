using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using VMS.TPS.Common.Model.API;
using VMS.TPS.Common.Model.Types;
using WrapperExample.TpsService;
using Patient = WrapperExample.TpsService.Patient;

namespace WrapperExample.Esapi
{
    public class EsapiService : ITpsService
    {
        private VMS.TPS.Common.Model.API.Application app;
        private VMS.TPS.Common.Model.API.Patient esapiPatient;
        private VMS.TPS.Common.Model.API.PlanSetup esapiPlan;

        public Patient Patient { get; private set; }
        public Plan Plan { get; private set; }

#if ESAPI_136
        public void LogIn(string username, string password)
        {
            app = Application.CreateApplication(username, password);
        }
#endif

#if ESAPI_155
        public void LogIn()
        {
            app = Application.CreateApplication();
        }
#endif

        public void LogOut()
        {
            app.Dispose();
        }

        public void OpenPatient(string patientId)
        {
            esapiPatient = app.OpenPatientById(patientId);

            if (esapiPatient != null)
            {
                Patient = new Patient
                {
                    Id = esapiPatient.Id,
                    FirstName = esapiPatient.FirstName,
                    LastName = esapiPatient.LastName
                };
            }
        }

        public void OpenPlan(string courseId, string planId)
        {
            esapiPlan = esapiPatient
                .Courses.FirstOrDefault(c => c.Id == courseId)?
                .PlanSetups.FirstOrDefault(p => p.Id == planId);

            if (esapiPlan != null)
            {
                Plan = new Plan
                {
                    Id = esapiPlan.Id,
#if ESAPI_136
                    Fractions = esapiPlan.UniqueFractionation?.NumberOfFractions.GetValueOrDefault() ?? 0,
                    DosePerFractionGy = esapiPlan.UniqueFractionation?.PrescribedDosePerFraction.Dose ?? 0,
#elif ESAPI_155
                    Fractions = esapiPlan.NumberOfFractions.GetValueOrDefault(),
                    DosePerFractionGy = esapiPlan.DosePerFraction.Dose
#endif
                };
            }
        }
    }
}
