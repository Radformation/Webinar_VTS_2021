using WrapperExample.TpsService;

namespace WrapperExample.Script
{
    public class Script
    {
        private readonly ITpsService tps;

        public Script(ITpsService tpsService)
        {
            tps = tpsService;
        }

        public void Start()
        {
            var mainWindow = new MainWindow();
            mainWindow.Initialize(tps.Patient, tps.Plan);
            mainWindow.Show();
        }
    }
}


