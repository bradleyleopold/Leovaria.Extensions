namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetLastWeekendDateOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly expectedResult)
        {
            var result = dateOnly.GetLastWeekendDateOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 03, 05), new DateOnly(2024, 03, 31) },
                { new DateOnly(2024, 02, 10), new DateOnly(2024, 02, 25) },
                { new DateOnly(2024, 01, 15), new DateOnly(2024, 01, 28) },
                { new DateOnly(2024, 06, 03), new DateOnly(2024, 06, 30) },
            };
        }
    }
}
