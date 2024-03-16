namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetPreviousLeapYearDate
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly value, DateOnly expectedResult)
        {
            var result = value.GetPreviousLeapYearDate();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 03, 09), new DateOnly(2024, 02, 29) },
                { new DateOnly(2024, 02, 29), new DateOnly(2020, 02, 29) },
                { new DateOnly(2024, 02, 28), new DateOnly(2020, 02, 29) },
                { new DateOnly(2024, 01, 01), new DateOnly(2020, 02, 29) },
                { new DateOnly(2019, 01, 26), new DateOnly(2016, 02, 29) },
                { new DateOnly(2015, 10, 31), new DateOnly(2012, 02, 29) },
            };
        }
    }
}
