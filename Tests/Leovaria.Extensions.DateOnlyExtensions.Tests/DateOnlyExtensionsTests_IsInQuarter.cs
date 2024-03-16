using Leovaria.Extensions.DateOnlyExtensions.Enums;

namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsInQuarter
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, Quarter quarter, bool expectedResult)
        {
            var result = dateOnly.IsInQuarter(quarter);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, Quarter, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, Quarter, bool>
            {
                { new DateOnly(2024, 03, 31), Quarter.Second, false },
                { new DateOnly(2024, 03, 01), Quarter.Third, false },
                { new DateOnly(2024, 09, 12), Quarter.Fourth, false },
                { new DateOnly(2024, 01, 01), Quarter.First, true },
                { new DateOnly(2023, 01, 01), Quarter.Fourth, false },
                { new DateOnly(2025, 01, 01), Quarter.Second, false },
                { new DateOnly(9999, 10, 01), Quarter.Fourth, true },
                { new DateOnly(2020, 08, 01), Quarter.Third, true },
            };
        }
    }
}
