using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    interface IFileService
    {
        List<FileNameConvertion> Open(string filename);
        void Save(string filename, List<FileNameConvertion> phonesList);        
    }
}
