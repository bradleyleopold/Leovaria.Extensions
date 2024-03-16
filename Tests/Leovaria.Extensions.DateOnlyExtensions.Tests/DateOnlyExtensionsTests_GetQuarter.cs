using Leovaria.Extensions.DateOnlyExtensions.Enums;

namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetQuarter
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, Quarter expectedResult)
        {
            var result = dateOnly.GetQuarter();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, Quarter> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, Quarter>
            {
                { new DateOnly(2024, 03, 31), Quarter.First },
                { new DateOnly(2024, 03, 01), Quarter.First },
                { new DateOnly(2024, 02, 01), Quarter.First },
                { new DateOnly(2024, 09, 12), Quarter.Third },
                { new DateOnly(2024, 01, 01), Quarter.First },
                { new DateOnly(2023, 01, 01), Quarter.First },
                { new DateOnly(2025, 01, 01), Quarter.First },
                { new DateOnly(9999, 10, 01), Quarter.Fourth },
                { new DateOnly(0001, 07, 01), Quarter.Third },
                { new DateOnly(0001, 07, 02), Quarter.Third },
                { new DateOnly(2024, 07, 02), Quarter.Third },
                { new DateOnly(2025, 07, 02), Quarter.Third },
                { new DateOnly(2025, 05, 02), Quarter.Second },
                { new DateOnly(2023, 06, 03), Quarter.Second },
                { new DateOnly(2023, 08, 31), Quarter.Third },
                { new DateOnly(2028, 11, 30), Quarter.Fourth },
                { new DateOnly(2028, 12, 30), Quarter.Fourth },
            };
        }
    }
}
