namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_LastDayOfMonth
    {
        [Fact]
        public void GetsExpectedResult()
        {
            var expectedResult = "Sunday";
            var dateOnly = new DateOnly(2024, 03, 09);

            var result = dateOnly.LastDayOfMonth();

            Assert.Equal(expectedResult, result);
        }
    }
}
