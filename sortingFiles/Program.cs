using System;
using System.Collections.Generic;          //для работы с листом и словарем
using System.IO;                           //для работы с каталогами

namespace sortingFiles
{
    class sorting
    {
        static string path = @"C:\Users\";                                //путь для создания подпапок
        static string subpath = @"krist\Downloads\";
        static FileInfo[] files;
        public static void Main(string[] args)
        {
            try
            {           
                

                List<string> ImageTypes = new List<string> { ".png", ".jpeg", ".bmp", ".gif" };          //сортировка файлов
                List<string> VideoTypes = new List<string> { ".mp4", ".avi", ".flv", ".wmv" };
                List<string> MusicTypes = new List<string> { ".mp3", ".wav", ".m4a", ".flac" };
                List<string> DocumentTypes = new List<string> { ".doc", ".ppt", ".xls", ".txt", ".pdf" };
                List<string> ArchiveTypes = new List<string> { ".zip", ".rar" };
                List<string> ExeTypes = new List<string> { ".exe" };

                Dictionary< string, List<string> > dict= new Dictionary<string, List<string>>();        //соотношение листов со словарем
                dict.Add("Images" , ImageTypes);
                dict.Add("Videos", VideoTypes);
                dict.Add("Music", MusicTypes);
                dict.Add("Documents", DocumentTypes);
                dict.Add("Archive", ArchiveTypes);
                dict.Add("Exe", ExeTypes);

                
                foreach (var folder in dict)            //создание подпапок
                {
                    var dirInfo = path + subpath + folder.Key;
                    if (!Directory.Exists(dirInfo))
                    {
                        Directory.CreateDirectory(dirInfo);
                    }

                }

                DirectoryInfo downloads = new DirectoryInfo(path + subpath);          //получение расширения файлов
                files = downloads.GetFiles();
                CopyToDir(dict);      

                Console.WriteLine("Ошибок нет");

            }
            catch (Exception ex)                             //поиск ошибок
            {
                Console.Write(ex.ToString());
            }
        }

        //public static FileInfo info;          //информация о файле
        /// <summary>
        /// Перемещение файла в директорию
        /// </summary>
        /// <param name="list">Список расширений</param>
        /// <param name="archive">Имя папки для куда перемещать</param>
        public static void CopyToDir(Dictionary<string, List<string>> dict)
        {
            foreach (var dic in dict)
            {
                foreach (var item in dic.Value)
                {
                    foreach (var file in files)
                    {
                        if (file.Extension == item && !File.Exists(path + subpath + dic.Key + "\\" + file.Name))
                        {
                            file.CopyTo(path + subpath + dic.Key + "\\" + file.Name);
                        }
                    }
                }
            }
            
        }

        
    }

  
    
}
