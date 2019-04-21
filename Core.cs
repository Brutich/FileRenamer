using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileRenamer
{
    internal class Core
    {
        internal static bool Execute(string folderPathFrom, string folderPathTo, ObservableCollection<FileNameConvertion> nameConvertions)
        {
            foreach (FileNameConvertion nc in nameConvertions)
            {
                try
                {
                    File.Copy(
                        Path.Combine(folderPathFrom, nc.NameOld), 
                        Path.Combine(folderPathTo, nc.NameNew),
                        true);
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message);
                    return false;
                }
            }
            return true;
        }
    }
}
