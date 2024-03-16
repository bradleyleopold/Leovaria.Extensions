namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsFirstDateOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsFirstDateOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, bool> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, bool>
            {
                { new DateOnly(2024, 03, 01), true },
                { new DateOnly(2024, 01, 01), true },
                { new DateOnly(0001, 01, 01), true },
                { new DateOnly(9999, 12, 01), true },
                { new DateOnly(2020, 10, 31), false },
                { new DateOnly(2024, 02, 29), false },
                { new DateOnly(2024, 05, 02), false },
            };
        }
    }
}
