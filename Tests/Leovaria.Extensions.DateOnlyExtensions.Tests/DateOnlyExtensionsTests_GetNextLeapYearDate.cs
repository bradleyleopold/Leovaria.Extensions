namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetNextLeapYearDate
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly value, DateOnly expectedResult)
        {
            var result = value.GetNextLeapYearDate();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 03, 09), new DateOnly(2028, 02, 29) },
                { new DateOnly(2024, 02, 29), new DateOnly(2028, 02, 29) },
                { new DateOnly(2024, 02, 28), new DateOnly(2024, 02, 29) },
                { new DateOnly(2024, 01, 01), new DateOnly(2024, 02, 29) },
                { new DateOnly(2019, 01, 01), new DateOnly(2020, 02, 29) },
                { new DateOnly(2014, 04, 20), new DateOnly(2016, 02, 29) },
                { new DateOnly(2012, 02, 28), new DateOnly(2012, 02, 29) },
            };
        }
    }
}
