namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetLastDateOfMonth
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, DateOnly expectedResult)
        {
            var result = dateOnly.GetLastDateOfMonth();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, DateOnly> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, DateOnly>
            {
                { new DateOnly(2024, 09, 30), new DateOnly(2024, 09, 30) },
                { new DateOnly(2023, 10, 30), new DateOnly(2023, 10, 31) },
                { new DateOnly(2024, 01, 26), new DateOnly(2024, 01, 31) },
                { new DateOnly(2023, 05, 29), new DateOnly(2023, 05, 31) },
                { new DateOnly(2024, 10, 31), new DateOnly(2024, 10, 31) },
                { new DateOnly(2023, 08, 15), new DateOnly(2023, 08, 31) },
                { new DateOnly(2024, 05, 17), new DateOnly(2024, 05, 31) },
                { new DateOnly(2023, 11, 23), new DateOnly(2023, 11, 30) },
                { new DateOnly(2024, 02, 23), new DateOnly(2024, 02, 29) },
                { new DateOnly(2023, 02, 20), new DateOnly(2023, 02, 28) },
            };
        }
    }
}
