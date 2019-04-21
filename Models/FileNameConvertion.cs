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
        private string nameOriginal;
        private string nameModified;
        private bool isCorrect;


        public string NameOriginal
        {
            get { return nameOriginal; }
            set
            {
                nameOriginal = value;
                OnPropertyChanged("NameOriginal");
            }
        }
        public string NameModified
        {
            get { return nameModified; }
            set
            {
                nameModified = value;
                OnPropertyChanged("NameModified");
            }
        }

        public bool IsCorrect
        {
            get { return isCorrect; }
            set
            {
                isCorrect = (nameOriginal != "") | (nameModified != "");
                OnPropertyChanged("IsCorrect");
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
