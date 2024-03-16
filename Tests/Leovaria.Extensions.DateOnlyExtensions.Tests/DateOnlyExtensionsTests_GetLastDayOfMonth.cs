namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetLastDayOfMonth
    {
        [Fact]
        public void GetsExpectedResult()
        {
            var expectedResult = "Sunday";
            var dateOnly = new DateOnly(2024, 03, 09);

            var result = dateOnly.GetLastDayOfMonth();

            Assert.Equal(expectedResult, result);
        }
    }
}
