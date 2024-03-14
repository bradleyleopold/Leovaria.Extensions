namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_LastDayOfYear
    {
        [Fact]
        public void GetsExpectedResult()
        {
            var expectedResult = "Tuesday";
            var dateOnly = new DateOnly(2024, 03, 09);

            var result = dateOnly.LastDayOfYear();

            Assert.Equal(expectedResult, result);
        }
    }
}
