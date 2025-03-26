
using System;
using System.Globalization;
using WebApi.Common;

namespace PersianLibrary
{
    /// <summary>
    /// PersianCalendar calendar. Persian calendar, also named Jalaali calendar, was first based on Solar year by Omar Khayyam, the great Iranian poet, astrologer and scientist.
    /// Jalaali calendar is approximately 365 days. Each of the first six months in the Jalaali calendar has 31 days, each of the next five months has 30 days, and the last month has 29 days in a common year and 30 days in a leap year. A leap year is a year that, when divided by 33, has a remainder of 1, 5, 9, 13, 17, 22, 26, or 30. For example, the year 1370 is a leap year because dividing it by 33 yields a remainder of 17. There are approximately 8 leap years in every 33 year cycle.
    /// </summary>
    [Serializable]
    public class PersianCalendar : Calendar
    {
        string msgCultureError = "Your language Culture is not supported in Calendar .";
        /// <summary>
        /// Represents the current era.
        /// </summary>
        /// <remarks>The Persian calendar recognizes one era: A.P. (Latin "Anno Persarum", which means "the year of/for Persians").</remarks>
        public static readonly int PersianEra = 1;
        #region Calculate This Month Days
        /// <summary>
        ///	   Culculate This Month Days
        /// </summary>
        /// <param name="FinYear"></param>
        /// <param name="Month"></param>
        /// <returns></returns>
        public int MonthDaysNumbers(int FinYear, int Month)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))
            {
                int ThisMonthDays = 0;
                DateTime t;
                int temp = FinYear;
                if (Month != 12)
                {
                    t = this.ToDateTime(temp, Month + 1, 1, 0, 0, 0, 0);
                }
                else
                {
                    t = this.ToDateTime(temp + 1, 1, 1, 0, 0, 0, 0);
                }
                t = this.ToDateTime(FinYear, Month, 1, 0, 0, 0, 0);
                t = t.AddDays(-1);
                ThisMonthDays = this.GetDayOfMonth(t);
                return ThisMonthDays;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return DateTime.DaysInMonth(FinYear, Month);
            }
            else
                throw new Exception("101:" + msgCultureError);

        }
        #endregion

        /// <summary>
        /// Returns a DateTime that is the specified number of months away from the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to add.</param>
        /// <param name="months">The number of months to add.</param>
        /// <returns>The DateTime that results from adding the specified number of months to the specified DateTime.</returns>
        /// <remarks>
        /// The year part of the resulting DateTime is affected if the resulting month is beyond the last month of the current year. The day part of the resulting DateTime is also affected if the resulting day is not a valid day in the resulting month of the resulting year; it is changed to the last valid day in the resulting month of the resulting year. The time-of-day part of the resulting DateTime remains the same as the specified DateTime.
        /// 
        /// For example, if the specified month is Ordibehesht, which is the 2nd month and has 31 days, the specified day is the 31th day of that month, and the value of the months parameter is -3, the resulting year is one less than the specified year, the resulting month is Bahman, and the resulting day is the 30th day, which is the last day in Bahman.
        /// 
        /// If the value of the months parameter is negative, the resulting DateTime would be earlier than the specified DateTime.
        /// </remarks>
        public override System.DateTime AddMonths(System.DateTime time, int months)
        {

            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))
            {
                if (Math.Abs(months) > 120000)
                {
                    throw new System.ArgumentOutOfRangeException("months", "100300:Valid values are between -120000 and 120000, inclusive.");
                }
                int year = GetYear(true, time);
                int month = GetMonth(false, time);
                int day = GetDayOfMonth(false, time);

                DateTime dateTime;
                month += (year - 1) * 12 + months;
                year = (month - 1) / 12 + 1;
                month -= (year - 1) * 12;
                if (day > 29)
                {
                    int maxday = GetDaysInMonth(false, year, month, 0);
                    if (maxday < day) day = maxday;
                }
                try
                {
                    dateTime = ToDateTime(year, month, day, 0, 0, 0, 0) + time.TimeOfDay;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new System.ArgumentException("100301:The resulting DateTime is outside the supported range.", "months");
                }
                return dateTime;

            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return ((DateTime)time).AddMonths(months);
            }
            else
                throw new Exception("102:" + msgCultureError);
        }

        /// <summary>
        /// Returns a DateTime that is the specified number of years away from the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to add.</param>
        /// <param name="years">The number of years to add.</param>
        /// <returns>The DateTime that results from adding the specified number of years to the specified DateTime.</returns>
        /// <remarks>
        /// The day part of the resulting DateTime is affected if the resulting day is not a valid day in the resulting month of the resulting year; it is changed to the last valid day in the resulting month of the resulting year. The time-of-day part of the resulting DateTime remains the same as the specified DateTime.
        /// 
        /// For example, Esfand has 29 days, except during leap years when it has 30 days. If the specified date is the 30th day of Esfand in a leap year and the value of years is 1, the resulting date will be the 29th day of Esfand in the following year.
        /// 
        /// If years is negative, the resulting DateTime would be earlier than the specified DateTime.
        /// </remarks>
        public override System.DateTime AddYears(System.DateTime time, int years)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase)) //Persian
            {
                int year = GetYear(true, time);
                int month = GetMonth(false, time);
                int day = GetDayOfMonth(false, time);
                year += years;
                if (day == 30 && month == 12)
                {
                    if (!IsLeapYear(false, year, 0))
                        day = 29;
                }
                DateTime dateTime;
                try
                {
                    dateTime = ToDateTime(year, month, day, 0, 0, 0, 0) + time.TimeOfDay;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new System.ArgumentException("100302:The resulting DateTime is outside the supported range.", "years");
                }
                return dateTime;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return ((DateTime)time).AddYears(years);
            }
            else
                throw new Exception("103:" + msgCultureError);
        }

        /// <summary>
        /// Gets the day of the month in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer from 1 to 31 that represents the day of the month in time.</returns>
        public override int GetDayOfMonth(System.DateTime time)
        {
            return GetDayOfMonth(true, time);
        }


        private int GetDayOfMonth(bool validate, System.DateTime time)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                int days = GetDayOfYear(validate, time);
                for (int i = 0; i < 6; i++)
                {
                    if (days <= 31) return days;
                    days -= 31;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (days <= 30) return days;
                    days -= 30;
                }
                return days;

            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return ((DateTime)time).Day;
            }
            else
                throw new Exception("104:" + msgCultureError);
        }

        /// <summary>
        /// Gets the day of the week in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>A DayOfWeek value that represents the day of the week in time.</returns>
        /// <remarks>The DayOfWeek values are Sunday which indicates YekShanbe', Monday which indicates DoShanbe', Tuesday which indicates SeShanbe', Wednesday which indicates ChaharShanbe', Thursday which indicates PanjShanbe', Friday which indicates Jom'e, and Saturday which indicates Shanbe'.</remarks>
        public override System.DayOfWeek GetDayOfWeek(System.DateTime time)
        {
            return time.DayOfWeek;
        }

        /// <summary>
        /// Gets the day of the year in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer from 1 to 366 that represents the day of the year in time.</returns>
        public override int GetDayOfYear(System.DateTime time)
        {
            return GetDayOfYear(true, time);
        }


        private int GetDayOfYear(bool validate, System.DateTime time)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                int year;
                int days;
                GetYearAndRemainingDays(validate, time, out year, out days);
                return days;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return ((DateTime)time).DayOfYear;
            }
            else
                throw new Exception("105:" + msgCultureError);
        }

        /// <summary>
        /// Gets the number of days in the specified month.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
        /// <remarks>For example, this method might return 29 or 30 for Esfand (month = 12), depending on whether year is a leap year.</remarks>
        public override int GetDaysInMonth(int year, int month, int era)
        {
            return GetDaysInMonth(true, year, month, era);
        }


        private int GetDaysInMonth(bool validate, int year, int month, int era)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                CheckEraRange(validate, era);
                CheckYearRange(validate, year);
                CheckMonthRange(validate, month);
                if (month < 7) return 31;
                if (month < 12) return 30;
                if (IsLeapYear(false, year, 0)) return 30;
                else return 29;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return DateTime.DaysInMonth(year, month);
            }
            else
                throw new Exception("106:" + msgCultureError);
        }

        /// <summary>
        /// Gets the number of days in the year specified by the year and era parameters.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The number of days in the specified year in the specified era.</returns>
        /// <remarks>For example, this method might return 365 or 366, depending on whether year is a leap year.</remarks>
        public override int GetDaysInYear(int year, int era)
        {
            return GetDaysInYear(true, year, era);
        }


        private int GetDaysInYear(bool validate, int year, int era)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                if (IsLeapYear(validate, year, era)) return 366;
                return 365;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                if (DateTime.IsLeapYear(year))
                    return 366;
                return 365;
            }
            else
                throw new Exception("107:" + msgCultureError);

        }

        /// <summary>
        /// Gets the era in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer that represents the era in time.</returns>
        /// <remarks>The Persian calendar recognizes one era: A.P. (Latin "Anno Persarum", which means "the year of/for Persians").</remarks>
        public override int GetEra(System.DateTime time)
        {
            CheckTicksRange(true, time);
            return PersianCalendar.PersianEra;
        }

        /// <summary>
        /// Gets the month in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer between 1 and 12 that represents the month in time.</returns>
        /// <remarks>Month 1 indicates Farvardin, month 2 indicates Ordibehesht, month 3 indicates Khordad, month 4 indicates Tir, month 5 indicates Amordad, month 6 indicates Shahrivar, month 7 indicates Mehr, month 8 indicates Aban, month 9 indicates Azar, month 10 indicates Dey, month 11 indicates Bahman, and month 12 indicates Esfand.</remarks>
        public override int GetMonth(System.DateTime time)
        {
            return GetMonth(true, time);
        }


        private int GetMonth(bool validate, System.DateTime time)
        {

            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                int days = GetDayOfYear(validate, time);
                if (days <= 31) return 1;
                if (days <= 62) return 2;
                if (days <= 93) return 3;
                if (days <= 124) return 4;
                if (days <= 155) return 5;
                if (days <= 186) return 6;
                if (days <= 216) return 7;
                if (days <= 246) return 8;
                if (days <= 276) return 9;
                if (days <= 306) return 10;
                if (days <= 336) return 11;
                return 12;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return time.Month;
            }
            else
                throw new Exception("108:" + msgCultureError);
        }

        /// <summary>
        /// Gets the number of months in the year specified by the year and era parameters.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The number of months in the specified year in the specified era.</returns>
        public override int GetMonthsInYear(int year, int era)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                CheckEraRange(true, era);
                CheckYearRange(true, year);
                return 12;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return 12;
            }
            else
                throw new Exception("109:" + msgCultureError);

        }

        /// <summary>
        /// Gets the year in the specified DateTime.
        /// </summary>
        /// <param name="time">The DateTime instance to read.</param>
        /// <returns>An integer between 1 and 9378 that represents the year in time.</returns>
        public override int GetYear(System.DateTime time)
        {
            return GetYear(true, time);
        }


        private int GetYear(bool validate, System.DateTime time)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                int days;
                int year;
                GetYearAndRemainingDays(validate, time, out year, out days);
                return year;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return time.Year;
            }
            else
                throw new Exception("110:" + msgCultureError);
        }

        /// <summary>
        /// Determines whether the date specified by the year, month, day, and era parameters is a leap day.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="day">An integer that represents the day.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>true if the specified day is a leap day; otherwise, false.</returns>
        /// <remarks>
        /// In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.
        /// 
        /// A leap day is a day that occurs only in a leap year. In the Persian calendar, the 30th day of Esfand (month 12) is the only leap day.
        /// </remarks>
        public override bool IsLeapDay(int year, int month, int day, int era)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                CheckEraRange(true, era);
                CheckYearRange(true, year);
                CheckMonthRange(true, month);
                if (day == 30 && month == 12 && IsLeapYear(false, year, 0))
                    return true;
                return false;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                if (day == 29 && month == 2 && DateTime.IsLeapYear(year))
                    return true;
                return false;
            }
            else
                throw new Exception("111:" + msgCultureError);
        }

        /// <summary>
        /// Determines whether the month specified by the year, month, and era parameters is a leap month.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>This method always returns false, unless overridden by a derived class.</returns>
        /// <remarks>
        /// In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.
        /// 
        /// A leap month is an entire month that occurs only in a leap year. The Persian calendar does not have any leap months.
        /// </remarks>
        public override bool IsLeapMonth(int year, int month, int era)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                CheckEraRange(true, era);
                CheckYearRange(true, year);
                CheckMonthRange(true, month);
                if (month == 12 && IsLeapYear(false, year, 0))
                    return true;
                return false;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                if (month == 2 && DateTime.IsLeapYear(year))
                    return true;
                return false;
            }
            else
                throw new Exception("112:" + msgCultureError);
        }

        //  if HasLeapFrac(year)==true and HasLeapFrac(year-1)==false
        //  then 'year' is a leap year.
        private static bool HasLeapFrac(int year)
        {
            double a = 31 * ((double)year + 38) / 128;
            if (a - Math.Floor(a) < 0.31)
                return true;
            return false;
        }

        /// <summary>
        /// Determines whether the year specified by the year and era parameters is a leap year.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>true if the specified year is a leap year; otherwise, false.</returns>
        /// <remarks>In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.</remarks>
        public override bool IsLeapYear(int year, int era)
        {
            return IsLeapYear(true, year, era);
        }


        private bool IsLeapYear(bool validate, int year, int era)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                CheckEraRange(validate, era);
                CheckYearRange(validate, year);
                if (HasLeapFrac(year) && !HasLeapFrac(year - 1))
                    return true;
                return false;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return DateTime.IsLeapYear(year);
            }
            else
                throw new Exception("113:" + msgCultureError);

        }

        /// <summary>
        /// Returns a DateTime that is set to the specified date and time in the specified era.
        /// </summary>
        /// <param name="year">An integer that represents the year.</param>
        /// <param name="month">An integer that represents the month.</param>
        /// <param name="day">An integer that represents the day.</param>
        /// <param name="hour">An integer that represents the hour.</param>
        /// <param name="minute">An integer that represents the minute.</param>
        /// <param name="second">An integer that represents the second.</param>
        /// <param name="millisecond">An integer that represents the millisecond.</param>
        /// <param name="era">An integer that represents the era.</param>
        /// <returns>The DateTime instance set to the specified date and time in the current era.</returns>
        public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {

                CheckEraRange(true, era);
                CheckDateRange(true, year, month, day);
                int days = day;
                for (int i = 1; i < month; i++)
                {
                    if (i < 7) days += 31;
                    else if (i < 12) days += 30;
                }
                days += 365 * year + NumberOfLeapYearsUntil(false, year);
                // following line validates the arguments of time
                DateTime timePart = new DateTime(1, 1, 1, hour, minute, second, millisecond);
                long ticks = days * 864000000000L + timePart.Ticks + 195721056000000000L;
                DateTime dateTime;
                try
                {
                    dateTime = new DateTime(ticks);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    // If ticks go greater than DateTime.MaxValue.Ticks, this exception will be caught
                    throw new System.ArgumentOutOfRangeException("100303:month and/or day", "Specified time is not supported in this calendar. It should be between 12:00:00 AM, 1/01/0001 AP and 11:59:59 PM, 12/10/9378 AP, inclusive.");
                }
                return dateTime;

            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {

                return new DateTime(year, month, day, hour, minute, second, millisecond);
            }
            else
                throw new Exception("114:" + msgCultureError);
        }

        /// <summary>
        /// Converts the given date to DateTime object
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public DateTime ToDateTime(string dateStr)
        {
            //OK
            int year, month, day;
            getDateInfo(dateStr, out year, out month, out day);
            return (ToDateTime(year, month, day, 0, 0, 0, 0, PersianEra));
        }
        /// <summary>
        /// Converts the specified two-digit year to a four-digit year by using the Globalization.PersianCalendar.TwoDigitYearMax property to determine the appropriate century.
        /// </summary>
        /// <param name="year">A two-digit integer that represents the year to convert.</param>
        /// <returns>An integer that contains the four-digit representation of year.</returns>
        /// <remarks>TwoDigitYearMax is the last year in the 100-year range that can be represented by a two-digit year. The century is determined by finding the sole occurrence of the two-digit year within that 100-year range. For example, if TwoDigitYearMax is set to 1429, the 100-year range is from 1330 to 1429; therefore, a 2-digit value of 30 is interpreted as 1330, while a 2-digit value of 29 is interpreted as 1429.</remarks>
        public override int ToFourDigitYear(int year)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                if (year != 0)
                {
                    try
                    {
                        CheckYearRange(true, year);
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        throw new System.ArgumentOutOfRangeException("year", "100304:Valid values for year to be converted are between 0 and 9378, inclusive.");
                    }
                }
                if (year > 99) return year;
                int a = TwoDigitYearMax / 100;
                if (year > TwoDigitYearMax - a * 100) a--;
                return a * 100 + year;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return Convert.ToInt32(new DateTime(year, 1, 1).ToString("yyyy"));
            }
            else
                throw new Exception("115:" + msgCultureError);
        }

        /// <summary>
        /// Gets the list of eras in the PersianCalendar.
        /// </summary>
        /// <remarks>The Persian calendar recognizes one era: A.P. (Latin "Anno Persarum", which means "the year of/for Persians").</remarks>
        public override int[] Eras
        {
            get
            {
                int[] eras = { 1 };
                return eras;
            }
        }


        private int twoDigitYearMax = 1409;

        /// <summary>
        /// Gets and sets the last year of a 100-year range that can be represented by a 2-digit year.
        /// </summary>
        /// <property_value>The last year of a 100-year range that can be represented by a 2-digit year.</property_value>
        /// <remarks>This property allows a 2-digit year to be properly translated to a 4-digit year. For example, if this property is set to 1429, the 100-year range is from 1330 to 1429; therefore, a 2-digit value of 30 is interpreted as 1330, while a 2-digit value of 29 is interpreted as 1429.</remarks>
        public new int TwoDigitYearMax
        {
            get
            {
                return twoDigitYearMax;
            }
            set
            {
                if (value < 100 || 9378 < value)
                    throw new System.ArgumentOutOfRangeException("value", "100305:Valid values are between 100 and 9378, inclusive.");
                twoDigitYearMax = value;
            }
        }

        /// <summary>
        /// Gets the century of the specified DateTime.
        /// </summary>
        /// <param name="time">An instance of the DateTime class to read.</param>
        /// <returns>An integer from 1 to 94 that represents the century.</returns>
        /// <remarks>A century is a whole 100-year period. So the century 14 for example, represents years 1301 through 1400.</remarks>
        public int GetCentury(System.DateTime time)
        {
            //OK
            return (GetYear(true, time) - 1) / 100 + 1;
        }

        /// <summary>
        /// Calculates the number of leap years until -but not including- the specified year.
        /// </summary>
        /// <param name="year">An integer between 1 and 9378</param>
        /// <returns>An integer representing the number of leap years that have occured by the year specified.</returns>
        /// <remarks>In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.</remarks>
        public int NumberOfLeapYearsUntil(int year)
        {
            return NumberOfLeapYearsUntil(true, year);
        }


        private int NumberOfLeapYearsUntil(bool validate, int year)
        {

            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                CheckYearRange(validate, year);
                int count = 0;
                for (int i = 4; i < year; i++)
                {
                    if (IsLeapYear(false, i, 0))
                    {
                        count++;
                        i += 3;
                    }
                }
                return count;

            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                int count = 0;
                for (int i = 4; i < year; i++)
                {
                    if (DateTime.IsLeapYear(i))
                    {
                        count++;
                        i += 3;
                    }
                }
                return count;
            }
            else
                throw new Exception("116:" + msgCultureError);
        }


        private void CheckEraRange(bool validate, int era)
        {
            if (validate)
            {
                if (era < 0 || 1 < era)
                    throw new System.ArgumentOutOfRangeException("era", "100306:Era value was not valid.");
            }
            return;
        }


        private void CheckYearRange(bool validate, int year)
        {
            if (validate)
            {
                if (year < 1 || 9378 < year)
                    throw new System.ArgumentOutOfRangeException("year", "100307:Valid values for year are between 1 and 9378, inclusive.");
            }
            return;
        }


        private void CheckMonthRange(bool validate, int month)
        {
            if (validate)
            {
                if (month < 1 || 12 < month)
                    throw new System.ArgumentOutOfRangeException("month", "100308:Values for month must be between 1 and 12.");
            }
            return;
        }


        private void CheckDateRange(bool validate, int year, int month, int day)
        {
            if (validate)
            {
                int maxday = GetDaysInMonth(true, year, month, 0);
                if (day < 1 || maxday < day)
                {
                    if (day == 30 && month == 12)
                        throw new System.ArgumentOutOfRangeException("day", "100309:Year " + year + " is not a leap year. Day must be at most 29 for month 12 of this year.");
                    throw new System.ArgumentOutOfRangeException("day", "100310:Day must be between 1 and " + maxday + " for month " + month + ".");
                }
            }
        }


        private void CheckTicksRange(bool validate, DateTime time)
        {
            // Valid ticks represent times between 12:00:00.000 AM, 22/03/0622 CE and 11:59:59.999 PM, 31/12/9999 CE.
            if (validate)
            {
                long ticks = time.Ticks;
                if (ticks < 196037280000000000L)
                    throw new System.ArgumentOutOfRangeException("time", "100311:Specified time is not supported in this calendar. It should be between 22/03/0622 12:00:00 AM and 31/12/9999 11:59:59 PM, inclusive.");
            }
            return;
        }

        private void GetYearAndRemainingDays(bool validate, DateTime time, out int year, out int days)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                CheckTicksRange(validate, time);
                days = (time - new DateTime(196036416000000000L)).Days;
                year = 1;
                int daysInNextYear = 365;
                while (days > daysInNextYear)
                {
                    days -= daysInNextYear;
                    year++;
                    daysInNextYear = GetDaysInYear(false, year, 0);
                }
                return;
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                year = time.Year;
                days = time.DayOfYear;
            }
            else
                throw new Exception("117:" + msgCultureError);
        }

        /// <summary>
        /// Converts the specified date to persian string
        /// </summary>
        /// <param name="date"></param>
        public string getDateStr(DateTime date)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                int year = GetYear(date);
                string month = GetMonth(date).ToString("00");
                string day = GetDayOfMonth(date).ToString("00");
                return (string.Format("{0}/{1}/{2}", year, month, day));
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return string.Format("{0}/{1}/{2}"
                , date.Year.ToString()
                , date.Month.ToString("00")
                , date.Day.ToString("00")
                );
            }
            else
                throw new Exception("118:" + msgCultureError);

        }
        /// <summary>
        /// Returns the year, month and day part of the given date
        /// </summary>
        public void getDateInfo(string date, out int year, out int month, out int day)
        {
            //OK
            day = int.Parse(date.Substring(8, 2));
            month = int.Parse(date.Substring(5, 2));
            year = int.Parse(date.Substring(0, 4));
        }
        /// <summary>
        /// Returns the year, month and day part of the given date
        /// </summary>
        public void getDateInfo(DateTime date, out int year, out int month, out int day)
        {
            //OK
            string dateStr = getDateStr(date);
            getDateInfo(dateStr, out year, out month, out day);
        }

        public TimeSpan subtract2Date(string fromDate, string toDate)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                int year1, month1, day1;
                int year2, month2, day2;

                getDateInfo(fromDate, out year2, out month2, out day2);
                getDateInfo(toDate, out year1, out month1, out day1);

                DateTime date1 = new DateTime(year1, month1, day1, 0, 0, 0, 0);
                DateTime date2 = new DateTime(year2, month2, day2, 0, 0, 0, 0);
                TimeSpan diff = date2.Subtract(date1);
                return (diff);
            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return DateTime.Parse(fromDate).Subtract(DateTime.Parse(toDate));
                //return DateTime.Parse(fromDate)- DateTime.Parse(toDate);
            }
            else
                throw new Exception("119:" + msgCultureError);

        }

        /// <summary>
        /// Subtracts from the specified date and returns the corresponding result date
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="numDays"></param>
        public string subtractFromDate(string fromDate, int numDays)
        {

            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {
                int year, month, day;
                getDateInfo(fromDate, out year, out month, out day);
                DateTime dateTime = new DateTime(year, month, day, new PersianCalendar());
                DateTime result = dateTime.Subtract(new TimeSpan(numDays, 0, 0, 0));
                return (getDateStr(result));
                //			return( string.Format("{0}/{1}/{2}", result.Year , result.Month.ToString("00"), 
                //								   result.Day.ToString("00")));

            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return DateTime.Parse(fromDate).AddDays(numDays * -1).ToString();
            }
            else
                throw new Exception("120:" + msgCultureError);

        }


        public int subtract2DateInstr(string dateFrom, string dateTo)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {

                //These two line is replaced with the lines bellow,because
                //it use the dateTime function which do not accept the 02/31
                //please inform davoood

                //TimeSpan diff = subtract2Date( dateFrom, dateTo);
                //return(diff.Days);

                int year1, month1, day1;
                int year2, month2, day2;

                getDateInfo(dateFrom, out year1, out month1, out day1);
                getDateInfo(dateTo, out year2, out month2, out day2);

                int dayFromfirst = (year1 - 1) * 365 + (month1 - 1) * 31 + day1;
                if (month1 > 7) dayFromfirst -= month1 - 7;  //correct the 30 days month

                int dayTofirst = (year2 - 1) * 365 + (month2 - 1) * 31 + day2;
                if (month2 > 7) dayTofirst -= month2 - 7;  //correct the 30 days month

                return (dayFromfirst - dayTofirst);

            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                return DateTime.Parse(dateFrom).Subtract(DateTime.Parse(dateTo)).Days;
            }
            else
                throw new Exception("121:" + msgCultureError);


        }
        /// <summary>
        /// Computes the subtract of date1 from date2 ( date2 - date1) and returns the corresponding 
        /// date result
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        public string subtract2DateStr(string date1, string date2)
        {
            TimeSpan diff = subtract2Date(date1, date2);
            DateTime diffDate = new DateTime(diff.Ticks);

            return (getDateStr(diffDate));
        }
        public TimeSpan subtract2DateTimeStr(string dateFrom, string timeFrom, string dateTo, string timeTo)
        {
            if (General.CalendarCulterInfo.Parent.Name.Equals("fa", StringComparison.CurrentCultureIgnoreCase))//Persian
            {

                if (dateFrom.IndexOf("_") >= 0 || dateTo.IndexOf("_") >= 0)
                    return new TimeSpan(0, 0, 0);
                if (timeFrom.IndexOf(" ") >= 0 || timeTo.IndexOf(" ") >= 0)
                    return new TimeSpan(0, 0, 0);
                DateTime from = (new PersianCalendar()).ToDateTime(dateFrom);
                DateTime to = (new PersianCalendar()).ToDateTime(dateTo);
                int hourFrom = int.Parse(timeFrom.Substring(0, 2));
                int hourTo = int.Parse(timeTo.Substring(0, 2));
                int minuteFrom = int.Parse(timeFrom.Substring(3, 2));
                int minuteTo = int.Parse(timeTo.Substring(3, 2));

                from = new DateTime(from.Year, from.Month, from.Day, hourFrom, minuteFrom, 0, 0);
                to = new DateTime(to.Year, to.Month, to.Day, hourTo, minuteTo, 0, 0);

                TimeSpan diff = to.Subtract(from);
                return diff;

            }
            else if (General.CalendarCulterInfo.Parent.Name.Equals("en", StringComparison.CurrentCultureIgnoreCase) || //English
                General.CalendarCulterInfo.Parent.Name.Equals("tr", StringComparison.CurrentCultureIgnoreCase)) //Turkish
            {
                var from = Convert.ToDateTime(string.Format("{0} {1}", dateFrom, timeFrom));
                var to = Convert.ToDateTime(string.Format("{0} {1}", dateTo, timeTo));
                return to.Subtract(from);
            }
            else
                throw new Exception("122:" + msgCultureError);
        }

    }

    
}




/*
using PPC.Base.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace PPC.Common
{
    public class PersianCalender
    {

        public class PersianCalendar : Calendar
        {
            /// <summary>
            /// Represents the current era.
            /// </summary>
            /// <remarks>The Persian calendar recognizes one era: A.P. (Latin "Anno Persarum", which means "the year of/for Persians").</remarks>
            public static readonly int PersianEra = 1;
            #region Calculate This Month Days
            /// <summary>
            ///	   Culculate This Month Days
            /// </summary>
            /// <param name="FinYear"></param>
            /// <param name="Month"></param>
            /// <returns></returns>
            public int MonthDaysNumber(int FinYear, int Month)
            {
                int ThisMonthDays = 0;
                DateTime t;
                int temp = FinYear;
                if (Month != 12)
                {
                    t = this.ToDateTime(temp, Month + 1, 1, 0, 0, 0, 0);
                }
                else
                {
                    t = this.ToDateTime(temp + 1, 1, 1, 0, 0, 0, 0);
                }
                t = this.ToDateTime(FinYear, Month, 1, 0, 0, 0, 0);
                t = t.AddDays(-1);
                ThisMonthDays = this.GetDayOfMonth(t);
                return ThisMonthDays;
            }
            #endregion

            /// <summary>
            /// Returns a DateTime that is the specified number of months away from the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to add.</param>
            /// <param name="months">The number of months to add.</param>
            /// <returns>The DateTime that results from adding the specified number of months to the specified DateTime.</returns>
            /// <remarks>
            /// The year part of the resulting DateTime is affected if the resulting month is beyond the last month of the current year. The day part of the resulting DateTime is also affected if the resulting day is not a valid day in the resulting month of the resulting year; it is changed to the last valid day in the resulting month of the resulting year. The time-of-day part of the resulting DateTime remains the same as the specified DateTime.
            /// 
            /// For example, if the specified month is Ordibehesht, which is the 2nd month and has 31 days, the specified day is the 31th day of that month, and the value of the months parameter is -3, the resulting year is one less than the specified year, the resulting month is Bahman, and the resulting day is the 30th day, which is the last day in Bahman.
            /// 
            /// If the value of the months parameter is negative, the resulting DateTime would be earlier than the specified DateTime.
            /// </remarks>
            public override System.DateTime AddMonths(System.DateTime time, int months)
            {
                if (Math.Abs(months) > 120000)
                {
                    throw new System.ArgumentOutOfRangeException("months", "100300:Valid values are between -120000 and 120000, inclusive.");
                }
                int year = GetYear(true, time);
                int month = GetMonth(false, time);
                int day = GetDayOfMonth(false, time);

                month += (year - 1) * 12 + months;
                year = (month - 1) / 12 + 1;
                month -= (year - 1) * 12;
                if (day > 29)
                {
                    int maxday = GetDaysInMonth(false, year, month, 0);
                    if (maxday < day) day = maxday;
                }
                DateTime dateTime;
                try
                {
                    dateTime = ToDateTime(year, month, day, 0, 0, 0, 0) + time.TimeOfDay;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new System.ArgumentException("100301:The resulting DateTime is outside the supported range.", "months");
                }
                return dateTime;
            }

            /// <summary>
            /// Returns a DateTime that is the specified number of years away from the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to add.</param>
            /// <param name="years">The number of years to add.</param>
            /// <returns>The DateTime that results from adding the specified number of years to the specified DateTime.</returns>
            /// <remarks>
            /// The day part of the resulting DateTime is affected if the resulting day is not a valid day in the resulting month of the resulting year; it is changed to the last valid day in the resulting month of the resulting year. The time-of-day part of the resulting DateTime remains the same as the specified DateTime.
            /// 
            /// For example, Esfand has 29 days, except during leap years when it has 30 days. If the specified date is the 30th day of Esfand in a leap year and the value of years is 1, the resulting date will be the 29th day of Esfand in the following year.
            /// 
            /// If years is negative, the resulting DateTime would be earlier than the specified DateTime.
            /// </remarks>
            public override System.DateTime AddYears(System.DateTime time, int years)
            {
                int year = GetYear(true, time);
                int month = GetMonth(false, time);
                int day = GetDayOfMonth(false, time);
                year += years;
                if (day == 30 && month == 12)
                {
                    if (!IsLeapYear(false, year, 0))
                        day = 29;
                }
                DateTime dateTime;
                try
                {
                    dateTime = ToDateTime(year, month, day, 0, 0, 0, 0) + time.TimeOfDay;
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    throw new System.ArgumentException("100302:The resulting DateTime is outside the supported range.", "years");
                }
                return dateTime;
            }

            /// <summary>
            /// Gets the day of the month in the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to read.</param>
            /// <returns>An integer from 1 to 31 that represents the day of the month in time.</returns>
            public override int GetDayOfMonth(System.DateTime time)
            {
                return GetDayOfMonth(true, time);
            }


            private int GetDayOfMonth(bool validate, System.DateTime time)
            {
                int days = GetDayOfYear(validate, time);
                for (int i = 0; i < 6; i++)
                {
                    if (days <= 31) return days;
                    days -= 31;
                }
                for (int i = 0; i < 5; i++)
                {
                    if (days <= 30) return days;
                    days -= 30;
                }
                return days;
            }

            /// <summary>
            /// Gets the day of the week in the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to read.</param>
            /// <returns>A DayOfWeek value that represents the day of the week in time.</returns>
            /// <remarks>The DayOfWeek values are Sunday which indicates YekShanbe', Monday which indicates DoShanbe', Tuesday which indicates SeShanbe', Wednesday which indicates ChaharShanbe', Thursday which indicates PanjShanbe', Friday which indicates Jom'e, and Saturday which indicates Shanbe'.</remarks>
            public override System.DayOfWeek GetDayOfWeek(System.DateTime time)
            {
                return time.DayOfWeek;
            }

            /// <summary>
            /// Gets the day of the year in the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to read.</param>
            /// <returns>An integer from 1 to 366 that represents the day of the year in time.</returns>
            public override int GetDayOfYear(System.DateTime time)
            {
                return GetDayOfYear(true, time);
            }


            private int GetDayOfYear(bool validate, System.DateTime time)
            {
                int year;
                int days;
                GetYearAndRemainingDays(validate, time, out year, out days);
                return days;
            }

            /// <summary>
            /// Gets the number of days in the specified month.
            /// </summary>
            /// <param name="year">An integer that represents the year.</param>
            /// <param name="month">An integer that represents the month.</param>
            /// <param name="era">An integer that represents the era.</param>
            /// <returns>The number of days in the specified month in the specified year in the specified era.</returns>
            /// <remarks>For example, this method might return 29 or 30 for Esfand (month = 12), depending on whether year is a leap year.</remarks>
            public override int GetDaysInMonth(int year, int month, int era)
            {
                return GetDaysInMonth(true, year, month, era);
            }


            private int GetDaysInMonth(bool validate, int year, int month, int era)
            {
                CheckEraRange(validate, era);
                CheckYearRange(validate, year);
                CheckMonthRange(validate, month);
                if (month < 7) return 31;
                if (month < 12) return 30;
                if (IsLeapYear(false, year, 0)) return 30;
                else return 29;
            }

            /// <summary>
            /// Gets the number of days in the year specified by the year and era parameters.
            /// </summary>
            /// <param name="year">An integer that represents the year.</param>
            /// <param name="era">An integer that represents the era.</param>
            /// <returns>The number of days in the specified year in the specified era.</returns>
            /// <remarks>For example, this method might return 365 or 366, depending on whether year is a leap year.</remarks>
            public override int GetDaysInYear(int year, int era)
            {
                return GetDaysInYear(true, year, era);
            }


            private int GetDaysInYear(bool validate, int year, int era)
            {
                if (IsLeapYear(validate, year, era)) return 366;
                return 365;
            }

            /// <summary>
            /// Gets the era in the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to read.</param>
            /// <returns>An integer that represents the era in time.</returns>
            /// <remarks>The Persian calendar recognizes one era: A.P. (Latin "Anno Persarum", which means "the year of/for Persians").</remarks>
            public override int GetEra(System.DateTime time)
            {
                CheckTicksRange(true, time);
                return PersianCalendar.PersianEra;
            }

            /// <summary>
            /// Gets the month in the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to read.</param>
            /// <returns>An integer between 1 and 12 that represents the month in time.</returns>
            /// <remarks>Month 1 indicates Farvardin, month 2 indicates Ordibehesht, month 3 indicates Khordad, month 4 indicates Tir, month 5 indicates Amordad, month 6 indicates Shahrivar, month 7 indicates Mehr, month 8 indicates Aban, month 9 indicates Azar, month 10 indicates Dey, month 11 indicates Bahman, and month 12 indicates Esfand.</remarks>
            public override int GetMonth(System.DateTime time)
            {
                return GetMonth(true, time);
            }


            private int GetMonth(bool validate, System.DateTime time)
            {
                int days = GetDayOfYear(validate, time);
                if (days <= 31) return 1;
                if (days <= 62) return 2;
                if (days <= 93) return 3;
                if (days <= 124) return 4;
                if (days <= 155) return 5;
                if (days <= 186) return 6;
                if (days <= 216) return 7;
                if (days <= 246) return 8;
                if (days <= 276) return 9;
                if (days <= 306) return 10;
                if (days <= 336) return 11;
                return 12;
            }

            /// <summary>
            /// Gets the number of months in the year specified by the year and era parameters.
            /// </summary>
            /// <param name="year">An integer that represents the year.</param>
            /// <param name="era">An integer that represents the era.</param>
            /// <returns>The number of months in the specified year in the specified era.</returns>
            public override int GetMonthsInYear(int year, int era)
            {
                CheckEraRange(true, era);
                CheckYearRange(true, year);
                return 12;
            }

            /// <summary>
            /// Gets the year in the specified DateTime.
            /// </summary>
            /// <param name="time">The DateTime instance to read.</param>
            /// <returns>An integer between 1 and 9378 that represents the year in time.</returns>
            public override int GetYear(System.DateTime time)
            {
                return GetYear(true, time);
            }


            private int GetYear(bool validate, System.DateTime time)
            {
                int days;
                int year;
                GetYearAndRemainingDays(validate, time, out year, out days);
                return year;
            }

            /// <summary>
            /// Determines whether the date specified by the year, month, day, and era parameters is a leap day.
            /// </summary>
            /// <param name="year">An integer that represents the year.</param>
            /// <param name="month">An integer that represents the month.</param>
            /// <param name="day">An integer that represents the day.</param>
            /// <param name="era">An integer that represents the era.</param>
            /// <returns>true if the specified day is a leap day; otherwise, false.</returns>
            /// <remarks>
            /// In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.
            /// 
            /// A leap day is a day that occurs only in a leap year. In the Persian calendar, the 30th day of Esfand (month 12) is the only leap day.
            /// </remarks>
            public override bool IsLeapDay(int year, int month, int day, int era)
            {
                CheckEraRange(true, era);
                CheckYearRange(true, year);
                CheckMonthRange(true, month);
                if (day == 30 && month == 12 && IsLeapYear(false, year, 0))
                    return true;
                return false;
            }

            /// <summary>
            /// Determines whether the month specified by the year, month, and era parameters is a leap month.
            /// </summary>
            /// <param name="year">An integer that represents the year.</param>
            /// <param name="month">An integer that represents the month.</param>
            /// <param name="era">An integer that represents the era.</param>
            /// <returns>This method always returns false, unless overridden by a derived class.</returns>
            /// <remarks>
            /// In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.
            /// 
            /// A leap month is an entire month that occurs only in a leap year. The Persian calendar does not have any leap months.
            /// </remarks>
            public override bool IsLeapMonth(int year, int month, int era)
            {
                CheckEraRange(true, era);
                CheckYearRange(true, year);
                CheckMonthRange(true, month);
                return false;
            }

            //  if HasLeapFrac(year)==true and HasLeapFrac(year-1)==false
            //  then 'year' is a leap year.
            private static bool HasLeapFrac(int year)
            {
                double a = 31 * ((double)year + 38) / 128;
                if (a - Math.Floor(a) < 0.31)
                    return true;
                return false;
            }

            /// <summary>
            /// Determines whether the year specified by the year and era parameters is a leap year.
            /// </summary>
            /// <param name="year">An integer that represents the year.</param>
            /// <param name="era">An integer that represents the era.</param>
            /// <returns>true if the specified year is a leap year; otherwise, false.</returns>
            /// <remarks>In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.</remarks>
            public override bool IsLeapYear(int year, int era)
            {
                return IsLeapYear(true, year, era);
            }


            private bool IsLeapYear(bool validate, int year, int era)
            {
                CheckEraRange(validate, era);
                CheckYearRange(validate, year);
                if (HasLeapFrac(year) && !HasLeapFrac(year - 1))
                    return true;
                return false;
            }

            /// <summary>
            /// Returns a DateTime that is set to the specified date and time in the specified era.
            /// </summary>
            /// <param name="year">An integer that represents the year.</param>
            /// <param name="month">An integer that represents the month.</param>
            /// <param name="day">An integer that represents the day.</param>
            /// <param name="hour">An integer that represents the hour.</param>
            /// <param name="minute">An integer that represents the minute.</param>
            /// <param name="second">An integer that represents the second.</param>
            /// <param name="millisecond">An integer that represents the millisecond.</param>
            /// <param name="era">An integer that represents the era.</param>
            /// <returns>The DateTime instance set to the specified date and time in the current era.</returns>
            public override System.DateTime ToDateTime(int year, int month, int day, int hour, int minute, int second, int millisecond, int era)
            {
                CheckEraRange(true, era);
                CheckDateRange(true, year, month, day);
                int days = day;
                for (int i = 1; i < month; i++)
                {
                    if (i < 7) days += 31;
                    else if (i < 12) days += 30;
                }
                days += 365 * year + NumberOfLeapYearsUntil(false, year);
                // following line validates the arguments of time
                DateTime timePart = new DateTime(1, 1, 1, hour, minute, second, millisecond);
                long ticks = days * 864000000000L + timePart.Ticks + 195721056000000000L;
                DateTime dateTime;
                try
                {
                    dateTime = new DateTime(ticks);
                }
                catch (System.ArgumentOutOfRangeException)
                {
                    // If ticks go greater than DateTime.MaxValue.Ticks, this exception will be caught
                    throw new System.ArgumentOutOfRangeException("100303:month and/or day", "Specified time is not supported in this calendar. It should be between 12:00:00 AM, 1/01/0001 AP and 11:59:59 PM, 12/10/9378 AP, inclusive.");
                }
                return dateTime;
            }

            /// <summary>
            /// Converts the given date to DateTime object
            /// </summary>
            /// <param name="dateStr"></param>
            /// <returns></returns>
            public DateTime ToDateTime(string dateStr)
            {
                int year, month, day;
                getDateInfo(dateStr, out year, out month, out day);
                return (ToDateTime(year, month, day, 0, 0, 0, 0, PersianEra));
            }
            /// <summary>
            /// Converts the specified two-digit year to a four-digit year by using the Globalization.PersianCalendar.TwoDigitYearMax property to determine the appropriate century.
            /// </summary>
            /// <param name="year">A two-digit integer that represents the year to convert.</param>
            /// <returns>An integer that contains the four-digit representation of year.</returns>
            /// <remarks>TwoDigitYearMax is the last year in the 100-year range that can be represented by a two-digit year. The century is determined by finding the sole occurrence of the two-digit year within that 100-year range. For example, if TwoDigitYearMax is set to 1429, the 100-year range is from 1330 to 1429; therefore, a 2-digit value of 30 is interpreted as 1330, while a 2-digit value of 29 is interpreted as 1429.</remarks>
            public override int ToFourDigitYear(int year)
            {
                if (year != 0)
                {
                    try
                    {
                        CheckYearRange(true, year);
                    }
                    catch (System.ArgumentOutOfRangeException)
                    {
                        throw new System.ArgumentOutOfRangeException("year", "100304:Valid values for year to be converted are between 0 and 9378, inclusive.");
                    }
                }
                if (year > 99) return year;
                int a = TwoDigitYearMax / 100;
                if (year > TwoDigitYearMax - a * 100) a--;
                return a * 100 + year;
            }

            /// <summary>
            /// Gets the list of eras in the PersianCalendar.
            /// </summary>
            /// <remarks>The Persian calendar recognizes one era: A.P. (Latin "Anno Persarum", which means "the year of/for Persians").</remarks>
            public override int[] Eras
            {
                get
                {
                    int[] eras = { 1 };
                    return eras;
                }
            }


            private int twoDigitYearMax = 1409;

            /// <summary>
            /// Gets and sets the last year of a 100-year range that can be represented by a 2-digit year.
            /// </summary>
            /// <property_value>The last year of a 100-year range that can be represented by a 2-digit year.</property_value>
            /// <remarks>This property allows a 2-digit year to be properly translated to a 4-digit year. For example, if this property is set to 1429, the 100-year range is from 1330 to 1429; therefore, a 2-digit value of 30 is interpreted as 1330, while a 2-digit value of 29 is interpreted as 1429.</remarks>
            public new int TwoDigitYearMax
            {
                get
                {
                    return twoDigitYearMax;
                }
                set
                {
                    if (value < 100 || 9378 < value)
                        throw new System.ArgumentOutOfRangeException("value", "100305:Valid values are between 100 and 9378, inclusive.");
                    twoDigitYearMax = value;
                }
            }

            /// <summary>
            /// Gets the century of the specified DateTime.
            /// </summary>
            /// <param name="time">An instance of the DateTime class to read.</param>
            /// <returns>An integer from 1 to 94 that represents the century.</returns>
            /// <remarks>A century is a whole 100-year period. So the century 14 for example, represents years 1301 through 1400.</remarks>
            public int GetCentury(System.DateTime time)
            {
                return (GetYear(true, time) - 1) / 100 + 1;
            }

            /// <summary>
            /// Calculates the number of leap years until -but not including- the specified year.
            /// </summary>
            /// <param name="year">An integer between 1 and 9378</param>
            /// <returns>An integer representing the number of leap years that have occured by the year specified.</returns>
            /// <remarks>In the Persian calendar leap years are applied every 4 or 5 years according to a certain pattern that iterates in a 2820-year cycle. A common year has 365 days and a leap year has 366 days.</remarks>
            public int NumberOfLeapYearsUntil(int year)
            {
                return NumberOfLeapYearsUntil(true, year);
            }


            private int NumberOfLeapYearsUntil(bool validate, int year)
            {
                CheckYearRange(validate, year);
                int count = 0;
                for (int i = 4; i < year; i++)
                {
                    if (IsLeapYear(false, i, 0))
                    {
                        count++;
                        i += 3;
                    }
                }
                return count;
            }


            private void CheckEraRange(bool validate, int era)
            {
                if (validate)
                {
                    if (era < 0 || 1 < era)
                        throw new System.ArgumentOutOfRangeException("era", "100306:Era value was not valid.");
                }
                return;
            }


            private void CheckYearRange(bool validate, int year)
            {
                if (validate)
                {
                    if (year < 1 || 9378 < year)
                        throw new System.ArgumentOutOfRangeException("year", "100307:Valid values for year are between 1 and 9378, inclusive.");
                }
                return;
            }


            private void CheckMonthRange(bool validate, int month)
            {
                if (validate)
                {
                    if (month < 1 || 12 < month)
                        throw new System.ArgumentOutOfRangeException("month", "100308:Values for month must be between 1 and 12.");
                }
                return;
            }


            private void CheckDateRange(bool validate, int year, int month, int day)
            {
                if (validate)
                {
                    int maxday = GetDaysInMonth(true, year, month, 0);
                    if (day < 1 || maxday < day)
                    {
                        if (day == 30 && month == 12)
                            throw new System.ArgumentOutOfRangeException("day", "100309:Year " + year + " is not a leap year. Day must be at most 29 for month 12 of this year.");
                        throw new System.ArgumentOutOfRangeException("day", "100310:Day must be between 1 and " + maxday + " for month " + month + ".");
                    }
                }
            }


            private void CheckTicksRange(bool validate, DateTime time)
            {
                // Valid ticks represent times between 12:00:00.000 AM, 22/03/0622 CE and 11:59:59.999 PM, 31/12/9999 CE.
                if (validate)
                {
                    long ticks = time.Ticks;
                    if (ticks < 196037280000000000L)
                        throw new System.ArgumentOutOfRangeException("time", "100311:Specified time is not supported in this calendar. It should be between 22/03/0622 12:00:00 AM and 31/12/9999 11:59:59 PM, inclusive.");
                }
                return;
            }


            private void GetYearAndRemainingDays(bool validate, DateTime time, out int year, out int days)
            {
                CheckTicksRange(validate, time);
                days = (time - new DateTime(196036416000000000L)).Days;
                year = 1;
                int daysInNextYear = 365;
                while (days > daysInNextYear)
                {
                    days -= daysInNextYear;
                    year++;
                    daysInNextYear = GetDaysInYear(false, year, 0);
                }
                return;
            }
            /// <summary>
            /// Converts the specified date to persian string
            /// </summary>
            /// <param name="date"></param>
            public string getDateStr(DateTime date)
            {
                int year = GetYear(date);
                string month = GetMonth(date).ToString("00");
                string day = GetDayOfMonth(date).ToString("00");
                return (string.Format("{0}/{1}/{2}", year, month, day));
            }
            /// <summary>
            /// Returns the year, month and day part of the given date
            /// </summary>
            public void getDateInfo(string date, out int year, out int month, out int day)
            {
                if (date.ToNullString().Length == 0)
                {
                    day = 0;
                    month = 0;
                    year = 0;
                    return;
                }
                day = int.Parse(date.Substring(8, 2));
                month = int.Parse(date.Substring(5, 2));
                year = int.Parse(date.Substring(0, 4));
            }
            /// <summary>
            /// Returns the year, month and day part of the given date
            /// </summary>
            public void getDateInfo(DateTime date, out int year, out int month, out int day)
            {
                string dateStr = getDateStr(date);
                getDateInfo(dateStr, out year, out month, out day);
            }


            public TimeSpan subtract2Date(string fromDate, string toDate)
            {
                int year1, month1, day1;
                int year2, month2, day2;

                getDateInfo(fromDate, out year2, out month2, out day2);
                getDateInfo(toDate, out year1, out month1, out day1);

                DateTime date1 = new DateTime(year1, month1, day1, 0, 0, 0, 0);
                DateTime date2 = new DateTime(year2, month2, day2, 0, 0, 0, 0);
                TimeSpan diff = date2.Subtract(date1);
                return (diff);
            }

            /// <summary>
            /// Subtracts from the specified date and returns the corresponding result date
            /// </summary>
            /// <param name="fromDate"></param>
            /// <param name="numDays"></param>
            public string subtractFromDate(string fromDate, int numDays)
            {
                int year, month, day;
                getDateInfo(fromDate, out year, out month, out day);
                DateTime dateTime = new DateTime(year, month, day, new PersianCalendar());
                DateTime result = dateTime.Subtract(new TimeSpan(numDays, 0, 0, 0));
                return (getDateStr(result));
                //			return( string.Format("{0}/{1}/{2}", result.Year , result.Month.ToString("00"), 
                //								   result.Day.ToString("00")));
            }


            public int subtract2DateInstr(string dateFrom, string dateTo)
            {
                //These two line is replaced with the lines bellow,because
                //it use the dateTime function which do not accept the 02/31
                //please inform davoood

                //TimeSpan diff = subtract2Date( dateFrom, dateTo);
                //return(diff.Days);

                int year1, month1, day1;
                int year2, month2, day2;

                getDateInfo(dateFrom, out year1, out month1, out day1);
                getDateInfo(dateTo, out year2, out month2, out day2);

                int dayFromfirst = (year1 - 1) * 365 + (month1 - 1) * 31 + day1;
                if (month1 > 7) dayFromfirst -= month1 - 7;  //correct the 30 days month

                int dayTofirst = (year2 - 1) * 365 + (month2 - 1) * 31 + day2;
                if (month2 > 7) dayTofirst -= month2 - 7;  //correct the 30 days month

                return (dayFromfirst - dayTofirst);

            }
            /// <summary>
            /// Computes the subtract of date1 from date2 ( date2 - date1) and returns the corresponding 
            /// date result
            /// </summary>
            /// <param name="date1"></param>
            /// <param name="date2"></param>
            /// <returns></returns>
            public string subtract2DateStr(string date1, string date2)
            {
                TimeSpan diff = subtract2Date(date1, date2);
                DateTime diffDate = new DateTime(diff.Ticks);

                return (getDateStr(diffDate));
            }
            public TimeSpan subtract2DateTimeStr(string dateFrom, string timeFrom, string dateTo, string timeTo)
            {
                DateTime from = (new PersianCalendar()).ToDateTime(dateFrom);
                DateTime to = (new PersianCalendar()).ToDateTime(dateTo);
                int hourFrom = int.Parse(timeFrom.Substring(0, 2));
                int hourTo = int.Parse(timeTo.Substring(0, 2));
                int minuteFrom = int.Parse(timeFrom.Substring(3, 2));
                int minuteTo = int.Parse(timeTo.Substring(3, 2));

                from = new DateTime(from.Year, from.Month, from.Day, hourFrom, minuteFrom, 0, 0);
                to = new DateTime(to.Year, to.Month, to.Day, hourTo, minuteTo, 0, 0);

                TimeSpan diff = to.Subtract(from);
                return diff;

            }

        }

    }
}
*/