namespace Leovaria.Extensions.StringExtensions.Tests
{
    /// <summary>
    /// Tests for <see cref="StringExtensions.TakeUpTo(string, int)"/>.
    /// </summary>
    public sealed class StringExtensionsTests_TakeUpTo
    {
        [Theory]
        [InlineData("This is an example string.", 4, "This")]
        [InlineData("Hello world!", 3, "Hel")]
        [InlineData("C# is a programming language.", 5, "C# is")]
        [InlineData(".NET Core 6", 4, ".NET")]
        [InlineData("2023", 1, "2")]
        [InlineData("September 3rd 2023", 9, "September")]
        [InlineData("Halloween", 50, "Halloween")]
        [InlineData("/.<|{}[];'~!@#$%^&*()-_+=,", 50, "/.<|{}[];'~!@#$%^&*()-_+=,")]
        public void TakesCorrectAmounts(string inputString, int takeCount, string expectedResult)
        {
            // Act
            var result = inputString.TakeUpTo(takeCount);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("This is an example string.", 5, 2, "is is")]
        [InlineData("Happy birthday!", 9, 6, "birthday!")]
        [InlineData("How are you today?", 7, 4, "are you")]
        [InlineData("I'm doing well.", 0, 4, "")]
        public void WorksWithStartIndex(string inputString, int takeCount, int startIndex, string expectedResult)
        {
            // Act
            var result = inputString.TakeUpTo(takeCount, startIndex);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("This is Halloween.", 0, "")]
        public void ProcessesZeroCounts(string inputString, int takeCount, string expectedResult)
        {
            // Act
            var result = inputString.TakeUpTo(takeCount);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void NullInputString_ThrowsArgumentNullException()
        {
            // Arrange
            var exampleString = (string?)null;

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => exampleString!.TakeUpTo(10));
        }

        [Fact]
        public void NegativeCharacterCount()
        {
            // Arrange
            var exampleString = "Example string";

            // Assert
            Assert.Throws<ArgumentException>(() => exampleString!.TakeUpTo(-10));
        }
    }
}
