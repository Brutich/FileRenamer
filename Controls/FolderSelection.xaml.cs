using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
using WinForms = System.Windows.Forms;

namespace FileRenamer.Controls
{
    /// <summary>
    /// Interaction logic for FolderSelection.xaml
    /// </summary>
    public partial class FolderSelection : UserControl
    {
        public FolderSelection()
        {
            InitializeComponent();
        }

        public string FolderPath { get; set; }

        private void OpenFolderDialog(object sender, RoutedEventArgs e)
        {
            WinForms.FolderBrowserDialog folderDialog = new WinForms.FolderBrowserDialog();
            folderDialog.ShowNewFolderButton = false;
            folderDialog.SelectedPath = AppDomain.CurrentDomain.BaseDirectory;
            WinForms.DialogResult result = folderDialog.ShowDialog();

            if(result == WinForms.DialogResult.OK)
            {
                this.FolderPath = folderDialog.SelectedPath;
            }
        }
    }



    /* WIP

    class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private int _Clicks;

        public int Clicks
        {
            get { return _Clicks; }

            set
            {
                _Clicks = value;
                OnPropertyChanged();
            }
        }


        public DelegateCommand ClickAdd
        {
            get
            {
                return new DelegateCommand((obj) => { Clicks++; }, (obj) => Clicks < 10);
            }

        }

    }

    class DelegateCommand : ICommand
    {


        private Action<object> execute;

        private Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return this.canExecute == null || this.canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }

    */
}
