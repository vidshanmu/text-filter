using System.Text;
using System.Text.RegularExpressions;

namespace TextFilterLib
{
    internal static class StringFilterHelper
    {
        public static string[] SplitString(string inputString)
        {
            return Regex.Split(inputString, "[^a-zA-Z0-9]+");
        }
        public static StringBuilder FilterWordFromString(StringBuilder inputString, string word)
        {
            // Match the word with leading or trailing space
            var replacePattern = string.Format(@"(?<!\S){0}(?!\S)", word);
            var regWordMatch = new Regex(replacePattern);
            var wordMatch = regWordMatch.Match(inputString.ToString(), 0);
            if (wordMatch.Success)
            {
                inputString = inputString.Remove(wordMatch.Index, wordMatch.Length);
                return inputString.Replace("  ", " ");
            }

            // Match the word with special char at the start
            var replacePatternWithSpecialCharStart = string.Format("(?:[?`.'\"(]){0}", word);
            regWordMatch = new Regex(replacePatternWithSpecialCharStart);
            wordMatch = regWordMatch.Match(inputString.ToString(), 0);
            if (wordMatch.Success)
            {
                //Exclude the special character at the start
                inputString = inputString.Remove(wordMatch.Index + 1, wordMatch.Length - 1);
                return inputString.Replace("  ", " ");
            }

            // Match the word with special char at the end
            var replacePatternWithSpecialCharEnd = string.Format("{0}(?:[?'\")!,;:.])", word);
            regWordMatch = new Regex(replacePatternWithSpecialCharEnd);
            wordMatch = regWordMatch.Match(inputString.ToString(), 0);
            if (wordMatch.Success)
            {
                //Exclude the special character at the end
                inputString = inputString.Remove(wordMatch.Index, wordMatch.Length - 1);
                return inputString.Replace("  ", " ");
            }

            return inputString;
        }
    }
}
