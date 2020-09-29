using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneClickZip.Includes.Utilities
{
    class ConverterUtils
    {
        private static readonly string[] SIZE_SUFFIXES =
                       { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string humanReadableFileSize(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SIZE_SUFFIXES[-value]; }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SIZE_SUFFIXES[mag]);
        }


        // 0.63 ms
        public static string ConvertToHourMinuteSeconds(long secs)
        {
            long hours = secs / 3600;
            long mins = (secs % 3600) / 60;
            secs = secs % 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, mins, secs);
        }

        // 0.64 ms
        public static string ConvertToHourMinuteSecondsUsingModulo(long secs)
        {
            long s = secs % 60;
            secs /= 60;
            long mins = secs % 60;
            long hours = secs / 60;
            return string.Format("{0:D2}:{1:D2}:{2:D2}", hours, mins, s);
        }

        // 0.70 ms
        public static string ConvertToHourMinuteSecondsUsingTimeSpan(long secs)
        {
            TimeSpan t = TimeSpan.FromSeconds(secs);
            return string.Format("{0:D2}:{1:D2}:{2:D2}",
                (int)t.TotalHours,
                t.Minutes,
                t.Seconds);
        }
    }


}
