using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InsMgr3.Model.Helpers
{
    public static class SerializationHelper
    {
        public static T Deserialize<T>(string filePath) => Deserialize<T>(new FileInfo(filePath));

        public static T Deserialize<T>(FileInfo file)
        {
            if (file.Exists)
            {
                var json = File.ReadAllText(file.FullName);
                return JsonConvert.DeserializeObject<T>(json);
            }

            return default(T);
        }

        public static void Serialize<T>(T obj, string filePath) => Serialize(obj, new FileInfo(filePath));

        public static void Serialize<T>(T obj, FileInfo file)
        {
            if (obj != null)
            {
                if (!Directory.Exists(file.DirectoryName))
                    Directory.CreateDirectory(file.DirectoryName);

                using (StreamWriter sw = file.CreateText())
                {
                    var json = JsonConvert.SerializeObject(obj);

                    sw.Write(json);
                }
            }
        }
    }
}