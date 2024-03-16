namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetDaysUntilNextLeapDay
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int expectedResult)
        {
            var result = dateOnly.GetDaysUntilNextLeapDay();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int>
            {
                { new DateOnly(2024, 02, 28), 1 },
                { new DateOnly(2024, 02, 29), 1461 },
                { new DateOnly(2024, 02, 27), 2 }
            };
        }
    }
}
