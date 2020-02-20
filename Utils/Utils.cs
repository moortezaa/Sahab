using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sahab_Desktop.Utils
{
    class Utils
    {
        public static DateTime ParsePersianDateString(string persianDate)
        {
            try
            {
                var dateTime = DateTime.ParseExact(persianDate, "yyyy/MM/dd", new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime();
                return dateTime;
            }
            catch (FormatException)
            {
                var persianDates = persianDate.Split('/');
                persianDates[0] = persianDates[0].Length == 4 ? persianDates[0] : $"13{persianDates[0]}";
                persianDates[1] = persianDates[1].Length == 2 ? persianDates[1] : $"0{persianDates[1]}";
                persianDates[2] = persianDates[2].Length == 2 ? persianDates[2] : $"0{persianDates[2]}";
                return DateTime.ParseExact(string.Join("/", persianDates), "yyyy/MM/dd", new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime();
            }
        }
        public static DateTime ParsePersianTimeString(string persianTime)
        {
            try
            {
                var dateTime = DateTime.ParseExact(persianTime, "HH:mm", new CultureInfo("fa-IR")).ToUniversalTime().ToLocalTime();
                return dateTime;
            }
            catch (FormatException)
            {
                var persianDates = persianTime.Split(':');
                if (persianDates.Length == 1)
                {
                    persianDates = (persianDates[0] + ":00").Split(':');
                }
                if (persianDates.Length == 2)
                {
                    persianDates = (persianDates[0] + ":" + persianDates[1] + ":00").Split(':');
                }
                persianDates[0] = persianDates[0].Length == 2 ? (persianDates[0] == "24" ? "00" : persianDates[0]) : ($"0{persianDates[0]}" == "24" ? "00" : persianDates[0]);
                persianDates[1] = persianDates[1].Length == 2 ? persianDates[1] : $"0{persianDates[1]}";
                persianDates[2] = persianDates[2].Length == 2 ? persianDates[2] : $"0{persianDates[2]}";
                return DateTime.ParseExact(string.Join(":", persianDates), "HH:mm:ss", new CultureInfo("en-US")).ToUniversalTime().ToLocalTime();
            }
        }
    }
}
