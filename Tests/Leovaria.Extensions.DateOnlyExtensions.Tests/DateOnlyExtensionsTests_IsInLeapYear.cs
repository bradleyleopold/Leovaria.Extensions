namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsInLeapYear
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsInLeapYear();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, bool>
            {
                { new DateOnly(2024, 03, 09), true },
                { new DateOnly(2023, 02, 28), false },
                { new DateOnly(2024, 02, 29), true },
                { new DateOnly(2022, 02, 28), false },
                { new DateOnly(2020, 02, 29), true },
                { new DateOnly(2020, 02, 28), true },
                { new DateOnly(2028, 02, 29), true },
                { new DateOnly(2028, 03, 01), true },
                { new DateOnly(2028, 10, 31), true },
                { new DateOnly(2018, 12, 31), false }
            };
        }
    }
}
