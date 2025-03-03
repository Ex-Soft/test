﻿using System;
using TimeZoneConverter;

namespace TestDateTimeOffset
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                tmpString;

            DateTimeOffset
                tmpDateTimeOffset1,
                tmpDateTimeOffset2;

            DateTime
                tmpDateTime1,
                tmpDateTime2;

            TimeZoneInfo
                timeZoneInfo;

            TimeSpan
                timeSpan;

            tmpDateTime1 = new DateTime(1899, 12, 30, 0, 0, 0, DateTimeKind.Local);
            tmpString = tmpDateTime1.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "1899-12-30 12:00:00 +02:00"
            tmpDateTimeOffset1 = new DateTimeOffset(1899, 12, 30, 0, 0, 0, new TimeSpan(0, 2, 0, 0, 0));
            tmpString = tmpDateTimeOffset1.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "1899-12-30 12:00:00 +02:00"
            
            tmpString = "2022-10-29T03:59:59+03:00";
            DateTime.TryParse(tmpString, out tmpDateTime1);
            tmpDateTime2 = tmpDateTime1.AddDays(1);
            tmpString = tmpDateTime2.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2022-10-30 03:59:59 +02:00"
            tmpString = "2022-10-29T04:00:00+03:00";
            DateTime.TryParse(tmpString, out tmpDateTime1);
            tmpDateTime2 = tmpDateTime1.AddDays(1);
            tmpString = tmpDateTime2.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2022-10-30 04:00:00 +02:00"

            tmpString = "2022-10-29T03:59:59+03:00";
            DateTimeOffset.TryParse(tmpString, out tmpDateTimeOffset1);
            tmpDateTimeOffset2 = tmpDateTimeOffset1.AddDays(1);
            tmpString = tmpDateTimeOffset2.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2022-10-30 03:59:59 +03:00"
            tmpDateTime1 = tmpDateTimeOffset1.DateTime;
            tmpString = "2022-10-29T04:00:00+03:00";
            DateTimeOffset.TryParse(tmpString, out tmpDateTimeOffset1);
            tmpDateTimeOffset2 = tmpDateTimeOffset1.AddDays(1);
            tmpString = tmpDateTimeOffset2.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2022-10-30 04:00:00 +03:00"

            // https://devblogs.microsoft.com/dotnet/cross-platform-time-zones-with-net-core/
            timeZoneInfo = TZConvert.GetTimeZoneInfo("Pacific Standard Time");
            tmpDateTime1 = new DateTime(2020, 9, 28, 0, 0, 0, DateTimeKind.Unspecified);
            timeSpan = timeZoneInfo.GetUtcOffset(tmpDateTime1);
            tmpDateTimeOffset1 = new DateTimeOffset(tmpDateTime1, timeSpan);
            tmpString = tmpDateTimeOffset1.ToString("u"); // "2020-09-28 07:00:00Z"
            tmpString = tmpDateTimeOffset1.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2020-09-28 12:00:00 -07:00"

            timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
            tmpDateTime1 = new DateTime(2020, 9, 28, 0, 0, 0, DateTimeKind.Unspecified);
            timeSpan = timeZoneInfo.GetUtcOffset(tmpDateTime1);
            tmpDateTimeOffset1 = new DateTimeOffset(tmpDateTime1, timeSpan);
            tmpString = tmpDateTimeOffset1.ToString("u"); // "2020-09-28 07:00:00Z"
            tmpString = tmpDateTimeOffset1.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2020-09-28 12:00:00 -07:00"

            tmpDateTime1 = new DateTime(2020, 9, 28, 0, 0, 0, DateTimeKind.Unspecified);
            tmpString = tmpDateTime1.ToString("u"); // "2020-09-28 00:00:00Z"
            tmpString = tmpDateTime1.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2020-09-28 12:00:00 +03:00"
            tmpDateTime2 = TimeZoneInfo.ConvertTime(tmpDateTime1, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"), TimeZoneInfo.Utc);
            tmpString = tmpDateTime2.ToString("u"); // "2020-09-28 07:00:00Z"
            tmpString = tmpDateTime2.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2020-09-28 07:00:00 +00:00"
            tmpDateTime1 = TimeZoneInfo.ConvertTime(tmpDateTime2, TimeZoneInfo.Utc, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"));
            tmpString = tmpDateTime1.ToString("u"); // "2020-09-28 00:00:00Z"
            tmpDateTime1 = new DateTime(2020, 12, 31, 0, 0, 0, DateTimeKind.Unspecified);
            tmpDateTime2 = TimeZoneInfo.ConvertTime(tmpDateTime1, TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"), TimeZoneInfo.Utc);
            tmpString = tmpDateTime2.ToString("u"); // "2020-09-28 08:00:00Z"
            tmpString = tmpDateTime2.ToString("yyyy-MM-dd hh:mm:ss zzz"); // "2020-09-28 08:00:00 +00:00"

            tmpString = "1583020799000"; // 2020-02-29 23:59:59 GMT || 2020-03-01 01:59:59 GMT+02
            tmpDateTimeOffset1 = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(tmpString));
            tmpDateTime1 = tmpDateTimeOffset1.DateTime;
            tmpDateTime2 = tmpDateTimeOffset1.UtcDateTime;
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2 ? "=" : "!")}= tmpDateTime2";
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2.ToUniversalTime() ? "=" : "!")}= tmpDateTime2.ToUniversalTime()";
            tmpString = $"DateTime.Equals(tmpDateTime1, tmpDateTime2) = {DateTime.Equals(tmpDateTime1, tmpDateTime2)}";
            tmpDateTime2 = tmpDateTime1.ToUniversalTime();
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2 ? "=" : "!")}= tmpDateTime2";
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2.ToUniversalTime() ? "=" : "!")}= tmpDateTime2.ToUniversalTime()";
            tmpString = $"DateTime.Equals(tmpDateTime1, tmpDateTime2) = {DateTime.Equals(tmpDateTime1, tmpDateTime2)}";

            tmpString = "1583013599000"; // 2020-02-29 23:59:59 GMT+02 || 2020-02-29 21:59:59 GMT
            tmpDateTimeOffset1 = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(tmpString));
            tmpDateTime1 = tmpDateTimeOffset1.DateTime;
            tmpDateTime2 = tmpDateTimeOffset1.UtcDateTime;
            tmpDateTime2 = tmpDateTime1.ToUniversalTime();

            tmpString = "2020-02-29T23:59:59";
            DateTime.TryParse(tmpString, out tmpDateTime1);
            tmpDateTime2 = new DateTime(2020, 2, 29, 23, 59, 59);
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2 ? "=" : "!")}= tmpDateTime2";
            tmpString = $"DateTime.Equals(tmpDateTime1, tmpDateTime2) = {DateTime.Equals(tmpDateTime1, tmpDateTime2)}";
            
            tmpDateTime1 = new DateTime(2020, 2, 29, 23, 59, 59, DateTimeKind.Utc);
            tmpString = tmpDateTime1.ToString("o"); // "2020-02-29T23:59:59.0000000Z"
            tmpString = tmpDateTime1.ToUniversalTime().ToString("o"); // "2020-02-29T23:59:59.0000000Z"
            tmpString = tmpDateTime1.ToString("O"); // "2020-02-29T23:59:59.0000000Z"
            tmpString = tmpDateTime1.ToUniversalTime().ToString("O"); // "2020-02-29T23:59:59.0000000Z"
            tmpString = tmpDateTime1.ToString("u"); // "2020-02-29 23:59:59Z"
            tmpString = tmpDateTime1.ToUniversalTime().ToString("u"); // "2020-02-29 23:59:59Z"
            tmpString = tmpDateTime1.ToString("U"); // "Saturday, 29 February, 2020 11:59:59 pm"
            tmpString = tmpDateTime1.ToUniversalTime().ToString("U"); // "Saturday, 29 February, 2020 11:59:59 pm"
        }
    }
}
