using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;

namespace Stackoverflow.Website.Extensions
{
    public static class GeneralExtensions
    {
        public static TEnum ToEnum<TEnum>(this int value) where TEnum : Enum
        {
            var values = Enum.GetValues(typeof(TEnum));
            if (Enum.IsDefined(typeof(TEnum), value))
            {
                return (TEnum)values.GetValue(value);
            }
            else
            {
                return (TEnum)values.GetValue(0);
            }
        }

        public static string ToSimpleDatetimeDifferenceString(this DateTime date)
        {
            var dif = DateTime.Now - date;

            if (dif.Days != 0)
            {
                if (dif.Days > 30)
                {
                    return $"{dif.Days / 30}M ago.";
                }

                return $"{dif.Days}d ago";
            }
            else if (dif.Hours != 0)
            {
                return $"{dif.Hours}h ago.";
            }
            else if (dif.Minutes != 0)
            {
                return $"{dif.Minutes}m ago.";
            }
            else
            {
                return $"{dif.Seconds}s ago.";
            }
        }

        public static string ToFormatedDatetimeString(this DateTime date)
        {
            return date.ToString("MMMM dd, yyyy HH:mm");
        }

        public static bool IsValid(this IFormFile file, out string error)
        {
            if (file.Length > 2000000)
            {
                error = "Image is too large.";
                return false;
            }

            if (!new List<string>() { ".jpg", ".jpeg", ".png", ".bmp" }.Contains(Path.GetExtension(file.FileName)))
            {
                error = "Unsupported file extension.";
                return false;
            }

            error = string.Empty;
            return true;
        }

        public static string ToSalaryDisplayString(this decimal value)
        {
            return $"{Convert.ToInt32(value / 1000)}k";
        }

        public static string[] SplitByComma(this string value)
        {
            return value.Split(new char[] { ',' });
        }

        public static string ToShortFormatedDisplayString(this int value)
        {
            if (value < 1000)
            {
                return value.ToString();
            }
            else if (value < 1000000)
            {
                return $"{value / 1000}k";
            }
            else
            {
                return $"{value / 1000000}m";
            }
        }
    }
}
