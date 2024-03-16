namespace Leovaria.Extensions.StringExtensions.Tests
{
    /// <summary>
    /// Tests for <see cref="StringExtensions.SplitByLength(string, int)"/>.
    /// </summary>
    public sealed class StringExtensionsTests_SplitByLength
    {
        [Theory]
        [MemberData(nameof(TestStringListData))]
        public void SplitsCorrectly(string inputString, int splitLength, List<string> expectedResult)
        {
            // Act
            var result = inputString.SplitByLength(splitLength);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ProcessesZeroCounts()
        {
            // Arrange
            var inputString = "Split me by nothing.";
            var expectedResult = new List<string> { inputString };

            // Act
            var result = inputString.SplitByLength(0);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void NullInputString_ThrowsArgumentNullException()
        {
            // Arrange
            var exampleString = (string?)null;

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => exampleString!.SplitByLength(10));
        }

        [Fact]
        public void NegativeCharacterCount()
        {
            // Arrange
            var exampleString = "Example string";

            // Assert
            Assert.Throws<ArgumentException>(() => exampleString!.SplitByLength(-10));
        }

        /// <summary>
        /// Test data for SplitByLength method testing.
        /// </summary>
        public static IEnumerable<object[]> TestStringListData()
        {
            // [0] = Input String
            // [1] = Number to split length by
            // [2] = Expected Result

            yield return new object[] {
                "Split me baby one more time!",
                5,
                new List<string> { "Split", " me b", "aby o", "ne mo", "re ti", "me!" }
            };
        }
    }
}
