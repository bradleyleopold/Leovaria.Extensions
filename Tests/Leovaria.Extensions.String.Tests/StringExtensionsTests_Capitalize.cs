namespace Leovaria.Extensions.StringExtensions.Tests
{
    /// <summary>
    /// Tests for <see cref="StringExtensions.Capitalize(string)"/>.
    /// </summary>
    public sealed class StringExtensionsTests_Capitalize
    {
        [Theory]
        [InlineData("hello world", "Hello world")]
        [InlineData("452958", "452958")]
        [InlineData("yo dawg", "Yo dawg")]
        [InlineData("Iamastring", "Iamastring")]
        [InlineData("<>?;'[]\\:!@#$%^&*()-_+=", "<>?;'[]\\:!@#$%^&*()-_+=")]
        [InlineData("z<>?;'[]\\:!@#$%^&*()-_+=", "Z<>?;'[]\\:!@#$%^&*()-_+=")]
        public void CapitalizesExpectedly(string inputString, string expectedResult)
        {
            // Act
            var result = inputString.Capitalize();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void NullInputString_ThrowsArgumentNullException()
        {
            // Arrange
            var exampleString = (string?)null;

            // Act / Assert
            Assert.Throws<ArgumentNullException>(() => exampleString!.Capitalize());
        }
    }
}
