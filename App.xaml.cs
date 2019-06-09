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
        static void Main(String[] args)
        {

            App app = new App();
            MainWindow window = new MainWindow();
            MainWindowModel mainViewModel = new MainWindowModel(new DefaultDialogService(), new JsonFileService());
            // WIP
            //mainViewModel.RequestClose += delegate { window.Close(); };

            if (args.Count() > 0)
            {
                string fileNamePassedIn = args[0];
                DataObject dataObject = mainViewModel.fileService.Open(fileNamePassedIn);
                mainViewModel.FolderPathTo.FolderPath = dataObject.PathTo;
                mainViewModel.FolderPathFrom.FolderPath = dataObject.PathFrom;
                List<FileNameConvertion> nameConvertions = dataObject.NameConvertions;
                mainViewModel.NameConvertions.Clear();
                foreach (var c in nameConvertions)
                    mainViewModel.NameConvertions.Add(c);
            }

            window.DataContext = mainViewModel;
            window.folderFrom.DataContext = mainViewModel.FolderPathFrom;
            window.folderTo.DataContext = mainViewModel.FolderPathTo;
            app.Run(window);

        }
    }
}
