using System.IO;

namespace TextFilterLib
{
    public class TextProcessor : ITextProcessor
    {
        private IFileReader fileReader;
        private IFilterProvider filterProvider;
        private IOutputWriter outputWriter;
        public TextProcessor(IFileReader reader, 
                             IFilterProvider provider, 
                             IOutputWriter writer)
        {
            fileReader = reader;
            filterProvider = provider;
            outputWriter = writer;
        }

        public void ProcessText(string filePath)
        {
            if (!fileReader.IsFileExists(filePath))
            {
                throw new FileNotFoundException();
            }
            var fileContents = fileReader.Read(filePath);
            var vowelFilterOutput = filterProvider
                                        .GetVowelFilter()
                                        .ApplyFilter(fileContents);
            var lenghtFilterOutput = filterProvider
                                        .GetLenghtFilter(3)
                                        .ApplyFilter(vowelFilterOutput);
            var charFilterOutput = filterProvider
                                        .GetCharFilter('t')
                                        .ApplyFilter(lenghtFilterOutput);
            outputWriter.Write(charFilterOutput);
        }
    }
}
