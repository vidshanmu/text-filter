using System.Text;

namespace TextFilterLib
{
    public class StringLengthFilter : IFilter
    {
        private int filterLength;

        public StringLengthFilter(int filterLen)
        {
            filterLength = filterLen;
        }

        public string ApplyFilter(string inputString)
        {
            var wordList = StringFilterHelper.SplitString(inputString);
            var input = new StringBuilder(inputString);

            foreach (var word in wordList)
            {               
                if (!string.IsNullOrEmpty(word) && word.Length < filterLength)
                {
                    input = StringFilterHelper.FilterWordFromString(input, word);
                }
            }

            return input.ToString().Trim();
        }
    }
}
