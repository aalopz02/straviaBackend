using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace straviaBackend.mist
{
    public class ProcessSaveFiles
    {
        private static string url = "D://OneDrive//Escritorio//imgrepo//";

        public static string saveImg(FileModel inFile, string username) {
            string content = inFile.file;
            //data:image/jpeg;base64, => metadata , indica donde inicia
            string[] decoDiv = content.Split(",");
            string fileType = decoDiv[0].Split("/")[1].Split(";")[0];
            byte[] data = System.Convert.FromBase64String(decoDiv[1]);
            string name = username + "." + fileType;
            try
            {
                using (var fs = new FileStream(url + name, FileMode.Create, FileAccess.Write))
                {
                    fs.Write(data, 0, data.Length);
                    return name;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in process: {0}", ex);
                return null;
            }
        }
    }
}
