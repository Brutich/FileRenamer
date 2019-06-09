using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows;

namespace FileRenamer
{
    public class MainWindowModel : INotifyPropertyChanged
    {
        internal IFileService fileService;
        internal IDialogService dialogService;

        public string Version { get; set; }

        private readonly bool IsAllDataCorrect = true;

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

        
        // команда очистки формы
        private RelayCommand newCommand;
        public RelayCommand NewCommand
        {
            get
            {
                return newCommand ??
                  (newCommand = new RelayCommand(obj =>
                  {
                      NameConvertions.Clear();
                      folderPathFrom.FolderPath = "";
                      folderPathTo.FolderPath = "";
                  }));
            }
        }


        // команда сохранения файла
        private RelayCommand saveAsCommand;
        public RelayCommand SaveAsCommand
        {
            get
            {
                return saveAsCommand ??
                  (saveAsCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              DataObject dataObject = new DataObject()
                              {
                                  NameConvertions = this.NameConvertions.ToList(),
                                  PathFrom = folderPathFrom.FolderPath,
                                  PathTo = folderPathTo.FolderPath
                              };
                              fileService.Save(dialogService.FilePath, dataObject);
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
                              DataObject dataObject = fileService.Open(dialogService.FilePath);
                              folderPathTo.FolderPath = dataObject.PathTo;
                              folderPathFrom.FolderPath = dataObject.PathFrom;
                              List<FileNameConvertion> nameConvertions = dataObject.NameConvertions;
                              NameConvertions.Clear();
                              foreach (var c in nameConvertions)
                                  NameConvertions.Add(c);
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
                      if( Core.Execute(folderPathFrom.FolderPath, folderPathTo.FolderPath, NameConvertions) )
                      {
                          dialogService.ShowMessage("Копирование файлов завершено успешно");
                      }
                      else
                      {
                          dialogService.ShowMessage("Копирование файлов завершено c ошибкой");
                      }
                      
                  },
                  (obj) => IsAllDataCorrect));
            }
        }

        // команда отмены
        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                  (cancelCommand = new RelayCommand(obj =>
                  {
                      Window window = (Window)obj;
                      window.Close();
                  },
                  (obj) => true));
            }
        }


        public MainWindowModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            FolderPathFrom = new FolderSelectoinModel(dialogService);
            FolderPathTo = new FolderSelectoinModel(dialogService);

            // данные по умлолчанию
            NameConvertions = new ObservableCollection<FileNameConvertion> { };

            Version = "v1.0.0-beta"; //+ Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        
        public MainWindowModel()
        {
            
            // данные по умлолчанию
            NameConvertions = new ObservableCollection<FileNameConvertion>
            {
                // new FileNameConvertion { NameOriginal="iPhone XS", NameModified="Apple" }
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
