#nullable enable

using DTOResturant;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace DTOResturant.Models.ValidationAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidOrderDateAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public ValidOrderDateAttribute()
        {
            ErrorMessage =
                "יש להזין תאריך ושעה תקינים בפורמט dd/MM/yyyy HH:mm:ss.";
        }

        public override bool IsValid(object? value)
        {
            // Required handles missing values.
            if (value == null)
                return true;

            if (!(value is string dateText))
                return false;

            if (string.IsNullOrWhiteSpace(dateText))
                return true;

            return DateTime.TryParseExact(
                dateText,
                "dd/MM/yyyy HH:mm:ss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }
    }
}
