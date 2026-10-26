#nullable enable

using DTOResturant;
using System;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.ValidationAttribute
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NonNegativePriceAttribute : System.ComponentModel.DataAnnotations.ValidationAttribute
    {
        public NonNegativePriceAttribute()
        {
            ErrorMessage = "המחיר חייב להיות מספר תקין שאינו שלילי.";
        }

        public override bool IsValid(object? value)
        {
            // Required handles missing values.
            if (value == null)
                return true;

            if (!(value is double price))
                return false;

            return !double.IsNaN(price)
                && !double.IsInfinity(price)
                && price >= 0;
        }
    }
}
