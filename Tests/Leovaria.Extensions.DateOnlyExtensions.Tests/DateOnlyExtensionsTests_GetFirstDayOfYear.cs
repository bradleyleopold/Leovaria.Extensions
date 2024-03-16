namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetFirstDayOfYear
    {
        [Fact]
        public void GetsExpectedResult()
        {
            var expectedResult = "Monday";
            var dateOnly = new DateOnly(2024, 03, 09);

            var result = dateOnly.GetFirstDayOfYear();

            Assert.Equal(expectedResult, result);
        }
    }
}
