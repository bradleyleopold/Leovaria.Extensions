namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsLastDateOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsLastDateOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, bool>
            {
                { new DateOnly(2024, 03, 31), true },
                { new DateOnly(2024, 01, 01), false },
                { new DateOnly(0001, 01, 31), true },
                { new DateOnly(9999, 12, 31), true },
                { new DateOnly(2020, 10, 30), false },
                { new DateOnly(2024, 02, 29), true },
                { new DateOnly(2024, 05, 02), false },
                { new DateOnly(2024, 05, 01), false },
                { new DateOnly(2024, 05, 31), true },
                { new DateOnly(2024, 06, 30), true },
                { new DateOnly(2024, 07, 31), true },
            };
        }
    }
}
