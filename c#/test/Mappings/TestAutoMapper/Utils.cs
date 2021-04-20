using System;

namespace TestAutoMapper
{
    public class Utils
    {
        public static DateTime FromUnixEpochSeconds(double timestamp)
        {
            var origin = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            return origin.AddSeconds(timestamp);
        }
    }
}
