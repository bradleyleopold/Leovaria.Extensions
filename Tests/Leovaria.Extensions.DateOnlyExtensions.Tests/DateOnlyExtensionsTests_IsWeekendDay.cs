namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsWeekendDay
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsWeekendDay();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, bool>
            {
                { new DateOnly(2024, 03, 01), false },
                { new DateOnly(2024, 02, 29), false },
                { new DateOnly(2024, 03, 02), true },
                { new DateOnly(2024, 03, 03), true },
            };
        }
    }
}
