using System;
using static System.Console;

namespace TestDateTimeOffset
{
    class Program
    {
        static void Main(string[] args)
        {
            string
                tmpString;

            DateTimeOffset
                tmpDateTimeOffset;

            DateTime
                tmpDateTime1,
                tmpDateTime2;

            tmpString = "1583020799000"; // 2020-02-29 23:59:59 GMT || 2020-03-01 01:59:59 GMT+02
            tmpDateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(tmpString));
            tmpDateTime1 = tmpDateTimeOffset.DateTime;
            tmpDateTime2 = tmpDateTimeOffset.UtcDateTime;
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2 ? "=" : "!")}= tmpDateTime2";
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2.ToUniversalTime() ? "=" : "!")}= tmpDateTime2.ToUniversalTime()";
            tmpString = $"DateTime.Equals(tmpDateTime1, tmpDateTime2) = {DateTime.Equals(tmpDateTime1, tmpDateTime2)}";
            tmpDateTime2 = tmpDateTime1.ToUniversalTime();
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2 ? "=" : "!")}= tmpDateTime2";
            tmpString = $"tmpDateTime1 {(tmpDateTime1 == tmpDateTime2.ToUniversalTime() ? "=" : "!")}= tmpDateTime2.ToUniversalTime()";
            tmpString = $"DateTime.Equals(tmpDateTime1, tmpDateTime2) = {DateTime.Equals(tmpDateTime1, tmpDateTime2)}";

            tmpString = "1583013599000"; // 2020-02-29 23:59:59 GMT+02 || 2020-02-29 21:59:59 GMT
            tmpDateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(Convert.ToInt64(tmpString));
            tmpDateTime1 = tmpDateTimeOffset.DateTime;
            tmpDateTime2 = tmpDateTimeOffset.UtcDateTime;
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
