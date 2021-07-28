using System.Windows;
using WrapperExample.Esapi;

namespace WrapperExample.EsapiStart
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var esapiService = new EsapiService();
#if ESAPI_136
            esapiService.LogIn("SysAdmin", "SysAdmin");
#elif ESAPI_155
            esapiService.LogIn();
#endif
            esapiService.OpenPatient("123456789");
            esapiService.OpenPlan("Course", "Plan");

            var script = new Script.Script(esapiService);
            script.Start();
        }
    }
}
