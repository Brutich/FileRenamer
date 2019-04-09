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
            DataContext = new FolderSelectoinModel(new DefaultDialogService(), new JsonFileService());
        }

    }

}
