using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace FileRenamer
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        App()
        {
            InitializeComponent();
        }

        [STAThread]
        static void Main()
        {
            App app = new App();
            MainWindow window = new MainWindow();
            app.Run(window);
        }

        /*
        protected override void OnStartup(StartupEventArgs e)
        {
            // Check if this was launched by double-clicking a doc. If so, use that as the
            // startup file name.
            if (AppDomain.CurrentDomain.SetupInformation
                .ActivationArguments.ActivationData != null
            && AppDomain.CurrentDomain.SetupInformation
                .ActivationArguments.ActivationData.Length > 0)
            {
                string fname = "No filename given";
                try
                {
                    fname = AppDomain.CurrentDomain.SetupInformation
                            .ActivationArguments.ActivationData[0];

                    // It comes in as a URI; this helps to convert it to a path.
                    Uri uri = new Uri(fname);
                    fname = uri.LocalPath;

                    this.Properties["FolderPathFrom"] = fname;
                    
                }
                catch (Exception ex)
                {
                    // For some reason, this couldn't be read as a URI.
                    // Do what you must...
                }
            }

            base.OnStartup(e);
        }
        */
    }
}
