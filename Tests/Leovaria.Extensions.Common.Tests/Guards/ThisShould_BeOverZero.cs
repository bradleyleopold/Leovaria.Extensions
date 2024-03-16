using Leovaria.Extensions.Common.Guards;

namespace Leovaria.Extensions.Common.Tests.Guards
{
    /// <summary>
    /// Tests for <see cref="ThisShould.BeOverZero(int)"/>.
    /// </summary>
    public sealed class ThisShould_BeOverZero
    {
        [Theory]
        [InlineData(1)]
        [InlineData(145484521)]
        [InlineData(26)]
        [InlineData(3)]
        public void WorksWithAcceptableAmounts(int inputToTest)
        {
            // Act / Assert
            ThisShould.BeOverZero(inputToTest);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-37)]
        [InlineData(-727343)]
        [InlineData(-15486215)]
        public void ThrowsArgumentExceptionWhenArgumentIsLessThanZero(int inputToTest)
        {
            // Act
            var action = () => ThisShould.BeOverZero(inputToTest);

            // Assert
            Assert.Throws<ArgumentException>(action);
        }
    }
}
