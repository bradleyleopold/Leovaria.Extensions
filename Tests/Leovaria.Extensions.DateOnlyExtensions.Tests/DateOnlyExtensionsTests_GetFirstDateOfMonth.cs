namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetFirstDateOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly expectedResult)
        {
            var result = dateOnly.GetFirstDateOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 09, 30), new DateOnly(2024, 09, 01) },
                { new DateOnly(2023, 10, 30), new DateOnly(2023, 10, 01) },
                { new DateOnly(2024, 01, 26), new DateOnly(2024, 01, 01) },
                { new DateOnly(2023, 05, 29), new DateOnly(2023, 05, 01) },
                { new DateOnly(2024, 10, 31), new DateOnly(2024, 10, 01) },
                { new DateOnly(2023, 08, 15), new DateOnly(2023, 08, 01) },
                { new DateOnly(2024, 05, 17), new DateOnly(2024, 05, 01) },
                { new DateOnly(2023, 11, 23), new DateOnly(2023, 11, 01) },
            };
        }
    }
}
