namespace TextFilterLib
{
    public class FilterProvider : IFilterProvider
    {
        public IFilter GetCharFilter(char c)
        {
            return new CharFilter(c);  
        }

        public IFilter GetLenghtFilter(int length)
        {
            return new StringLengthFilter(length);
        }

        public IFilter GetVowelFilter()
        {
            return new VowelFilter();
        }
    }
}