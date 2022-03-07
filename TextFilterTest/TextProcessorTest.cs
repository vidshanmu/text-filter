using NUnit.Framework;
using TextFilterLib;
using Moq;
using System.IO;

namespace TextFilterTest
{
    public class TextProcessorTest
    {
        [Test]
        public void ShouldThrowFileNotFoundException()
        {
            //Setup
            var path = "filePath";
            Mock<IFileReader> fileReader = new Mock<IFileReader>();
            fileReader.Setup(x => x.IsFileExists(path)).Returns(false);
            var textProcessor = new TextProcessor(fileReader.Object, null, null);
           
            Assert.Throws<FileNotFoundException>(() => {
                textProcessor.ProcessText(path);
            });
        }
            [Test]
        public void ShouldCreateAndApplyFiltersAndReturnText()
        {
            //Setup
            var path = "filePath";
            var inputString = "Test";
            var vowelFilteroutputString = "vf";
            var lengthFilteroutputString = "lf";
            var charFilteroutputString = "cf";

            Mock<IFileReader> fileReader = new Mock<IFileReader>();
            Mock<IFilterProvider> filterProvider = new Mock<IFilterProvider>();
            Mock<IOutputWriter> outputFilter = new Mock<IOutputWriter>();
            Mock<IFilter> vowelFilter = new Mock<IFilter>();
            Mock<IFilter> lengthFilter = new Mock<IFilter>();
            Mock<IFilter> charFilter = new Mock<IFilter>();
            Mock<IOutputWriter> outputWriter = new Mock<IOutputWriter>();

            fileReader.Setup(x => x.Read(path)).Returns(inputString);
            fileReader.Setup(x => x.IsFileExists(path)).Returns(true);
            filterProvider.Setup(x => x.GetVowelFilter()).Returns(vowelFilter.Object);
            filterProvider.Setup(x => x.GetLenghtFilter(3)).Returns(lengthFilter.Object);
            filterProvider.Setup(x => x.GetCharFilter('t')).Returns(charFilter.Object);
            vowelFilter.Setup(x => x.ApplyFilter(inputString)).Returns(vowelFilteroutputString);
            lengthFilter.Setup(x => x.ApplyFilter(vowelFilteroutputString)).Returns(lengthFilteroutputString);
            charFilter.Setup(x => x.ApplyFilter(lengthFilteroutputString)).Returns(charFilteroutputString);
            outputWriter.Setup(x => x.Write(charFilteroutputString));


            var textProcessor = new TextProcessor(fileReader.Object, filterProvider.Object, outputWriter.Object);

            //Action
            textProcessor.ProcessText(path);

            //Assert
            fileReader.VerifyAll();
            filterProvider.VerifyAll();
            vowelFilter.VerifyAll();
            lengthFilter.VerifyAll();
            charFilter.VerifyAll();
            outputWriter.VerifyAll();
        }
    }
}
