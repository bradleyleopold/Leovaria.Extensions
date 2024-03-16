namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetFirstDayOfYear
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, string expectedResult)
        {
            var result = dateOnly.GetFirstDayOfYear();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, string> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, string>
            {
                { new DateOnly(2023, 10, 30), "Sunday" },

                { new DateOnly(2024, 01, 26), "Monday" },

                { new DateOnly(2019, 09, 08), "Tuesday" },

                { new DateOnly(2020, 07, 27), "Wednesday" },

                { new DateOnly(2015, 12, 25), "Thursday" },

                { new DateOnly(2021, 06, 03), "Friday" },

                { new DateOnly(2022, 05, 17), "Saturday" },
            };
        }
    }
}
