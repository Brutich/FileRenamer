using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    class FolderSelectoinModel : INotifyPropertyChanged
    {
        IFileService fileService;
        IDialogService dialogService;

        public string FolderPath { get; set; }


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
                              FolderPath = dialogService.FilePath;
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public FolderSelectoinModel(DefaultDialogService dialogService, JsonFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            // данные по умлолчанию
            FolderPath = "This is the default value";
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
