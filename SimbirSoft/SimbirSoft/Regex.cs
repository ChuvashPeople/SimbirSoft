using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SimbirSoft
{
    class Remove
    {
        public static string RemoveWithRegex(string text)
        {
            Regex regexJS = new Regex(@"(?s)<script.*?(/>|</script>)", RegexOptions.IgnoreCase);
            Regex regexST = new Regex(@"(?s)<style.*?(/>|</style>)", RegexOptions.IgnoreCase);
            Regex regex = new Regex(@"&\S+\d", RegexOptions.IgnoreCase); //Удаление специальных символов HTML
            Regex regexNumber = new Regex(@"\w*\d-\w*"); // Удаление чисел вместе с окончанием слова, пример "3-й" будет удалено
            Regex regexSimpleNumber = new Regex(@"\d", RegexOptions.IgnoreCase); //Удаление чисел
            text = regexJS.Replace(text, " ");
            text = regexST.Replace(text, " ");
            text = regex.Replace(text, " ");
            text = regexNumber.Replace(text, " ");
            text = regexSimpleNumber.Replace(text, " ");
            return text;
        }
    }
}