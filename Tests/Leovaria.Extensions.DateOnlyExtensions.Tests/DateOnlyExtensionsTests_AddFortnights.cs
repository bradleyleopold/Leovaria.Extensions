namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_AddFortnights
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int fortnights, DateOnly expectedResult)
        {
            var result = dateOnly.AddFortnights(fortnights);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int, DateOnly>
            {
                { new DateOnly(2024, 03, 31), 0, new DateOnly(2024, 03, 31) },
                { new DateOnly(2024, 03, 01), 1, new DateOnly(2024, 03, 15) },
                { new DateOnly(2024, 03, 15), -1, new DateOnly(2024, 03, 01) },
                { new DateOnly(2024, 01, 01), 4, new DateOnly(2024, 02, 26) },
            };
        }
    }
}
