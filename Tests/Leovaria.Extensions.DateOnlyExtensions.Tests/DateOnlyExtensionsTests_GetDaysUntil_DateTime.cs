namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetDaysUntil_DateTime
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateTime untilDate, int expectedResult)
        {
            var result = dateOnly.GetDaysUntil(untilDate);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateTime, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateTime, int>
            {
                { new DateOnly(2024, 01, 01), new DateTime(2024, 01, 02), 1 },
                { new DateOnly(2024, 02, 01), new DateTime(2024, 02, 11), 10 },
                { new DateOnly(2024, 12, 31), new DateTime(2025, 01, 01) , 1 },
            };
        }
    }
}
