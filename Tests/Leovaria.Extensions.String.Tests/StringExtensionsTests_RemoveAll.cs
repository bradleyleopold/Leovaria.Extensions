namespace Leovaria.Extensions.String.Tests
{
    /// <summary>
    /// Tests for <see cref="StringExtensions.RemoveAll(string, IEnumerable{string})"/>.
    /// </summary>
    public sealed class StringExtensionsTests_RemoveAll
    {
        [Theory]
        [MemberData(nameof(TestStringListData))]
        public void StripsOutAllSpecifiedStrings(string inputString, IEnumerable<string> stringsToRemove, string expectedResult)
        {
            // Act
            var result = inputString.RemoveAll(stringsToRemove);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void EmptyStringsToRemoveWorksCorrectly()
        {
            // Arrange
            var inputString = "Random test string.";
            var stringsToRemove = new List<string>();
            var expectedResult = "Random test string.";

            // Act
            var result = inputString.RemoveAll(stringsToRemove);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void NullInputString_ThrowsArgumentNullException()
        {
            // Arrange
            var exampleString = (string?)null;
            var stringsToRemove = new List<string> { "test string" };

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => exampleString!.RemoveAll(stringsToRemove));
            var test = Enumerable.Empty<string>();
        }

        [Fact]
        public void NullInputStringsToRemove_ThrowsArgumentNullException()
        {
            // Arrange
            var exampleString = "Test random string.";
            var stringsToRemove = (List<string>?)null;

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => exampleString.RemoveAll(stringsToRemove!));
        }

        /// <summary>
        /// Test data for RemoveAll method testing.
        /// </summary>
        public static IEnumerable<object[]> TestStringListData()
        {
            // [0] = Input String
            // [1] = Strings To Remove
            // [2] = Expected Result

            yield return new object[] { 
                "Hello REMOVEMEthere, how THISTOOare you?", 
                new List<string> { "REMOVEME", "THISTOO" },
                "Hello there, how are you?"
            };

            yield return new object[] {
                "asdfjoa sdfiaj fa dfjiasd jfoiwneaen fas asjfioaj dofasf",
                new List<string> { " dfjiasd", "fas ", "asdfjoa " },
                "sdfiaj fa jfoiwneaen asjfioaj dofasf"
            };

            yield return new object[] {
                "LONGSTRINGTEST test will make sure the shorter strings aren't removed firstLONGSTRING",
                new List<string> { "LONGSTRING", "LONGSTRINGTEST" },
                " test will make sure the shorter strings aren't removed first"
            };

            yield return new object[] {
                "LONGSTRING test will make sure the shorter strings aren't removed firstLONGSTRINGTEST",
                new string[] { "LONGSTRING", "LONGSTRINGTEST" },
                " test will make sure the shorter strings aren't removed first"
            };
        }
    }
}
