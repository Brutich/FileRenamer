using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace FileRenamer
{
    public class JsonFileService : IFileService
    {
        public List<FileNameConvertion> Open(string filename)
        {
            List<FileNameConvertion> phones = new List<FileNameConvertion>();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<FileNameConvertion>));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = jsonFormatter.ReadObject(fs) as List<FileNameConvertion>;
            }

            return phones;
        }

        public void Save(string filename, List<FileNameConvertion> phonesList)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(List<FileNameConvertion>));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, phonesList);
            }
        }
    }
}
