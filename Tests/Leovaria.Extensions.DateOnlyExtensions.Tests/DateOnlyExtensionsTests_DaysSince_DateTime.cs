namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_DaysSince_DateTime
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateTime sinceDate, int expectedResult)
        {
            var result = dateOnly.DaysSince(sinceDate);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateTime, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateTime, int>
            {
                { new DateOnly(2024, 01, 02), new DateTime(2024, 01, 01, 05, 01, 35), 1 },
                { new DateOnly(2024, 02, 11), new DateTime(2024, 02, 01), 10 },
                { new DateOnly(2025, 01, 01), new DateTime(2024, 12, 31), 1 },
                { new DateOnly(2025, 01, 01), new DateTime(2023, 12, 31), 367 },
                { new DateOnly(2025, 01, 01), new DateTime(2025, 01, 02), -1 },
                { new DateOnly(2025, 01, 01), new DateTime(2025, 01, 01), 0 },
                { DateOnly.MinValue, DateTime.MaxValue, -3_652_058 },
                { DateOnly.MaxValue, DateTime.MinValue, 3_652_058 }
            };
        }
    }
}
