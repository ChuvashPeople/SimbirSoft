using System;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Collections.Generic;


namespace SimbirSoft
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите ссылку: ");
            string link = Console.ReadLine();
            
            string path = "newHtml.txt";
            int count;
            string text;
            List<string> listForSort = new List<string>();

            Console.WriteLine("\nПожалуйста, подождите...\n");
            Download_Split.DownloadSplit(link, path, out count);
            
            int i = 1;
            
            
            while (i < count)
            {             
                text = Merge(ref i);

                foreach (var u in Parse.ParseMethod(text))
                {
                    listForSort.Add(u);
                }
                i++;
            }

            Sort.SortMethod(listForSort);
        }

        // Данный метод "собирает" строки между открывающим и закрывающим тегами в одну строковую переменную 
        // для того чтобы потом корректно отделить код от слов
        //↓↓↓↓↓
        public static string Merge(ref int i) 
        {
            string text = " ";
            string str = ".txt";
            string newPath;
            newPath = str;

            newPath = String.Concat(i.ToString(), newPath);

            using (StreamReader sr = new StreamReader(newPath))
            {
                text = sr.ReadToEnd();
                if (text.Contains('<'))
                {
                    while (!text.Contains("</"))
                    {
                        i++;
                        newPath = str;
                        newPath = String.Concat(i.ToString(), newPath);
                        using (StreamReader sR = new StreamReader(newPath))
                        {
                            text += sR.ReadToEnd();
                        }
                    }
                }
            }

            return text;
        }
    }
}
