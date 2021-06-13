using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimbirSoft

{
    class Parse
    {
        public static List<string> ParseMethod(string oldText)
        {
            string text = "";

            char[] r = { ' ', ',', '.', '!', '?', '"', ';',
                ':', '[', ']', '(', ')', '\n', '\r', '\t',
                '«', '»', '—','/', '©','-', '\\','+',' ','&','.','·','‑','*','|', '<', '>', '=' };

            oldText = Remove.RemoveWithRegex(oldText);
            int i = 0;
            while (oldText.Length != i)
            {
                if (oldText[i].Equals('<'))
                {
                    while (!oldText[i].Equals('>'))
                    {
                        i++;
                        if (i >= oldText.Length)
                        {
                            break;
                        }
                    }
                    text += " ";

                }
                else
                {
                    text += oldText[i];
                }

                if (i >= oldText.Length)
                {
                    break;
                }
                i++;
            }

            text = text.ToUpper();
            string[] mas = text.Split(r, StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>();

            foreach (var u in mas)
            {
                list.Add(u);
            }

            return list;
        }
    }
}