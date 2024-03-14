namespace Leovaria.Extensions.DateOnlyExtensions.Tests
{
    public sealed class DateOnlyExtensionsTests_NextLeapYearDate
    {
        [Theory]
        [MemberData(nameof(GetsExpectedResult_TestData))]
        public void GetsExpectedResult(DateOnly value, DateOnly expectedResult)
        {
            // Act
            var result = value.NextLeapYearDate();

            // Assert
            Assert.Equal(expectedResult, result);
        }

        public static IEnumerable<object[]> GetsExpectedResult_TestData()
        {
            yield return new object[]
            {
                new DateOnly(2024, 03, 09),
                new DateOnly(2028, 02, 29)
            };

            yield return new object[]
            {
                new DateOnly(2024, 02, 29),
                new DateOnly(2028, 02, 29)
            };

            yield return new object[]
            {
                new DateOnly(2024, 02, 28),
                new DateOnly(2024, 02, 29)
            };

            yield return new object[]
            {
                new DateOnly(2024, 01, 01),
                new DateOnly(2024, 02, 29)
            };
        }
    }
}
