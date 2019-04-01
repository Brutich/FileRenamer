using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FileRenamer
{
    public class FileNameConvertion : INotifyPropertyChanged
    {
        private string _NameOld;
        private string _NameNew;


        public string NameOld
        {
            get { return _NameOld; }
            set
            {
                _NameOld = value;
                OnPropertyChanged("NameOld");
            }
        }
        public string NameNew
        {
            get { return _NameNew; }
            set
            {
                _NameNew = value;
                OnPropertyChanged("NameNew");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
