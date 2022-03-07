using System.Text;

namespace TextFilterLib
{
    public class CharFilter : IFilter
    {
        private char filterCharacter;

        public CharFilter(char filterChar)
        {
            filterCharacter = filterChar;
        }
        public string ApplyFilter(string inputString)
        {
            var wordList = StringFilterHelper.SplitString(inputString);
            var input = new StringBuilder(inputString);

            foreach (var word in wordList)
            {
                if (!string.IsNullOrEmpty(word) && word.Contains(filterCharacter))
                {
                    input = StringFilterHelper.FilterWordFromString(input, word);
                }
            }

            return input.ToString().Trim();
        }
    }
}
