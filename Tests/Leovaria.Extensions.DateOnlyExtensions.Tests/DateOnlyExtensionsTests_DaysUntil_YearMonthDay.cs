﻿namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_DaysUntil_YearMonthDay
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int year, int month, int day, int expectedResult)
        {
            var result = dateOnly.DaysUntil(year, month, day);
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int, int, int, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int, int, int, int>
            {
                { new DateOnly(2024, 01, 01), 2024, 01, 02, 1 },
                { new DateOnly(2024, 02, 01), 2024, 02, 11, 10 },
                { new DateOnly(2024, 12, 31), 2025, 01, 01, 1 },
            };
        }
    }
}