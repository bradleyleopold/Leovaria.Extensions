using Leovaria.Extensions.String.Guards;

namespace Leovaria.Extensions.Common.Tests.Guards
{
    /// <summary>
    /// Tests for <see cref="ThisShould.BeZeroOrMore(int)"/>.
    /// </summary>
    public sealed class ThisShould_BeZeroOrMore
    {
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(145484521)]
        [InlineData(26)]
        [InlineData(3)]
        public void WorksWithAcceptableAmounts(int inputToTest)
        {
            // Act / Assert
            ThisShould.BeZeroOrMore(inputToTest);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-37)]
        [InlineData(-727343)]
        [InlineData(-15486215)]
        public void ThrowsExceptionWhenArgumentIsLessThanZero(int inputToTest)
        {
            // Act
            var action = () => ThisShould.BeZeroOrMore(inputToTest);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
