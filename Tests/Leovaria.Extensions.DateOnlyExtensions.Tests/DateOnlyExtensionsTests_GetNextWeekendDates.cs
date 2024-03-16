namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetNextWeekendDates
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, List<DateOnly> expectedResult)
        {
            var result = dateOnly.GetNextWeekendDates();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, List<DateOnly>> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, List<DateOnly>>
            {
                { new DateOnly(2024, 03, 01), [new DateOnly(2024, 03, 02), new DateOnly(2024, 03, 03)] },
                { new DateOnly(2024, 03, 02), [new DateOnly(2024, 03, 09), new DateOnly(2024, 03, 10)] },
            };
        }
    }
}
