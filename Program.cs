using System;
using System.Collections.Generic;
using System.IO;

namespace LittleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = "output.txt";
            string text = File.ReadAllText(fileName);

            IEnumerable<(char Letter, int Count)> lettersList = Analytic.GetLetterCount(text);

            Console.WriteLine("Each letter are in the file");
            foreach (var item in lettersList)
            {
                Console.WriteLine($"\t{item.Letter} {item.Count}");
            }
            Console.WriteLine("\n");

            int capitalizedLetterCount = Analytic.GetCapitalizedLetterCount(text);
            Console.WriteLine($"Number of letters are capitalized in the file");
            Console.WriteLine($"\tnumber  = {capitalizedLetterCount}\n");


            (string Word, int Count)? mostRepeatWord = Analytic.GetMostRepeatWord(text);
            Console.WriteLine($"The most common word and the number of times it has been seen");
            Console.WriteLine($"\tword '{mostRepeatWord.Value.Word}' number = {mostRepeatWord.Value.Count}\n");

            const int lengthPrefix = 2;
            (string Prefix, int Count)? mostRepeatPrefix = Analytic.GetMostRepeatCharacterPrefix(text, lengthPrefix);
            Console.WriteLine($"The most common {lengthPrefix} character prefix and the number of occurrences in the text file.");
            Console.WriteLine($"\tprefix '{mostRepeatPrefix.Value.Prefix}' number = {mostRepeatPrefix.Value.Count}\n");
        }
    }
}
