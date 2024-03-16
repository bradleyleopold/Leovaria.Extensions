namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetLastDayOfYear
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, string expectedResult)
        {
            var result = dateOnly.GetLastDayOfYear();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, string> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, string>
            {
                { new DateOnly(2023, 01, 26), "Sunday" },

                { new DateOnly(2018, 04, 20), "Monday" },

                { new DateOnly(2024, 10, 31), "Tuesday" },

                { new DateOnly(2025, 12, 25), "Wednesday" },

                { new DateOnly(2020, 11, 25), "Thursday" },

                { new DateOnly(2021, 09, 12), "Friday" },

                { new DateOnly(2022, 10, 30), "Saturday" },
            };
        }
    }
}
