namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_WeekendNumber
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int expectedResult)
        {
            var result = dateOnly.WeekNumber();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int>
            {
                { new DateOnly(2024, 01, 01), 1},
                { new DateOnly(2024, 01, 08), 2},
            };
        }
    }
}
