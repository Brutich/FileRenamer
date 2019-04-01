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
        private FileNameConvertion _SelectedFileNameConvertion;

        public ObservableCollection<FileNameConvertion> FileNameConvertions { get; set; }

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
                      FileNameConvertions.Insert(0, convertion);
                      SelectedFileNameConvertions = convertion;
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
                          FileNameConvertions.Remove(convertion);
                      }
                  },
                 (obj) => FileNameConvertions.Count > 0));
            }
        }


        public FileNameConvertion SelectedFileNameConvertions
        {
            get { return _SelectedFileNameConvertion; }
            set
            {
                _SelectedFileNameConvertion = value;
                OnPropertyChanged("SelectedFileNameConvertions");
            }
        }

        public ApplicationViewModel()
        {
            FileNameConvertions = new ObservableCollection<FileNameConvertion>
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
