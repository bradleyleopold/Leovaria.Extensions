namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetWeekendNumber
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int expectedResult)
        {
            var result = dateOnly.GetWeekNumber();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int>
            {
                { new DateOnly(2024, 01, 01), 1},
                { new DateOnly(2024, 01, 08), 2},
                { new DateOnly(2024, 01, 10), 2},
                { new DateOnly(2024, 01, 13), 2},
                { new DateOnly(2024, 01, 14), 3},
                { new DateOnly(2024, 12, 31), 53},
                { new DateOnly(2024, 12, 25), 52},
            };
        }
    }
}

