using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace FileRenamer
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainWindowModel mainViewModel = new MainWindowModel(new DefaultDialogService(), new JsonFileService());

            DataContext = mainViewModel;
            folderFrom.DataContext = mainViewModel.FolderPathFrom;
            folderTo.DataContext = mainViewModel.FolderPathTo;
        }
    }
}
