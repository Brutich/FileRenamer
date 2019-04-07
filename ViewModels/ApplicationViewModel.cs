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

        IFileService fileService;
        IDialogService dialogService;

        public ObservableCollection<FileNameConvertion> NameConvertions { get; set; }

        
        // команда очистки списка
        private RelayCommand newCommand;
        public RelayCommand NewCommand
        {
            get
            {
                return newCommand ??
                  (newCommand = new RelayCommand(obj =>
                  {
                      NameConvertions.Clear();
                  }));
            }
        }


        // команда сохранения файла
        private RelayCommand saveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return saveCommand ??
                  (saveCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, NameConvertions.ToList());
                              dialogService.ShowMessage("Файл сохранен");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
          
        // команда открытия файла
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                  (openCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var nameConvertions = fileService.Open(dialogService.FilePath);
                              NameConvertions.Clear();
                              foreach (var p in nameConvertions)
                                  NameConvertions.Add(p);
                              dialogService.ShowMessage("Файл открыт");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }
        
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
                      NameConvertions.Add(convertion);
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
                  (obj) => SelectedFileNameConvertion != null));
                 //(obj) => NameConvertions.Count > 0));
            }
        }

        // команда удаления 2
        private RelayCommand removeCommand2;
        public RelayCommand RemoveCommand2
        {
            get
            {
                return removeCommand2 ??
                  (removeCommand2 = new RelayCommand(obj =>
                  {
                      int index = (int)obj;
                      NameConvertions.RemoveAt(index);
                  },
                  (obj) => true));
                //(obj) => NameConvertions.Count > 0));
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


        public ApplicationViewModel(DefaultDialogService dialogService, JsonFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            // данные по умлолчанию
            NameConvertions = new ObservableCollection<FileNameConvertion>
            {
                new FileNameConvertion { NameOld="iPhone 7", NameNew="Apple" },
                new FileNameConvertion { NameOld="Galaxy S7 Edge", NameNew="Samsung" },
                new FileNameConvertion { NameOld="Elite x3", NameNew="HP" },
                new FileNameConvertion { NameOld="Mi5S", NameNew="Xiaomi" },
                new FileNameConvertion { NameOld="iPhone X", NameNew="Apple" }
            };
            
        }

        public ApplicationViewModel()
        {

            // данные по умлолчанию
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
