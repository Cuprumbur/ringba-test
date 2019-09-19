using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace LittleApp
{
    public class Analytic
    {
        public static int GetCapitalizedLetterCount(string text)
        {
            if (string.IsNullOrEmpty(text))
                return 0;

            MatchCollection matchCollection = Regex.Matches(text, @"[A-Z]");
            return matchCollection.Count();
        }

        public static IEnumerable<(char Letter, int Count)> GetLetterCount(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            return text.ToCharArray()
             .GroupBy(x => x)
             .Select(y => (Letter: y.Key, Count: y.Count()))
             .OrderBy(z => z.Letter);
        }

        public static (string Word, int Count)? GetMostRepeatWord(string text)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            MatchCollection matchCollection = Regex.Matches(text, @"[A-Z][a-z]*");
            if (matchCollection.Count() == 0)
                return null;

            var groupWords = matchCollection.GroupBy(x => x.Value);

            int max = groupWords.Max(x => x.Count());
            string word = groupWords.First(x => x.Count() == max).Key;

            return (Word: word, Count: max);
        }

        internal static (string Prefix, int Count)? GetMostRepeatCharacterPrefix(string text, int lengthPrefix)
        {
            if (string.IsNullOrEmpty(text))
                return null;

            MatchCollection matchCollection = Regex.Matches(text, @"[A-Z][a-z]*");
            if (matchCollection.Count() == 0)
                return null;

            var prefixes = matchCollection
                      .Where(x => x.Value.Length > lengthPrefix)
                      .Select(y => y.Value.Substring(0, lengthPrefix));

            var groupPrefixes = prefixes.GroupBy(x => x);

            int max = groupPrefixes.Max(x => x.Count());
            string prefix = groupPrefixes.First(x => x.Count() == max).Key;

            return (Prefix: prefix, Count: max);
        }
    }
}

