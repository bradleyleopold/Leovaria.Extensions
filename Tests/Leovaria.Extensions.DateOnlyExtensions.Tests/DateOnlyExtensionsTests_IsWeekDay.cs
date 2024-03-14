namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsWeekDay
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsWeekDay();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, bool>
            {
                { new DateOnly(2024, 03, 01), true },
                { new DateOnly(2024, 02, 29), true },
                { new DateOnly(2024, 03, 02), false },
                { new DateOnly(2024, 03, 03), false },
            };
        }
    }
}
