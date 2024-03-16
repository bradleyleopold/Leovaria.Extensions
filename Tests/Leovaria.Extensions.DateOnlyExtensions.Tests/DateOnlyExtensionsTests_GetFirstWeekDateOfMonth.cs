namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetFirstWeekDateOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly expectedResult)
        {
            var result = dateOnly.GetFirstWeekDateOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 09, 30), new DateOnly(2024, 09, 02) },
                { new DateOnly(2023, 10, 30), new DateOnly(2023, 10, 02) },
                { new DateOnly(2024, 01, 26), new DateOnly(2024, 01, 01) },
                { new DateOnly(2023, 05, 29), new DateOnly(2023, 05, 01) },
                { new DateOnly(2024, 10, 31), new DateOnly(2024, 10, 01) },
                { new DateOnly(2024, 06, 08), new DateOnly(2024, 06, 03) },
            };
        }
    }
}
