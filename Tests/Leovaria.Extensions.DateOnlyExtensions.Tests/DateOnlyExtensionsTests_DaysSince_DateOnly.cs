namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_DaysSince_DateOnly
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly sinceDate, int expectedResult)
        {
            var result = dateOnly.DaysSince(sinceDate);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly, int>
            {
                { new DateOnly(2024, 01, 02), new DateOnly(2024, 01, 01), 1 },
                { new DateOnly(2024, 02, 11), new DateOnly(2024, 02, 01), 10 },
                { new DateOnly(2025, 01, 01), new DateOnly(2024, 12, 31), 1 },
                { new DateOnly(2025, 01, 01), new DateOnly(2023, 12, 31), 367 },
                { new DateOnly(2025, 01, 01), new DateOnly(2025, 01, 02), -1 },
                { new DateOnly(2025, 01, 01), new DateOnly(2025, 01, 01), 0 },
                { DateOnly.MinValue, DateOnly.MaxValue, -3_652_058 },
                { DateOnly.MaxValue, DateOnly.MinValue, 3_652_058 }
            };
        }
    }
}
