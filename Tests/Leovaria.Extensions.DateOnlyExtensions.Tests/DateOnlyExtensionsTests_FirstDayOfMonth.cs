namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_FirstDayOfMonth
    {
        [Fact]
        public void GetsExpectedResult()
        {
            var expectedResult = "Friday";
            var dateOnly = new DateOnly(2024, 03, 09);

            var result = dateOnly.FirstDayOfMonth();

            Assert.Equal(expectedResult, result);
        }
    }
}
