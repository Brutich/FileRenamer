using FileRenamer.MVVP;
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

namespace FileRenamer.ViewModels
{
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
                return new DelegateCommand((obj) => { Clicks++;}, (obj) => Clicks < 10);
            }

        }

    }
}
