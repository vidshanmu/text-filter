using NUnit.Framework;
using TextFilterLib;

namespace TextFilterTest
{
    public class StringLengthFilterTest
    {
        [Test]
        public void FilterLessThanThreeCharLengthWords()
        {
            //Setup
            var inputString = "for no, she had plenty of time as she went down to have a look about her it.";
            var expectedString = "for , she had plenty time she went down have look about her .";
            var filterLength = 3;

            //Action
            var strLenghtFilter = new StringLengthFilter(filterLength);
            var actualString = strLenghtFilter.ApplyFilter(inputString);

            //Assert
            Assert.AreEqual(expectedString, actualString);
        }  
    }
}
