namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_IsLeapDay
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly dateOnly, bool expectedResult)
        {
            var result = dateOnly.IsLeapDay();
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> GetsExpectedResult_TestData()
        {
            yield return new object[]
            {
                new DateOnly(2024, 03, 09),
                false
            };

            yield return new object[]
            {
                new DateOnly(2024, 02, 29),
                true
            };

            yield return new object[]
            {
                new DateOnly(2024, 02, 28),
                false
            };

            yield return new object[]
            {
                new DateOnly(2028, 02, 29),
                true
            };

            yield return new object[]
            {
                new DateOnly(2020, 02, 29),
                true
            };
        }
    }
}
