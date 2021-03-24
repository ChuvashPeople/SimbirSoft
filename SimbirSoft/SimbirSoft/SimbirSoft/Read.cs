using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TestProjectSimbirProject
{
    class Read
    {
        public static string ReadMethod(string path)
        {
            string text = "";
            using (StreamReader str = new StreamReader(path))
            {
                text = str.ReadToEnd();
            }
            return text;
        }
    }
}