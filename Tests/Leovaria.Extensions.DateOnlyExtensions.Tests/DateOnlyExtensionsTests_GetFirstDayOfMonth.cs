namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetFirstDayOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, string expectedResult)
        {
            var result = dateOnly.GetFirstDayOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, string> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, string>
            {
                { new DateOnly(2024, 09, 30), "Sunday" },
                { new DateOnly(2023, 10, 30), "Sunday" },

                { new DateOnly(2024, 01, 26), "Monday" },
                { new DateOnly(2023, 05, 29), "Monday" },

                { new DateOnly(2024, 10, 31), "Tuesday" },
                { new DateOnly(2023, 08, 15), "Tuesday" },

                { new DateOnly(2024, 05, 17), "Wednesday" },
                { new DateOnly(2023, 11, 23), "Wednesday" },

                { new DateOnly(2024, 08, 13), "Thursday" },
                { new DateOnly(2023, 06, 29), "Thursday" },

                { new DateOnly(2024, 03, 31), "Friday" },
                { new DateOnly(2024, 03, 01), "Friday" },
                { new DateOnly(2023, 09, 12), "Friday" },

                { new DateOnly(2024, 06, 03), "Saturday" },
                { new DateOnly(2023, 07, 27), "Saturday" },
            };
        }
    }
}
