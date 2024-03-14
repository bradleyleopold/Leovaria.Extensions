namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_DaysUntil_DateOnly
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly untilDate, int expectedResult)
        {
            var result = dateOnly.DaysUntil(untilDate);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly, int>
            {
                { new DateOnly(2024, 01, 01), new DateOnly(2024, 01, 02), 1 },
                { new DateOnly(2024, 02, 01), new DateOnly(2024, 02, 11), 10 },
                { new DateOnly(2024, 12, 31), new DateOnly(2025, 01, 01) , 1 },
            };
        }
    }
}
