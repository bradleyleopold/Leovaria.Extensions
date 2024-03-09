namespace Leovaria.Extensions.String.Tests
{
    /// <summary>
    /// Tests for <see cref="StringExtensions.TakeUpToLast(string, int)"/>.
    /// </summary>
    public sealed class StringExtensionsTests_TakeUpToLast
    {
        [Theory]
        [InlineData("racecar", 3, "car")]
        [InlineData("racecar", 1, "r")]
        [InlineData("xunit-testing-string-1234567890", 10, "1234567890")]
        [InlineData("racecar", 0, "")]
        public void TakesCorrectSliceFromTheBack(string inputString, int takeCount, string expectedResult)
        {
            // Act
            var result = inputString.TakeUpToLast(takeCount);
            
            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void CountExceedsInputStringLength()
        {
            // Arrange
            var exampleString = "This is an example string.";

            // Act
            var result = exampleString.TakeUpToLast(50);

            // Assert
            Assert.Equal("This is an example string.", result);
        }

        [Fact]
        public void NegativeCharacterCount()
        {
            // Arrange
            var exampleString = "Example string";

            // Assert
            Assert.Throws<ArgumentException>(() => exampleString!.TakeUpToLast(-10));
        }
    }
}