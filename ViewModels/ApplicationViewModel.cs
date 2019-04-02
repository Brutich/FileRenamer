using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace FileRenamer
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private FileNameConvertion selectedFileNameConvertion;
        public ObservableCollection<FileNameConvertion> NameConvertions { get; set; }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      FileNameConvertion convertion = new FileNameConvertion();
                      NameConvertions.Insert(0, convertion);
                      SelectedFileNameConvertion = convertion;
                  }));
            }
        }


        // команда удаления
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      FileNameConvertion convertion = obj as FileNameConvertion;
                      if (convertion != null)
                      {
                          NameConvertions.Remove(convertion);
                      }
                  },
                 (obj) => NameConvertions.Count > 0));
            }
        }
        
        public FileNameConvertion SelectedFileNameConvertion
        {
            get { return selectedFileNameConvertion; }
            set
            {
                selectedFileNameConvertion = value;
                OnPropertyChanged("SelectedFileNameConvertion");
            }
        }

        public ApplicationViewModel()
        {
            NameConvertions = new ObservableCollection<FileNameConvertion>
            {
                new FileNameConvertion { NameOld="iPhone 7", NameNew="Apple" },
                new FileNameConvertion { NameOld="Galaxy S7 Edge", NameNew="Samsung" },
                new FileNameConvertion { NameOld="Elite x3", NameNew="HP" },
                new FileNameConvertion { NameOld="Mi5S", NameNew="Xiaomi" },
                new FileNameConvertion { NameOld="iPhone X", NameNew="Apple" }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
