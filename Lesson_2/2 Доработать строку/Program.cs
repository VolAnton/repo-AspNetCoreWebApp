using System;
using System.Text.RegularExpressions;

namespace StringLine
{
    class Program
    {
        static void Main(string[] args)
        {
            string baseString = "   Предложение  один   Теперь  предложение   два     Предложение    три    ";

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            string resultString = regex.Replace(baseString, " ");

            regex = new Regex(@"^\s|\s$", options);
            resultString = regex.Replace(resultString, "");

            regex = new Regex(@"\s[А-Я]", options);
            MatchCollection matches = regex.Matches(resultString);

            foreach (Match match in matches)
            {
                int index = resultString.IndexOf(match.Value);
                resultString = resultString.Insert(index, ".");
            }

            if (resultString[resultString.Length - 1] != '.')
            {
                resultString = resultString.Insert(resultString.Length, ".");
            }

            Console.WriteLine("Было:");
            Console.WriteLine(baseString);
            Console.WriteLine("\nСтало:");
            Console.WriteLine(resultString);

            Console.ReadKey();
        }        
    }
}
