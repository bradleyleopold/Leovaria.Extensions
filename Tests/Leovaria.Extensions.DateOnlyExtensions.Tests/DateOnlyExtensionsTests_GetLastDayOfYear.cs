namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetLastDayOfYear
    {
        [Fact]
        public void GetsExpectedResult()
        {
            var expectedResult = "Tuesday";
            var dateOnly = new DateOnly(2024, 03, 09);

            var result = dateOnly.GetLastDayOfYear();

            Assert.Equal(expectedResult, result);
        }
    }
}
