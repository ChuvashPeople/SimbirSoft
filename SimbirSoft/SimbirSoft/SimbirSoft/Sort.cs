using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectSimbirProject
{
    class Sort
    {
        public static void SortMethod(List<string> text)
        {
            var result = from i in text
                         group i by i into g
                         select new
                         {
                             Name = g.Key,
                             Count = g.Count()
                         };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.Name} - {item.Count} ");
            }
        }
    }
}