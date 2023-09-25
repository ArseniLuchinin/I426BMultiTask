using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace MultiTask
{
    static class Instruments
    {
        public static void writeRedText(String outputString, ConsoleColor messageColor = ConsoleColor.Red) {
            ConsoleColor fontColor = Console.ForegroundColor;
            Console.ForegroundColor = messageColor;
            Console.WriteLine(outputString);
            Console.ForegroundColor = fontColor;
        }
        public static void enterNumber(String innputMessage, out int returnedInt, String ErrorMessage = "Неверный формат записи")
        {
            while (true)
            {
                Console.WriteLine(innputMessage);
                if ((Int32.TryParse(Console.ReadLine(), out returnedInt)) && (returnedInt > 0))
                    break;

                else writeRedText(ErrorMessage);
            }
        }

        public static void enterName(String Message, out String name, String ErrorMessage = "Неверный формат записи имени")
        {
            while (true)
            {

                Console.WriteLine(Message);
                name = "" + Console.ReadLine();
                String pattern = "^[А-ЯЁA-Z][а-яёa-z]{" + (name.Length - 1) + "}";
                Regex regex = new Regex(pattern);
                if (regex.IsMatch(name))
                    break;
                else
                    writeRedText(ErrorMessage);
            }
        }

        public static void enterWord(String Message, out String word, String ErrorMessage = "Неверный формат записи")
        {
            while (true)
            {
                Console.WriteLine(Message);
                word = "" + Console.ReadLine();
                Regex regex = new Regex(@"\w*", RegexOptions.IgnoreCase);
                if (regex.IsMatch(word))
                    break;
                else
                    writeRedText(ErrorMessage);
            }
        }
    }
}   
