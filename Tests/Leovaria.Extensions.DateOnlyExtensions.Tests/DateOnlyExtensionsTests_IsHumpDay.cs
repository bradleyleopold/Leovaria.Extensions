namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsHumpDay
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsHumpDay();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, bool>
            {
                { new DateOnly(2024, 03, 16), false },
                { new DateOnly(2024, 03, 15), false },
                { new DateOnly(2024, 03, 14), false },
                { new DateOnly(2024, 03, 13), true },
                { new DateOnly(2024, 03, 12), false },
                { new DateOnly(2024, 03, 11), false },
                { new DateOnly(2024, 03, 10), false },
                { new DateOnly(2024, 03, 06), true },
                { new DateOnly(2024, 02, 28), true },
                { new DateOnly(2024, 02, 21), true },
                { new DateOnly(2024, 01, 24), true },
            };
        }
    }
}
