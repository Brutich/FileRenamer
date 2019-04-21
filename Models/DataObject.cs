using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FileRenamer
{
    public class DataObject
    {
        public List<FileNameConvertion> NameConvertions;
        public string PathFrom { get; set; }
        public string PathTo { get; set; }

    }
}
