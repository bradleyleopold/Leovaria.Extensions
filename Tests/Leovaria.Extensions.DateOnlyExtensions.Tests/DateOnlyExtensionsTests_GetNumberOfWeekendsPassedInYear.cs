﻿namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_GetNumberOfWeekendsPassedInYear
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, int expectedResult)
        {
            var result = dateOnly.GetNumberOfWeekendsPassedInYear();
            Assert.Equal(expectedResult, result);
        }

        public static TheoryData<DateOnly, int> GetsExpectedResult_TestData()
        {
            return new TheoryData<DateOnly, int>
            {
                { new DateOnly(2024, 01, 01), 0},
                { new DateOnly(2024, 01, 08), 1},
                { new DateOnly(2024, 12, 31), 52},
            };
        }
    }
}
