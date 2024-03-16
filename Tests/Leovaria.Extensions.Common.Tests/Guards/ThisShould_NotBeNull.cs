using Leovaria.Extensions.Common.Guards;

namespace Leovaria.Extensions.Common.Tests.Guards
{
    /// <summary>
    /// Tests for <see cref="ThisShould.NotBeNull(object)"/>.
    /// </summary>
    public sealed class ThisShould_NotBeNull
    {
        [Theory]
        [InlineData(0)]
        [InlineData("")]
        [InlineData("thisisateststring")]
        [InlineData(15.0d)]
        public void WorksWithAcceptableAmounts(object inputToTest)
        {
            // Act / Assert
            ThisShould.NotBeNull(inputToTest);
        }

        [Theory]
        [InlineData(null)]
        public void ThrowsArgumentNullExceptionWhenArgumentIsNull(object? inputToTest)
        {
            // Act
            var action = () => ThisShould.NotBeNull(inputToTest!);

            // Assert
            Assert.Throws<ArgumentNullException>(action);
        }
    }
}
