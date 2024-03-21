
[![MIT License](https://img.shields.io/badge/License-MIT-green.svg)](https://choosealicense.com/licenses/mit/)
# Leovaria Extensions

Extensions for different data types in C#.


## DateOnly Extensions

The `Leovaria.Extensions.DateOnlyExtensions` package provides numerous extension methods for the DateOnly struct in .NET which allows users to easily calculate certain dates, get upcoming or previous dates, check if there is anything special with certain dates, and more.

Users that work with a lot of date logic will hopefully find this package useful.

> [!IMPORTANT]
> This package strictly uses the ***Gregorian Calendar*** to calculate date logic from.
> While the package may work for other calendars in some cases as well, it has not been tested for those. If many users would like to have support for other calendars, let me know and I'd be happy to look into adding support for those as well.

### Some Method Examples

`IsWeekendDay()`
```c#
var date = new DateOnly(2024, 03, 21); // Thursday.
return date.IsWeekendDay(); // Produces boolean 'false'.
```
```c#
var date = new DateOnly(2024, 03, 23); // Saturday.
return date.IsWeekendDay(); // Produces boolean 'true'.
```

`GetLastDateOfMonth()`
```c#
var date = new DateOnly(2024, 03, 21);
return date.GetLastDateOfMonth(); // Produces DateOnly instance of 03/31/2024.
```

`GetNextLeapYearDate()`
```c#
var date = new DateOnly(2024, 09, 08);
return date.GetNextLeapYearDate(); // Produces DateOnly instance of 02/29/2028.
```

`IsLeapDay()`
```c#
var date = new DateOnly(2024, 02, 29);
return date.IsLeapDay(); // Produces boolean 'true'.
```
```c#
var date = new DateOnly(2024, 01, 24);
return date.IsLeapDay(); // Produces boolean 'false'.
```

`GetNextWeekendDates()`
```c#
var date = new DateOnly(2024, 03, 21);
return date.GetNextWeekendDates();
// Produces List of DateOnly instances with
// values 03/23/2024 and 03/24/2024.
```

`GetDaysUntil(DateOnly untilDate)`
```c#
var date = new DateOnly(2024, 03, 21);
var untilDate = new DateOnly(2024, 04, 01);
return date.GetDaysUntil(untilDate); // Produces int '11'.
```

`AddWeeks(int weeks)`
```c#
var date = new DateOnly(2024, 03, 01);
return date.AddWeeks(1); // Produces DateOnly instance of 03/08/2024.
```

`AddFortnights(int fortnights)`
```c#
var date = new DateOnly(2024, 03, 01);
return date.AddFortnights(1); // Produces DateOnly instance of 03/15/2024.
```
## String Extensions (Coming soon)

More to come on this package soon.
## Special Thanks

- readme.so for giving me an easy tool to write this readme with.
- shields.io for providing a nice License MIT badge.
