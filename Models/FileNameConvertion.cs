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
        private string nameOld;
        private string nameNew;


        public string NameOld
        {
            get { return nameOld; }
            set
            {
                nameOld = value;
                OnPropertyChanged("NameOld");
            }
        }
        public string NameNew
        {
            get { return nameNew; }
            set
            {
                nameNew = value;
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
