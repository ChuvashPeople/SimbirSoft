using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace TestProjectSimbirProject
{
    class Download_Split
    {
        public static void DownloadSplit(string link, string path, out int count)
        {
            
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadFile(link, path); // Скачиваем HTML документ в текстовый файл по указанному пути
                }
                count = File.ReadLines(path).Count();

                string str = ".txt";
                string newPath;
                string pat = str;

                using (StreamReader sR = new StreamReader(path))
                {
                    for (int i = 1; i <= count; i++)
                    {
                        newPath = pat;
                        newPath = String.Concat(i.ToString(), newPath);
                        using (StreamWriter sW = new StreamWriter(newPath, false)) // Записываем каждую строку в отдельный файл (номер строки = название файла)
                        {
                            sW.WriteLine(sR.ReadLine());
                        }
                    }
                }
            }
            catch (WebException)
            {
                Console.WriteLine("Пожалуйста, введите корректную ссылку");
            }

            count = File.ReadLines(path).Count();
        }
    }
}