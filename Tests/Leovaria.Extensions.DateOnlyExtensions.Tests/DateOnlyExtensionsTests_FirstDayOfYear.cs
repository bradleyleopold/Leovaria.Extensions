namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_FirstDayOfYear
    {
        [Fact]
        public void GetsExpectedResult()
        {
            var expectedResult = "Monday";
            var dateOnly = new DateOnly(2024, 03, 09);

            var result = dateOnly.FirstDayOfYear();

            Assert.Equal(expectedResult, result);
        }
    }
}
