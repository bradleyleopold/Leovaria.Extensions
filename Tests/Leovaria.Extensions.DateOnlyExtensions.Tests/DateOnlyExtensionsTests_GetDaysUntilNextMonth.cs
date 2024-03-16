namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetDaysUntilNextMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int expectedResult)
        {
            var result = dateOnly.GetDaysUntilNextMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int>
            {
                { new DateOnly(2024, 03, 01), 31 },
                { new DateOnly(2024, 02, 29), 1 },
                { new DateOnly(2024, 03, 02), 30 },
                { new DateOnly(2024, 02, 01), 29 },
            };
        }
    }
}
