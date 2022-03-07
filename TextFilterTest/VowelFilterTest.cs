using NUnit.Framework;
using TextFilterLib;

namespace TextFilterTest
{
    public class VowelFilterTest
    {
        [Test]
        public void FilterMiddleVowelInOddLengthWords()
        {
            //Setup
            var inputString = "clean the place using wipes";
            var expectedString = "the wipes";

            //Action
            var vowelFilter = new VowelFilter();
            var actualString = vowelFilter.ApplyFilter(inputString);

            //Assert
            Assert.AreEqual(expectedString,actualString);
        }

        [Test]
        public void FilterMiddleVowelInEvenLenghtWords()
        {
            //Setup
            var inputString = "very tired of sitting by sister on the bank";
            var expectedString = "tired sitting by sister the";

            //Action
            var vowelFilter = new VowelFilter();
            var actualString = vowelFilter.ApplyFilter(inputString);

            //Assert
            Assert.AreEqual(expectedString, actualString);
        }


        [Test]
        public void FilterMiddleVowelInStringWithSpecialChars()
        {
            //Setup
            var inputString = "Rabbit say to 'and itself, 'Oh dear! Oh dear! I shall be late! (when she thought it over afterwards,";
            var expectedString = "Rabbit 'and , ' ! ! ! ( she afterwards,";
                                   

            //Action
            var vowelFilter = new VowelFilter();
            var actualString = vowelFilter.ApplyFilter(inputString);

            //Assert
            Assert.AreEqual(expectedString, actualString);
        }

        [Test]
        public void FilterVowelInStringWithSpecialChars()
        {
            //Setup
            var inputString = "it, it 'it it) its it .it oh! 'oh! ohh! \"said";
            var expectedString = ", ' ) its . ! '! ohh! \"";

            //Action
            var vowelFilter = new VowelFilter();
            var actualString = vowelFilter.ApplyFilter(inputString);

            //Assert
            Assert.AreEqual(expectedString, actualString);
        }       
    }
}