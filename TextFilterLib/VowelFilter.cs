using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TextFilterLib
{
    public class VowelFilter : IFilter
    {
        public string ApplyFilter(string inputString)
        {
            var wordList = StringFilterHelper.SplitString(inputString);
            var vowels = new string[] { "A", "E", "I", "O", "U" };
            var input = new StringBuilder(inputString);

            foreach (var word in wordList)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    var lengthMod = word.Length % 2;
                    var middleIndex = (int)Math.Floor(word.Length / 2.0);
                    var middleChars = lengthMod != 0 
                        ? word.Substring(middleIndex, 1) 
                        : word.Substring(middleIndex - 1, 2);

                    if (vowels.Any(x => middleChars.Contains(x, StringComparison.InvariantCultureIgnoreCase)))
                    {
                        input = StringFilterHelper.FilterWordFromString(input, word);
                    }                 
                }
            }

            return input.ToString().Trim();
        }
    }
}
