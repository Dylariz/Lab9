using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab9
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Number1.Program.Start();
        }
    }
}

namespace Number1
{
    public static class Program
    {
        /// <summary>
        /// В заданном тексте определить частоту, с которой встречаются в
        /// тексте различные буквы русского алфавита (в долях от общего количества букв).
        /// </summary>
        public static void Start()
        {
            var alphabet =
                Enumerable.Range('а', 32).ToDictionary(x => (char)x, x => 0);
            var streamReader = new StreamReader("Input.txt");
            string text = streamReader.ReadToEnd().ToLower();
            double totalChars = 0;

            foreach (var t in text)
            {
                if (alphabet.ContainsKey(t))
                {
                    alphabet[t]++;
                    totalChars++;
                }
            }

            foreach (var t in alphabet)
            {
                Console.WriteLine($"{t.Key}: {t.Value / totalChars * 100:f2}%");
            }
        }
    }
}

namespace Number5   
{
    /// <summary>
    /// Задан текст, содержащий не более 1000 символов. Напечатать буквы,
    /// на которые начинаются слова в тексте, в порядке убывания частоты их употребления.
    /// </summary>
    internal static class Program
    {
        public static void Start()
        {
            var alphabet =
                Enumerable.Range('а', 32).ToDictionary(x => (char)x, x => 0);
            var streamReader = new StreamReader("Input.txt");
            string text = streamReader.ReadToEnd().ToLower();
            double totalChars = 0;
            
            char last = '\n';
            foreach (var t in text)
            {
                if ((last == '\n' || last == '\t' || last == ' ') && alphabet.ContainsKey(t))
                {
                    alphabet[t]++;
                    totalChars++;
                }

                last = t;
            }
            
            alphabet = (from entry in alphabet orderby entry.Value descending select entry).ToDictionary(x => x.Key, x=> x.Value);

            foreach (var t in alphabet)
            {
                Console.WriteLine($"{t.Key}: {t.Value / totalChars * 100:f2}%");
            }
        }
    }
}