#nullable enable

using DTOResturant;
using System;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.ValidationAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PositiveIdAttribute : ValidationAttribute
    {
        public PositiveIdAttribute()
        {
            ErrorMessage = "המזהה חייב להיות מספר שלם הגדול מ־0.";
        }

        public override bool IsValid(object? value)
        {
            // Required handles missing values.
            if (value == null)
                return true;

            return value is int id && id > 0;
        }
    }
}
