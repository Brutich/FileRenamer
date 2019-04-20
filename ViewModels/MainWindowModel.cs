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
    public class MainWindowModel : INotifyPropertyChanged
    {
        private FileNameConvertion selectedFileNameConvertion;

        IFileService fileService;
        IDialogService dialogService;


        private FolderSelectoinModel folderPathFrom;
        public FolderSelectoinModel FolderPathFrom
        {
            get { return folderPathFrom; }
            set { folderPathFrom = value; OnPropertyChanged(); }
        }
        
        private FolderSelectoinModel folderPathTo;
        public FolderSelectoinModel FolderPathTo
        {
            get { return folderPathTo; }
            set { folderPathTo = value; OnPropertyChanged(); }
        }


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


        // команда выполнения
        private RelayCommand runCommand;
        public RelayCommand RunCommand
        {
            get
            {
                return runCommand ??
                  (runCommand = new RelayCommand(obj =>
                  {
                      dialogService.ShowMessage("Переименование выполнено из " + folderPathFrom.FolderPath + "\nв " + folderPathTo.FolderPath);
                  },
                  (obj) => true));
            }
        }


        public MainWindowModel(IDialogService dialogService, IFileService fileService)
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

            FolderPathFrom = new FolderSelectoinModel(dialogService, fileService);
            FolderPathTo = new FolderSelectoinModel(dialogService, fileService);

        }

        public MainWindowModel()
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
