namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_AddWeeks
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int weeks, DateOnly expectedResult)
        {
            var result = dateOnly.AddWeeks(weeks);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int, DateOnly>
            {
                { new DateOnly(2024, 03, 31), 0, new DateOnly(2024, 03, 31) },
                { new DateOnly(2024, 03, 01), 1, new DateOnly(2024, 03, 08) },
                { new DateOnly(2024, 03, 08), -1, new DateOnly(2024, 03, 01) },
                { new DateOnly(2024, 01, 01), 4, new DateOnly(2024, 01, 29) },
                { new DateOnly(2024, 01, 01), 52, new DateOnly(2024, 12, 30) },
                { new DateOnly(2024, 12, 30), -52, new DateOnly(2024, 01, 01) },
                { new DateOnly(0001, 10, 01), 2, new DateOnly(0001, 10, 15) },
                { new DateOnly(0001, 10, 15), -2, new DateOnly(0001, 10, 01) },
            };
        }
    }
}
