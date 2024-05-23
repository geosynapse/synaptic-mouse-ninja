using GeoSynapse.MouseNinja;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GeoSynapse.MouseNinja
{
    public partial class App : Application
    {
        private void App_Startup(object sender, StartupEventArgs e)
        {
            string[] args = e.Args;
            MainWindow mainWindow = new MainWindow(args);
            mainWindow.Show();
        }
    }
}

