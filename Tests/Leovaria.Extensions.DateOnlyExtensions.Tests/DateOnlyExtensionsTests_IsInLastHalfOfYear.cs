namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsInLastHalfOfYear
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsInLastHalfOfYear();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, bool>
            {
                { new DateOnly(2024, 03, 31), false },
                { new DateOnly(2024, 03, 01), false },
                { new DateOnly(2024, 09, 12), true },
                { new DateOnly(2024, 01, 01), false },
                { new DateOnly(2023, 01, 01), false },
                { new DateOnly(2025, 01, 01), false },
                { new DateOnly(9999, 10, 01), true },
                { new DateOnly(0001, 07, 01), true },
                { new DateOnly(0001, 07, 02), true },
            };
        }
    }
}
