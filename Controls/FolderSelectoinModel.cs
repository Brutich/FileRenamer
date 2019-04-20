using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    public class FolderSelectoinModel : INotifyPropertyChanged
    {
        IFileService fileService;
        IDialogService dialogService;

        private string _folderPath;
        public string FolderPath
        {
            get { return _folderPath; }
            set
            {
                _folderPath = value;
                OnPropertyChanged();
            }
        }

        // команда открытия директории
        private RelayCommand browseCommand;
        public RelayCommand BrowseCommand
        {
            get
            {
                return browseCommand ??
                  (browseCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFolderDialog() == true)
                          {
                              FolderPath = dialogService.FolderPath;
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public FolderSelectoinModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            // данные по умлолчанию
            _folderPath = "This is the default value";
        }

        public FolderSelectoinModel()
        {
            // данные по умлолчанию
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
