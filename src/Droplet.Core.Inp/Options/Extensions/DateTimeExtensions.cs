// DateTimeExtensions.cs
// By: Adam Renaud
// Created: 2019-08-09

using System;

namespace Droplet.Core.Inp.Options.Extensions
{
    /// <summary>
    /// Extensions for the DateTime class
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Combine the date of this DateTime with the time of another DateTime     
        /// </summary>
        /// <param name="date">This DateTime (The date)</param>
        /// <param name="time">The time that will be combined</param>
        public static void CombineTime(this DateTime date, DateTime time)
        {
            var newDateTime = new DateTime(date.Year, date.Month, date.Day, time.Hour, time.Minute, time.Second);
            date = newDateTime;
        }
    }
}
