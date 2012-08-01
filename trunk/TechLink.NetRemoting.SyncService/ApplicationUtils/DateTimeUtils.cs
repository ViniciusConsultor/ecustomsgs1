using System;
using System.Collections.Generic;
using System.Globalization;

namespace ApplicationUtils.Utils
{
	public class DateTimeUtils
	{
		[Serializable]
		public struct TimeInterval
		{
			public static TimeInterval Zero = new TimeInterval(DateTime.MinValue, DateTime.MinValue, false);
			public static TimeInterval Max = new TimeInterval(DateTime.MinValue, DateTime.MaxValue, false);

			private DateTime intervalStart;
			private DateTime intervalEnd;
			private readonly bool includeMargins;

			public DateTime Start
			{
				get
				{
					return intervalStart;
				}
			}

			public DateTime End
			{
				get
				{
					return intervalEnd;
				}
			}

			public TimeSpan TimeSpan
			{
				get
				{
					if (this == Zero)
					{
						return TimeSpan.Zero;
					}

					return intervalEnd - intervalStart;
				}
			}

			/// <summary>
			/// Initializes a new instance of the <see cref="TimeInterval"/> class.
			/// </summary>
			/// <param name="intervalStart">The interval start.</param>
			/// <param name="intervalEnd">The interval end.</param>
			/// <param name="includeMargins">if set to <c>true</c> the intervalStart is reseted to hh:mm:ss = 00:00:00 and intervalStart at 23:59:59.Else, no modifications are made</param>
			public TimeInterval(DateTime intervalStart, DateTime intervalEnd, bool includeMargins)
			{
				this.includeMargins = includeMargins;
				if (intervalStart > intervalEnd)
				{
					throw new ArgumentException("The time interval cannot end before it begins, " + intervalStart + " > " + intervalEnd);
				}
				if (includeMargins)
				{
					this.intervalStart = GetBeggingOfTheDay(intervalStart);
					this.intervalEnd = GetEndOfTheDay(intervalEnd);
				}
				else
				{
					this.intervalStart = intervalStart;
					this.intervalEnd = intervalEnd;
				}
			}

			public static bool operator ==(TimeInterval a, TimeInterval b)
			{
				return a.Start == b.Start && a.End == b.End;
			}

			public static bool operator !=(TimeInterval a, TimeInterval b)
			{
				return a.Start != b.Start || a.End != b.End;
			}

			public override int GetHashCode()
			{
				return Start.GetHashCode() + End.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				if (obj is TimeInterval)
				{
					return ((TimeInterval)obj) == this;
				}
				return false;
			}

			public TimeInterval Intersect(TimeInterval interval, bool includeMargins)
			{
				return IntervalIntersection(this, interval, includeMargins);
			}

			public TimeInterval[] Exclude(TimeInterval interval, bool includeMargins)
			{
				TimeInterval intersection = Intersect(interval, includeMargins);
				if (intersection == Zero)
				{
					return new TimeInterval[] { this };
				}
				else
				{
					if (intersection == this)
					{
						return new TimeInterval[] { Zero };
					}
					if (intersection.Start == this.Start)
					{
						TimeInterval newInterval = new TimeInterval(intersection.End, this.End, includeMargins);
						return new TimeInterval[] { newInterval };
					}
					if (intersection.End == End)
					{
						TimeInterval newInterval = new TimeInterval(Start, intersection.Start, includeMargins);
						return new TimeInterval[] { newInterval };
					}
					TimeInterval newInterval1 = new TimeInterval(Start, intersection.Start, includeMargins);
					TimeInterval newInterval2 = new TimeInterval(intersection.End, End, includeMargins);
					return new TimeInterval[] { newInterval1, newInterval2 };
				}
			}

			public bool Includes(TimeInterval interval)
			{
				return Start <= interval.Start && End >= interval.End;
			}

			public override string ToString()
			{
				return this.Start + " - " + this.End;
			}

			public string ToString(string format)
			{
				return this.Start.ToString(format) + " - " + this.End.ToString(format);
			}

			public bool Contains(DateTime date)
			{
				return this.Start <= date && this.End >= date;
			}

			public double TotalYears
			{
				get
				{
					double result = 0.0;
					DateTime start = this.intervalStart;
					// Accumulate years without going over.
					int years = End.Year - start.Year;
					start = start.AddYears(years);

					if (start > this.End)
					{
						years--;
						start = this.intervalStart.AddYears(years);
					}
					result += years;
					//now they are at less then 1 year distance

					long ticksInYear = CultureInfo.InvariantCulture.Calendar.GetDaysInYear(start.Year) *
														 TimeSpan.TicksPerDay;
					long ticksInIterval = (new TimeInterval(start, intervalEnd, this.includeMargins)).TimeSpan.Ticks + 1;

					result += (ticksInIterval / (double)ticksInYear);
					return result;
				}
			}

			public double TotalMonths
			{
				get
				{
					double result = 0.0;
					DateTime start = this.intervalStart;
					// Accumulate years without going over.
					int years = End.Year - start.Year;
					start = start.AddYears(years);

					if (start > this.End)
					{
						years--;
						start = this.intervalStart.AddYears(years);
					}
					result += years * 12;
					//now they are at less then 12 months distance

					//chech if the interval starts and ends in the same month
					if (start.Month == intervalEnd.Month)
					{
						long ticksInMonth = CultureInfo.InvariantCulture.Calendar.GetDaysInMonth(start.Year, start.Month) *
																TimeSpan.TicksPerDay;
						long ticksInIterval = (new TimeInterval(start, intervalEnd, this.includeMargins)).TimeSpan.Ticks + 1;

						result += (ticksInIterval / (double)ticksInMonth);
					}
					else
					{
						TimeInterval fraction1 = new TimeInterval(start, GetLastDayOfTheMonth(start), this.includeMargins);
						result += fraction1.TotalMonths;

						start = GetLastDayOfTheMonth(start).AddTicks(1);
						result += new TimeInterval(start, intervalEnd, this.includeMargins).TotalMonths;
					}

					return result;
				}
			}

			public double TotalWeeks
			{
				get
				{
					return this.TimeSpan.TotalDays / 7;
				}
			}

			public double TotalDays
			{
				get
				{
					return this.TimeSpan.TotalDays;
				}
			}

			public int TotalWorkingDays(DayOfWeek[] freeDays)
			{
				List<DayOfWeek> freeDaysList = new List<DayOfWeek>();
				freeDaysList.AddRange(freeDays);
				int result = 0;
				DateTime start = this.Start;
				if (!freeDaysList.Contains(start.DayOfWeek))
				{
					result++;
				}
				while (start.Date < this.End.Date)
				{
					start = start.AddDays(1);
					if (!freeDaysList.Contains(start.DayOfWeek))
					{
						result++;
					}
				}
				return result;
			}

			public double TotalHours
			{
				get
				{
					return TimeSpan.TotalHours;
				}
			}

			public double TotalMilliseconds
			{
				get
				{
					return TimeSpan.TotalMilliseconds;
				}
			}

			public double TotalMinutes
			{
				get
				{
					return TimeSpan.TotalMinutes;
				}
			}

			public double TotalSeconds
			{
				get
				{
					return TimeSpan.TotalSeconds;
				}
			}
		}

		/// <summary>
		/// Parse the string using the de-CH format (dd.MM.)
		/// </summary>
		/// <param name="dataTimeStr"></param>
		/// <param name="dateTime"></param>
		/// <returns></returns>
		public static bool TryParseDateTime(string dataTimeStr, out DateTime dateTime)
		{
			if (DateTime.TryParseExact(dataTimeStr, "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out dateTime))
			{
				return true;
			}

			if (DateTime.TryParseExact(dataTimeStr, "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out dateTime))
			{
				return true;
			}
			try
			{
				dateTime = DateTime.Parse(dataTimeStr, CultureInfo.GetCultureInfo("de-CH").DateTimeFormat);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>
		/// Parse the string using the de-CH format (dd.MM.yyyy)
		/// </summary>
		/// <param name="dataTimeStr"></param>
		/// <returns>The parsed date if successfull, DateTime.MinValue otherwise</returns>
		public static DateTime TryParse(string dataTimeStr)
		{
			DateTime dateTime = DateTime.MinValue;
			if (DateTime.TryParseExact(dataTimeStr, "dd.MM.yyyy", CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out dateTime))
			{
				return dateTime;
			}

			if (DateTime.TryParseExact(dataTimeStr, "dd-MM-yyyy", CultureInfo.CurrentCulture, DateTimeStyles.RoundtripKind, out dateTime))
			{
				return dateTime;
			}
			try
			{
				dateTime = DateTime.Parse(dataTimeStr, CultureInfo.GetCultureInfo("de-CH").DateTimeFormat);
				return dateTime;
			}
			catch
			{
				return DateTime.MinValue;
			}
		}

		public static DateTime GetLastDayOfTheMonth(DateTime dateTime)
		{
			if (dateTime == DateTime.MaxValue)
			{
				return DateTime.MaxValue;
			}
			int month = dateTime.Month + 1;
			int year = dateTime.Year;
			if (month > 12)
			{
				month = 1;
				year++;
			}
			return new DateTime(year, month, 1).AddTicks(-1);
		}

		public static DateTime GetEndOfTheDay(DateTime dateTime)
		{
			if (dateTime.ToString("dd.MM.yyyy HH:mm:ss") == DateTime.MaxValue.ToString("dd.MM.yyyy HH:mm:ss"))
			{
				return dateTime;
			}
			else
			{
				return dateTime.AddDays(1).Date.AddTicks(-1);
			}
		}

		/// <summary>
		/// Gets the begging of the day,the Date component ot the instance, at hh:mm:ss to 00:00:00
		/// </summary>
		/// <param name="dateTime">The date time.</param>
		/// <returns></returns>
		public static DateTime GetBeggingOfTheDay(DateTime dateTime)
		{
			return dateTime.Date;
		}

		public static DateTime GetFirstWorkingDayOfTheWeek(DateTime dateTime)
		{
			switch (dateTime.DayOfWeek)
			{
				case DayOfWeek.Monday:
					return dateTime.Date;
				case DayOfWeek.Tuesday:
					return dateTime.Date.AddDays(-1);
				case DayOfWeek.Wednesday:
					return dateTime.Date.AddDays(-2);
				case DayOfWeek.Thursday:
					return dateTime.Date.AddDays(-3);
				case DayOfWeek.Friday:
					return dateTime.Date.AddDays(-4);
				case DayOfWeek.Saturday:
					return dateTime.Date.AddDays(-5);
				case DayOfWeek.Sunday:
					return dateTime.Date.AddDays(-6);
				default:
					return dateTime.Date;
			}
		}

		public static DateTime GetLastWorkingDayOfTheWeek(DateTime dateTime)
		{
			DateTime firstDay = GetFirstWorkingDayOfTheWeek(dateTime);
			return firstDay.AddDays(5).AddTicks(-1);
		}

		public static DateTime GetFirstDayOfTheMonth(DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, 1);
		}

		public static DateTime GetFirstDayOfTheYear(DateTime dateTime)
		{
			return new DateTime(dateTime.Year, 1, 1);
		}

		public static DateTime GetLastDayOfTheYear(DateTime dateTime)
		{
			return new DateTime(dateTime.Year, 12, 31);
		}


		/// <summary>
		/// Gets the current month interval, the interval of time between the first day of the current month and the DateTime.Now
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetCurrentMonthInterval()
		{
			return new TimeInterval(GetFirstDayOfTheMonth(DateTime.Now), DateTime.Now, false);
		}

		/// <summary>
		/// The interval of time between the first day of the current year and the DateTime.Now
		/// The interval is NOT extended to include the end of the include the end of the current day (hours 23:59:59)
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetCurrentYearInterval()
		{
			return new TimeInterval(GetFirstDayOfTheYear(DateTime.Now), DateTime.Now, false);
		}

		/// <summary>
		/// The interval of time between the first day and the last day of the month of the dateTime
		/// The interval is extended so that the begging of the interval starts at 00:00:00 and the end of the interval ends at 23:59:59
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetMonthInterval(DateTime dateTime)
		{
			return new TimeInterval(GetFirstDayOfTheMonth(dateTime), GetLastDayOfTheMonth(dateTime), true);
		}

		/// <summary>
		/// The interval of time between the first day and the last day of the month specefied in parameters.
		/// The interval is extended so that the begging of the interval starts at 00:00:00 and the end of the interval ends at 23:59:59
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetMonthInterval(int year, int month)
		{
			if (DateTime.MinValue.Year > year || DateTime.MaxValue.Year < year)
			{
				throw new ArgumentException(
						string.Format("year argument can have min value {0} and max value {1}", DateTime.MinValue.Year,
													DateTime.MaxValue.Year));
			}
			if (month < 1 || month > 12)
			{
				throw new ArgumentException(
						string.Format("month argument can have min value {0} and max value {1}", 1, 12));
			}
			DateTime yearDateTime = new DateTime(year, month, 1);
			return new TimeInterval(GetFirstDayOfTheMonth(yearDateTime), GetLastDayOfTheMonth(yearDateTime), true);
		}

		/// <summary>
		/// The interval of time between the current day and the next [monthsAhead] months.
		/// The interval is extended so that the begging of the interval starts at 00:00:00 and the end of the interval ends at 23:59:59
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetNextMonthsInterval(int monthsAhead)
		{
			if (monthsAhead < 1)
			{
				throw new ArgumentException("monthsAhead must be greater then 1");
			}
			return new TimeInterval(DateTime.Now, DateTime.Now.AddMonths(monthsAhead), true);
		}

		/// <summary>
		/// The interval of time between the current day and the next [yearsAhead] years.
		/// The interval is extended so that the begging of the interval starts at 00:00:00 and the end of the interval ends at 23:59:59
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetNextYearsInterval(int yearsAhead)
		{
			if (yearsAhead < 1)
			{
				throw new ArgumentException("yearsAhead must be greater then 1");
			}
			return new TimeInterval(DateTime.Now, DateTime.Now.AddYears(yearsAhead), true);
		}

		/// <summary>
		/// The interval of time between the first day and the last day of the year of the dateTime
		/// The interval is extended so that the begging of the interval starts at 00:00:00 and the end of the interval ends at 23:59:59
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetYearInterval(DateTime dateTime)
		{
			return new TimeInterval(GetFirstDayOfTheYear(DateTime.Now), GetLastDayOfTheYear(DateTime.Now), true);
		}

		/// <summary>
		/// The interval of time between the first day and the last day of the year of the dateTime
		/// The interval is extended so that the begging of the interval starts at 00:00:00 and the end of the interval ends at 23:59:59
		/// </summary>
		/// <returns></returns>
		public static TimeInterval GetYearInterval(int year)
		{
			if (DateTime.MinValue.Year > year || DateTime.MaxValue.Year < year)
			{
				throw new ArgumentException(
						string.Format("year argument can have min value {0} and max value {1}", DateTime.MinValue.Year,
													DateTime.MaxValue.Year));
			}
			DateTime yearDateTime = new DateTime(year, 1, 1);
			return new TimeInterval(GetFirstDayOfTheYear(yearDateTime), GetLastDayOfTheYear(yearDateTime), true);
		}

		public static TimeInterval IntervalIntersection(TimeInterval firstInterval, TimeInterval secondInterval, bool includeMargins)
		{
			//if the two intervals have no intersection, return an 0 value TimeSpan;
			if (
					(firstInterval.Start < secondInterval.Start) && (firstInterval.End < secondInterval.Start)
					|| (secondInterval.Start < firstInterval.Start) && (secondInterval.End < firstInterval.Start)
					)
			{
				return TimeInterval.Zero;
			}

			DateTime intersectionStart = firstInterval.Start > secondInterval.Start ? firstInterval.Start : secondInterval.Start;
			DateTime intersectionEnd = firstInterval.End < secondInterval.End ? firstInterval.End : secondInterval.End;
			return new TimeInterval(intersectionStart, intersectionEnd, includeMargins);
		}

		public static bool IsEqualMinutesResolution(DateTime date1, DateTime date2)
		{

			DateTime date1_minutesResolution = GetDateMinutesResolution(date1);
			DateTime date2_minutesResolution = GetDateMinutesResolution(date2); ;

			return date1_minutesResolution == date2_minutesResolution;

		}

		public static bool IsLessOrEqualMinutesResolution(DateTime date1, DateTime date2)
		{
			DateTime date1_minutesResolution = GetDateMinutesResolution(date1);
			DateTime date2_minutesResolution = GetDateMinutesResolution(date2); ;
			return date1_minutesResolution <= date2_minutesResolution;
		}

		public static bool IsGraterOrEqualMinutesResolution(DateTime date1, DateTime date2)
		{
			DateTime date1_minutesResolution = GetDateMinutesResolution(date1);
			DateTime date2_minutesResolution = GetDateMinutesResolution(date2); ;
			return date1_minutesResolution >= date2_minutesResolution;
		}

		private static DateTime GetDateMinutesResolution(DateTime date1)
		{
			return new DateTime(date1.Year, date1.Month, date1.Day, date1.Hour, date1.Minute, 0);
		}

		public static string GetBaseDateTimeString(DateTime dateTime)
		{
			return string.Format("{0}.{1}.{2}-{3}:{4}:{5}", dateTime.Day, dateTime.Month, dateTime.Year, dateTime.Hour,
													 dateTime.Minute, dateTime.Second);
		}

		public static string GetBaseDateTimeNowString()
		{
			return GetBaseDateTimeString(DateTime.Now);
		}
	}

	[Serializable]
	public class DateTimeEncapsulator : IComparable, IComparable<DateTimeEncapsulator>
	{
		private DateTime date;

		public DateTimeEncapsulator(DateTime date)
		{
			this.date = date;
		}

		public int CompareTo(DateTimeEncapsulator other)
		{
			return this.date.CompareTo(other.date);
		}

		public override string ToString()
		{
			if (date != DateTime.MinValue)
			{
				return date.ToString("dd.MM.yyyy");
			}
			else
			{
				return string.Empty;
			}
		}

		public int CompareTo(object obj)
		{
			if (obj == null)
			{
				return 1;
			}
			if (obj is DateTimeEncapsulator)
			{
				return this.CompareTo(obj as DateTimeEncapsulator);
			}
			else return 1;
		}
	}
}