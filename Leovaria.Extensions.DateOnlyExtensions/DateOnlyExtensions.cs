using Leovaria.Extensions.DateOnlyExtensions.Enums;
using System.Globalization;

namespace Leovaria.Extensions.DateOnlyExtensions;
/// <summary>
/// Extensions for <see cref="DateOnly"/>. 
/// This extensions library assumes the use of the
/// Gregorian calendar currently. Therefore, results
/// given are based on the Gregorian calendar. Enhancements
/// for other calendars can be made down the road if users
/// would like to have that as well.
/// </summary>
public static class DateOnlyExtensions
{
    /// <summary>
    /// Gregorian calendar used in the extension methods.
    /// </summary>
    private static GregorianCalendar _gregorianCalendar = new();

    /// <summary>
    /// Gets the name of the first day of the month in regards to the
    /// <paramref name="value"/> input.
    /// </summary>
    /// <param name="value">Input DateOnly to get first day of month relative to.</param>
    /// <returns>
    /// The name of the day at the beginning of the month
    /// (i.e., Monday, Tuesday, etc.)
    /// </returns>
    public static string GetFirstDayOfMonth(this DateOnly value)
    {
        var firstDate = new DateOnly(value.Year, value.Month, 1);
        return firstDate.DayOfWeek.ToString();
    }

    /// <summary>
    /// Gets the name of the last day of the month in regards to the
    /// <paramref name="value"/> input.
    /// </summary>
    /// <param name="value">Input DateOnly to get last day of month relative to.</param>
    /// <returns>
    /// The name of the day at the end of the month
    /// (i.e., Monday, Tuesday, etc.)
    /// </returns>
    public static string GetLastDayOfMonth(this DateOnly value)
    {
        var lastDateOfMonth = new DateOnly(value.Year, value.Month, _gregorianCalendar.GetDaysInMonth(value.Year, value.Month));
        return lastDateOfMonth.DayOfWeek.ToString();
    }

    /// <summary>
    /// Gets the name of the first day of the year relative to the
    /// <paramref name="value"/> input.
    /// </summary>
    /// <param name="value">DateOnly to get first day of the year relative to.</param>
    /// <returns>
    /// The name of the day at the first of year.
    /// (i.e., Monday, Tuesday, etc.)
    /// </returns>
    public static string GetFirstDayOfYear(this DateOnly value)
    {
        var firstDateOfYear = new DateOnly(value.Year, 1, 1);
        return firstDateOfYear.DayOfWeek.ToString();
    }

    /// <summary>
    /// Gets the name of the last day of the year relative to the
    /// <paramref name="value"/> input.
    /// </summary>
    /// <param name="value">DateOnly to get last day of the year relative to.</param>
    /// <returns>
    /// The name of the day at the end of year.
    /// (i.e., Monday, Tuesday, etc.)
    /// </returns>
    public static string GetLastDayOfYear(this DateOnly value)
    {
        var lastDateOfYear = new DateOnly(value.Year, 12, 31);
        return lastDateOfYear.DayOfWeek.ToString();
    }

    /// <summary>
    /// Gets the previous leap year date that occurred relative to the
    /// <paramref name="value"/> date.
    /// </summary>
    /// <param name="value">Date to get the relative previous leap date of.</param>
    /// <returns>The last leap year date that occurred prior to <paramref name="value"/>.</returns>
    public static DateOnly GetPreviousLeapYearDate(this DateOnly value)
    {
        var loopDate = value;

        if (loopDate.IsLeapDay() || loopDate <= new DateOnly(value.Year, 02, 28))
        {
            loopDate = new DateOnly(value.Year - 1, 12, 31);
        }

        while (!loopDate.IsInLeapYear())
        {
            loopDate = loopDate.AddYears(-1);
        }

        return new DateOnly(loopDate.Year, 02, 29);
    }

    /// <summary>
    /// Gets the next leap year date that occurred relative to the
    /// <paramref name="value"/> date.
    /// </summary>
    /// <param name="value">Date to get the relative next leap date of.</param>
    /// <returns>The next leap year date relative to <paramref name="value"/>.</returns>
    public static DateOnly GetNextLeapYearDate(this DateOnly value)
    {
        var loopDate = value;

        if (loopDate.IsLeapDay() || loopDate >= new DateOnly(value.Year, 03, 01))
        {
            loopDate = new DateOnly(value.Year + 1, 12, 31);
        }

        while (!loopDate.IsInLeapYear())
        {
            loopDate = loopDate.AddYears(1);
        }

        return new DateOnly(loopDate.Year, 02, 29);
    }

    /// <summary>
    /// Denotes whether the <paramref name="value"/> is a
    /// leap day (February 29th) day or not.
    /// </summary>
    /// <param name="value">DateOnly to check.</param>
    /// <returns>True if it is, false if not.</returns>
    public static bool IsLeapDay(this DateOnly value)
    {
        if (_gregorianCalendar.IsLeapDay(value.Year, value.Month, value.Day))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Denotes whether the <paramref name="value"/> date
    /// is part of a year which has an extra day for
    /// February 29th.
    /// </summary>
    /// <param name="value">DateOnly to check.</param>
    /// <returns>
    /// True if <paramref name="value"/> is within a 
    /// leap year, false if not.
    /// </returns>
    public static bool IsInLeapYear(this DateOnly value)
    {
        if (_gregorianCalendar.IsLeapYear(value.Year))
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// Provides the amount of day(s) until the next leap day occurrence.
    /// </summary>
    /// <param name="value">DateOnly to calculate the next leap day amount from.</param>
    /// <returns>The number of days until the next leap day.</returns>
    public static int GetDaysUntilNextLeapDay(this DateOnly value)
    {
        var nextLeapYearDate = value.GetNextLeapYearDate();
        return nextLeapYearDate.DayNumber - value.DayNumber;
    }

    /// <summary>
    /// Provides the amount of day(s) since the last leap day occurrence.
    /// </summary>
    /// <param name="value">DateOnly to calculate the previous leap day amount from.</param>
    /// <returns>The number of days that has passed since last leap day.</returns>
    public static int GetDaysSinceLastLeapDay(this DateOnly value)
    {
        var previousLeapYearDate = value.GetPreviousLeapYearDate();
        return value.DayNumber - previousLeapYearDate.DayNumber;
    }

    /// <summary>
    /// Denotes whether the <paramref name="value"/> is a weekend day.
    /// </summary>
    /// <param name="value">DateOnly to check.</param>
    /// <returns>True if it is a weekend day, false otherwise.</returns>
    public static bool IsWeekendDay(this DateOnly value) =>
        value.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    /// <summary>
    /// Denotes whether the <paramref name="value"/> is a week day.
    /// </summary>
    /// <param name="value">DateOnly to check.</param>
    /// <returns>True if it is a week day, false otherwise.</returns>
    public static bool IsWeekDay(this DateOnly value) => !value.IsWeekendDay();

    /// <summary>
    /// Gets the dates of the next weekend occurrence.
    /// </summary>
    /// <param name="value">DateOnly to check against.</param>
    /// <returns>List of DateOnly of the next weekend dates.</returns>
    public static List<DateOnly> GetNextWeekendDates(this DateOnly value)
    {
        var loopDate = value;

        do
        {
            loopDate = loopDate.AddDays(1);
        }
        while (loopDate.DayOfWeek != DayOfWeek.Saturday);

        return [loopDate, loopDate.AddDays(1)];
    }

    /// <summary>
    /// Gets the dates of the previous weekend occurrence.
    /// </summary>
    /// <param name="value">DateOnly to check against.</param>
    /// <returns>List of DateOnly of the prior weekend dates.</returns>
    public static List<DateOnly> GetPreviousWeekendDates(this DateOnly value)
    {
        var loopDate = value;

        do
        {
            loopDate = loopDate.AddDays(-1);
        }
        while (loopDate.DayOfWeek != DayOfWeek.Sunday);

        return [loopDate.AddDays(-1), loopDate];
    }

    /// <summary>
    /// Calculates how many weekends are left in the year.
    /// </summary>
    /// <param name="value">DateOnly date used to start calcuation from.</param>
    /// <returns>Number of weekends left in the year.</returns>
    public static int GetNumberOfWeekendsLeftInYear(this DateOnly value)
    {
        var loopDate = value;
        var weekends = 0;

        do
        {
            loopDate = loopDate.GetNextWeekendDates()[0];
            weekends++;
        }
        while (loopDate < new DateOnly(value.Year + 1, 1, 1));

        return weekends;
    }

    /// <summary>
    /// Calculates how many weekends have passed in relation to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">DateOnly date used to start calcuation from.</param>
    /// <returns>Number of weekends passed in the year.</returns>
    public static int GetNumberOfWeekendsPassedInYear(this DateOnly value)
    {
        var loopDate = value;
        var weekends = 0;

        do
        {
            loopDate = loopDate.GetPreviousWeekendDates()[1];

            if (loopDate.Year == value.Year)
            {
                weekends++;
            }
        }
        while (loopDate > new DateOnly(value.Year - 1, 12, 31));

        return weekends;
    }

    /// <summary>
    /// Gets the week's number for the year in relation to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">DateOnly to check from.</param>
    /// <param name="calendarWeekRule">How to determine first week of the year.</param>
    /// <param name="firstDayOfWeek">Which day is the start of the week.</param>
    /// <returns>The number of the week relative to <paramref name="value"/> date.</returns>
    public static int GetWeekNumber(this DateOnly value, CalendarWeekRule calendarWeekRule = CalendarWeekRule.FirstDay, 
        DayOfWeek firstDayOfWeek = DayOfWeek.Sunday)
    {
        var dateTimeEquivalent = value.ToDateTime(TimeOnly.MinValue);
        return _gregorianCalendar.GetWeekOfYear(dateTimeEquivalent, calendarWeekRule, firstDayOfWeek);
    }

    /// <summary>
    /// Calculates the amount of days from <paramref name="value"/>
    /// until the first day of the next month begins.
    /// </summary>
    /// <param name="value">Date to start calculation from.</param>
    /// <returns>Days until the first day of the next month.</returns>
    public static int GetDaysUntilNextMonth(this DateOnly value)
    {
        var valuePlusOneMonth = value.AddMonths(1);
        var nextMonthFirstDate = new DateOnly(valuePlusOneMonth.Year, valuePlusOneMonth.Month, 1);
        return nextMonthFirstDate.DayNumber - value.DayNumber;
    }

    /// <summary>
    /// Calculates the amount of days from <paramref name="value"/>
    /// until the first day of the next year begins.
    /// </summary>
    /// <param name="value">Date to start calculation from.</param>
    /// <returns>Days until the first of the next year.</returns>
    public static int GetDaysUntilNextYear(this DateOnly value)
    {
        var nextYearFirstDate = new DateOnly(value.Year + 1, 1, 1);
        return nextYearFirstDate.DayNumber - value.DayNumber;
    }

    /// <summary>
    /// Calculates the amount of days from <paramref name="value"/>
    /// until <paramref name="untilDate"/>.
    /// </summary>
    /// <param name="value">Date to start calculation from.</param>
    /// <param name="untilDate">Date to stop calculation on.</param>
    /// <returns>Days from <paramref name="value"/> until <paramref name="untilDate"/>.</returns>
    public static int GetDaysUntil(this DateOnly value, DateOnly untilDate) =>
        untilDate.DayNumber - value.DayNumber;

    /// <summary>
    /// Calculates the amount of days from <paramref name="value"/>
    /// until <paramref name="untilDate"/>.
    /// </summary>
    /// <param name="value">Date to start calculation from.</param>
    /// <param name="untilDate">Date to stop calculation on.</param>
    /// <returns>Days from <paramref name="value"/> until <paramref name="untilDate"/>.</returns>
    public static int GetDaysUntil(this DateOnly value, DateTime untilDate) => 
        DateOnly.FromDateTime(untilDate).DayNumber - value.DayNumber;

    /// <summary>
    /// Calculates the amount of days from <paramref name="value"/>
    /// until the specified <paramref name="year"/>, <paramref name="month"/>, and <paramref name="day"/>.
    /// </summary>
    /// <param name="value">Date to start calculation from.</param>
    /// <param name="year">Specified year.</param>
    /// <param name="month">Specified month.</param>
    /// <param name="day">Specified day.</param>
    /// <returns>Days from <paramref name="value"/> until <paramref name="year"/>/<paramref name="month"/>/<paramref name="day"/>.</returns>
    public static int GetDaysUntil(this DateOnly value, int year, int month, int day) =>
        new DateOnly(year, month, day).DayNumber - value.DayNumber;

    /// <summary>
    /// Calculates the amount of days that have passed from <paramref name="sinceDate"/>
    /// to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">Date to end calculation to.</param>
    /// <param name="sinceDate">Date to start calculation from.</param>
    /// <returns>Amount of days since <paramref name="sinceDate"/> to <paramref name="value"/>.</returns>
    public static int GetDaysSince(this DateOnly value, DateOnly sinceDate) =>
        value.DayNumber - sinceDate.DayNumber;

    /// <summary>
    /// Calculates the amount of days that have passed from <paramref name="sinceDate"/>
    /// to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">Date to end calculation to.</param>
    /// <param name="sinceDate">Date to start calculation from.</param>
    /// <returns>Amount of days since <paramref name="sinceDate"/> to <paramref name="value"/>.</returns>
    public static int GetDaysSince(this DateOnly value, DateTime sinceDate) =>
        value.DayNumber - DateOnly.FromDateTime(sinceDate).DayNumber;

    /// <summary>
    /// Calculates the amount of days that have passed from
    /// <param name="year"/>/<paramref name="month"/>/<paramref name="day"/>
    /// to <paramref name="value"/>.
    /// </summary>
    /// <param name="value">Date to end calculation to.</param>
    /// <param name="year">Specified year.</param>
    /// <param name="month">Specified month.</param>
    /// <param name="day">Specified day.</param>
    /// <returns>Amount of days since <paramref name="year"/>/<paramref name="month"/>/<paramref name="day"/>
    /// to <paramref name="value"/>.</returns>
    public static int GetDaysSince(this DateOnly value, int year, int month, int day) =>
        value.DayNumber - new DateOnly(year, month, day).DayNumber;

    /// <summary>
    /// Denotes whether <paramref name="value"/> is the first date of the month.
    /// </summary>
    /// <param name="value">The date to check.</param>
    /// <returns>True if it is the first date of the month, false otherwise.</returns>
    public static bool IsFirstDateOfMonth(this DateOnly value) =>
        new DateOnly(value.Year, value.Month, 01) == value;

    /// <summary>
    /// Denotes whether <paramref name="value"/> is the last date of the month.
    /// </summary>
    /// <param name="value">The date to check.</param>
    /// <returns>True if it is the last date of the month, false otherwise.</returns>
    public static bool IsLastDateOfMonth(this DateOnly value)
    {
        var daysInMonth = _gregorianCalendar.GetDaysInMonth(value.Year, value.Month);
        return new DateOnly(value.Year, value.Month, daysInMonth) == value;
    }

    /// <summary>
    /// Gets the midpoint date of the year that <paramref name="value"/> resides in.
    /// </summary>
    /// <param name="value">The date to get year information from.</param>
    /// <returns>The middle date of the year.</returns>
    public static DateOnly GetYearMidpointDate(this DateOnly value) =>
        value.IsInLeapYear()
            ? new DateOnly(value.Year, 07, 02)
            : new DateOnly(value.Year, 07, 01);

    /// <summary>
    /// Denotes if <paramref name="value"/> is in the first half of the year.
    /// </summary>
    /// <param name="value">The date to check.</param>
    /// <returns>True if the date is in the first half of the year, false otherwise.</returns>
    public static bool IsInFirstHalfOfYear(this DateOnly value) =>
        value <= GetYearMidpointDate(value);

    /// <summary>
    /// Denotes if <paramref name="value"/> is in the last half of the year.
    /// </summary>
    /// <param name="value">The date to check.</param>
    /// <returns>True if the date is in the last half of the year, false otherwise.</returns>
    public static bool IsInLastHalfOfYear(this DateOnly value) =>
        value >= GetYearMidpointDate(value);

    /// <summary>
    /// Denotes if <paramref name="value"/> is the date in the center of the year.
    /// </summary>
    /// <param name="value">The date to check.</param>
    /// <returns>True if the date is the midpoint date of the year, false otherwise.</returns>
    public static bool IsYearMidpointDate(this DateOnly value) =>
        value == GetYearMidpointDate(value);

    /// <summary>
    /// Gets which quarter <paramref name="value"/> resides within the year.
    /// </summary>
    /// <param name="value">The date to check which quarter it's in.</param>
    /// <returns>First, Second, Third, or Fourth quarter.</returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Thrown if a faulty date is provided.
    /// </exception>
    public static Quarter GetQuarter(this DateOnly value)
    {
        return value.Month switch
        {
            1 or 2 or 3 => Quarter.First,
            4 or 5 or 6 => Quarter.Second,
            7 or 8 or 9 => Quarter.Third,
            10 or 11 or 12 => Quarter.Fourth,
            _ => throw new ArgumentOutOfRangeException(nameof(value), $"Unexpected date: {value}")
        };
    }

    /// <summary>
    /// Denotes if <paramref name="value"/> resides within the <paramref name="quarter"/>
    /// part of the year.
    /// </summary>
    /// <param name="value">The date to check.</param>
    /// <param name="quarter">Which quarter to check and see if the date resides in.</param>
    /// <returns>
    /// True if <paramref name="value"/> resides within 
    /// <paramref name="quarter"/>, false otherwise.
    /// </returns>
    public static bool IsInQuarter(this DateOnly value, Quarter quarter) =>
        value.GetQuarter() == quarter;

    /// <summary>
    /// Adds the amount of weeks to the provided <paramref name="value"/>, where
    /// one week represents seven days.
    /// </summary>
    /// <param name="value">The date to add weeks to.</param>
    /// <param name="weeks">How many weeks to add.</param>
    /// <returns>
    /// New instance of <see cref="DateOnly"/> that is generated after adding 
    /// <paramref name="weeks"/> to <paramref name="value"/>.
    /// </returns>
    public static DateOnly AddWeeks(this DateOnly value, int weeks) =>
        value.AddDays(weeks * 7);

    /// <summary>
    /// Adds the amount of fortnights to the provided <paramref name="value"/>, where
    /// one fortnight represents fourteen days (two weeks.)
    /// </summary>
    /// <param name="value">The date to add fortnights to.</param>
    /// <param name="fortnights">How many fortnights to add.</param>
    /// <returns>
    /// New instance of <see cref="DateOnly"/> that is generated after adding 
    /// <paramref name="fortnights"/> to <paramref name="value"/>.
    /// </returns>
    public static DateOnly AddFortnights(this DateOnly value, int fortnights) =>
        value.AddWeeks(fortnights * 2);
}