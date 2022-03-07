using NUnit.Framework;
using TextFilterLib;

namespace TextFilterTest
{
    public class FilterProviderTest
    {
        [Test]
        public void ShouldReturnVowelFilterInstance()
        {
            //Setup
            var filterProvider = new FilterProvider();

            //Action
            var actual = filterProvider.GetVowelFilter();

            //Assert
            Assert.IsInstanceOf<VowelFilter>(actual);
        }

        [Test]
        public void ShouldReturnLengthFilterInstance()
        {
            //Setup
            var filterProvider = new FilterProvider();

            //Action
            var actual = filterProvider.GetLenghtFilter(3);

            //Assert
            Assert.IsInstanceOf<StringLengthFilter>(actual);
        }


        [Test]
        public void ShouldReturnCharFilterInstance()
        {
            //Setup
            var filterProvider = new FilterProvider();

            //Action
            var actual = filterProvider.GetCharFilter('t');

            //Assert
            Assert.IsInstanceOf<CharFilter>(actual);
        }

    }
}
