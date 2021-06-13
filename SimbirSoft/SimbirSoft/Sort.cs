using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoft
{
    public class Sort
    {

        
        public static void SortMethod(List<string> text)
        {
            ProjDBContext projDBContext = new ProjDBContext();
            var result = from i in text
                         group i by i into g
                         select new Word
                         {
                             UniqueWord = g.Key,
                             Count = g.Count()
                         };

            foreach (var item in result)
            {
                Console.WriteLine($"{item.UniqueWord} - {item.Count} ");
                projDBContext.Words.Add(item);
                projDBContext.SaveChanges();
            }
            
        }
    }
}