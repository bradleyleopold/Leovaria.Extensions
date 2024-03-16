namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_YearMidpointDate
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly expectedResult)
        {
            var result = dateOnly.YearMidpointDate();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 03, 31), new DateOnly(2024, 07, 02) },
                { new DateOnly(2024, 03, 01), new DateOnly(2024, 07, 02) },
                { new DateOnly(2024, 09, 12), new DateOnly(2024, 07, 02) },
                { new DateOnly(2024, 01, 01), new DateOnly(2024, 07, 02) },
                { new DateOnly(2023, 01, 01), new DateOnly(2023, 07, 01) },
                { new DateOnly(2025, 01, 01), new DateOnly(2025, 07, 01) },
            };
        }
    }
}
