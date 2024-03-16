namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetDaysSince_YearMonthDay
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int year, int month, int day, int expectedResult)
        {
            var result = dateOnly.GetDaysSince(year, month, day);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int, int, int, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int, int, int, int>
            {
                { new DateOnly(2024, 01, 02), 2024, 01, 01, 1 },
                { new DateOnly(2024, 02, 11), 2024, 02, 01, 10 },
                { new DateOnly(2025, 01, 01), 2024, 12, 31, 1 },
                { new DateOnly(2025, 01, 01), 2023, 12, 31, 367 },
                { new DateOnly(2025, 01, 01), 2025, 01, 02, -1 },
                { new DateOnly(2025, 01, 01), 2025, 01, 01, 0 },
                { DateOnly.MinValue, 9999, 12, 31, -3_652_058 },
                { DateOnly.MaxValue, 0001, 01, 01, 3_652_058 }
            };
        }
    }
}
