using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InsMgr3.Model.Helpers
{
    public static class Serializer
    {
        public static T Deserialize<T>(string json) => JsonConvert.DeserializeObject<T>(json);

        public static T Deserialize<T>(FileInfo file)
        {
            if (file.Exists)
            {
                var json = File.ReadAllText(file.FullName);
                return Deserialize<T>(json);
            }

            return default(T);
        }

        public static string Serialize<T>(T obj) => JsonConvert.SerializeObject(obj);

        public static void Serialize<T>(T obj, FileInfo file)
        {
            if (obj != null)
            {
                if (!Directory.Exists(file.DirectoryName))
                    Directory.CreateDirectory(file.DirectoryName);

                using (StreamWriter sw = file.CreateText())
                {
                    var json = Serialize(obj);

                    sw.Write(json);
                }
            }
        }
    }
}