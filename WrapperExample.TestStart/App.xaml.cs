using System.Windows;
using WrapperExample.TestData;

namespace WrapperExample.TestStart
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var testService = new TestService();
            var script = new Script.Script(testService);
            script.Start();
        }
    }
}
