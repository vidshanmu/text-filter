using NUnit.Framework;
using TextFilterLib;

namespace TextFilterTest
{
    public class CharFilterTest
    {

        [Test]
        public void FilterWordsWithTheFilterChar()
        {
            //Setup
            var inputString = "The rabbit hole went straight on like a tunnel for some way .either";
            var expectedString = "The hole on like a for some way .";
            var filterChar = 't';

            //Action
            var strLenghtFilter = new CharFilter(filterChar);
            var actualString = strLenghtFilter.ApplyFilter(inputString);

            //Assert
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
