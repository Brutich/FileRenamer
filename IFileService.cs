using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    public interface IFileService
    {
        List<FileNameConvertion> Open(string filename);
        void Save(string filename, DataObject dataObject);        
    }
}
