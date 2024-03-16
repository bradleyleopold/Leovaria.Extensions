namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetLastDayOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, string expectedResult)
        {
            var result = dateOnly.GetLastDayOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, string> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, string>
            {
                { new DateOnly(2024, 03, 30), "Sunday" },
                { new DateOnly(2023, 12, 25), "Sunday" },

                { new DateOnly(2024, 09, 12), "Monday" },
                { new DateOnly(2023, 07, 27), "Monday" },

                { new DateOnly(2024, 12, 31), "Tuesday" },
                { new DateOnly(2023, 10, 15), "Tuesday" },

                { new DateOnly(2024, 07, 17), "Wednesday" },
                { new DateOnly(2023, 05, 23), "Wednesday" },

                { new DateOnly(2024, 10, 13), "Thursday" },
                { new DateOnly(2023, 11, 29), "Thursday" },

                { new DateOnly(2024, 05, 31), "Friday" },
                { new DateOnly(2023, 06, 01), "Friday" },

                { new DateOnly(2024, 08, 03), "Saturday" },
                { new DateOnly(2023, 09, 27), "Saturday" },
            };
        }
    }
}
