using straviaBackend.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace straviaBackend.mist
{
    public class ProcessSaveFiles
    {
        private static string urlimg = "D://OneDrive//Escritorio//dbstrava//imgrepo//";
        private static string urlrutas = "D://OneDrive//Escritorio//dbstrava//reporutas//";
        private static string urlrutascarreras = "D://OneDrive//Escritorio//dbstrava//reporutascarreras//";
        private static string urlrecibo = "D://OneDrive//Escritorio//dbstrava//reporecibos//";

        public static string SaveRecibo(FileModel inFile, string username)
        {

            string content = inFile.file;
            //data:image/jpeg;base64, => metadata , indica donde inicia
            string[] decoDiv = content.Split(",");
            string fileType = decoDiv[0].Split("/")[1].Split(";")[0];
            byte[] data = System.Convert.FromBase64String(decoDiv[1]);
            string name = username + "." + fileType;
            try
            {
                using (var fs = new FileStream(urlrecibo + name, FileMode.Create, FileAccess.Write))
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

        public static string saveImg(FileModel inFile, string username) {

            string content = inFile.file;
            //data:image/jpeg;base64, => metadata , indica donde inicia
            string[] decoDiv = content.Split(",");
            string fileType = decoDiv[0].Split("/")[1].Split(";")[0];
            byte[] data = System.Convert.FromBase64String(decoDiv[1]);
            string name = username + "." + fileType;
            try
            {
                using (var fs = new FileStream(urlimg + name, FileMode.Create, FileAccess.Write))
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

        public static string saveRuta(FileModel inFile, string username, string date)
        {
            string content = inFile.file;
            byte[] data = Encoding.ASCII.GetBytes(content);
            string name = username + date + ".txt";
            try
            {
                using (var fs = new FileStream(urlrutas + name, FileMode.Create, FileAccess.Write))
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

        public static string saveRutaCarrera(FileModel inFile, string nombreCarrera)
        {
            string content = inFile.file;
            byte[] data = Encoding.ASCII.GetBytes(content);
            string name = nombreCarrera + ".txt";
            try
            {
                using (var fs = new FileStream(urlrutascarreras + name, FileMode.Create, FileAccess.Write))
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
