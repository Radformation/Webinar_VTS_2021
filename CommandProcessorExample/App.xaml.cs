using System.Windows;
using CommandProcessorExample.Models;
using CommandProcessorExample.ViewModels;
using CommandProcessorExample.Views;

namespace CommandProcessorExample
{
    public partial class App : Application
    {
        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            var mainModel = LoadMainModel();

            // Create and initialize main view model
            var mainViewModel = new MainViewModel();
            mainViewModel.Initialize(mainModel);

            // Create and initialize main window
            var mainWindow = new MainWindow();
            mainWindow.DataContext = mainViewModel;

            mainWindow.Show();
        }

        // Create dummy model with random names (http://random-name-generator.info)
        private MainModel LoadMainModel()
        {
            var mainModel = new MainModel();
            mainModel.Patients.Add(new Patient {FirstName = "Roman", LastName = "Curtis"});
            mainModel.Patients.Add(new Patient {FirstName = "Beatrice", LastName = "Burke"});
            mainModel.Patients.Add(new Patient {FirstName = "Renee", LastName = "Hart"});
            mainModel.Patients.Add(new Patient {FirstName = "Boyd", LastName = "Brady"});
            mainModel.Patients.Add(new Patient {FirstName = "Eula", LastName = "Payne"});
            mainModel.Patients.Add(new Patient {FirstName = "Lonnie", LastName = "Warner"});
            mainModel.Patients.Add(new Patient {FirstName = "Vickie", LastName = "Torres"});
            mainModel.Patients.Add(new Patient {FirstName = "Gertrude", LastName = "Lynch"});
            mainModel.Patients.Add(new Patient {FirstName = "Grant", LastName = "Copeland"});
            mainModel.Patients.Add(new Patient {FirstName = "Brad", LastName = "Hunt"});
            return mainModel;
        }
    }
}
