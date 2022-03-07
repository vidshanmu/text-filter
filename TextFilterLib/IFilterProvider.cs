namespace TextFilterLib
{
    public interface IFilterProvider
    {
        IFilter GetVowelFilter();

        IFilter GetLenghtFilter(int length);

        IFilter GetCharFilter(char c);
    }
}