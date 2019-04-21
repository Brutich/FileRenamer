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
        public DataObject Open(string filename)
        {
            DataObject dataObject = new DataObject();
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(DataObject));
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                dataObject = jsonFormatter.ReadObject(fs) as DataObject;
            }

            return dataObject;
        }

        public void Save(string filename, DataObject dataObject)
        {
            DataContractJsonSerializer jsonFormatter =
                new DataContractJsonSerializer(typeof(DataObject));
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                jsonFormatter.WriteObject(fs, dataObject);
            }
        }
    }
}
