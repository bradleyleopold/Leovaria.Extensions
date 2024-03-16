namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetFirstWeekendDateOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly expectedResult)
        {
            var result = dateOnly.GetFirstWeekendDateOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 09, 30), new DateOnly(2024, 09, 01) },
                { new DateOnly(2023, 10, 30), new DateOnly(2023, 10, 01) },
                { new DateOnly(2024, 01, 26), new DateOnly(2024, 01, 06) },
                { new DateOnly(2023, 05, 29), new DateOnly(2023, 05, 06) },
                { new DateOnly(2024, 10, 31), new DateOnly(2024, 10, 05) },
                { new DateOnly(2024, 06, 08), new DateOnly(2024, 06, 01) },
                { new DateOnly(2024, 03, 02), new DateOnly(2024, 03, 02) },
                { new DateOnly(2024, 02, 02), new DateOnly(2024, 02, 03) },
                { new DateOnly(2024, 02, 02), new DateOnly(2024, 02, 03) },
                { new DateOnly(2025, 01, 02), new DateOnly(2025, 01, 04) },
            };
        }
    }
}
