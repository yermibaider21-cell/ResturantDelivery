#nullable enable

using DTOResturant;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.Models
{
    public class Dish : Model
    {
        private int dishID;
        private int categoryID;
        private string dishName = string.Empty;
        private double price;
        private string description = string.Empty;
        private bool isAvailable = true;

        public Dish()
        {
            IsNeedValidate = true;
        }

        [Range(0, int.MaxValue, ErrorMessage = "מזהה המנה אינו יכול להיות שלילי.")]
        public int DishID
        {
            get => dishID;
            set
            {
                dishID = value;
                OnPropertyChanged(nameof(DishID));
            }
        }

        [PositiveId(ErrorMessage = "יש לבחור קטגוריה תקינה.")]
        public int CategoryID
        {
            get => categoryID;
            set
            {
                categoryID = value;
                OnPropertyChanged(nameof(CategoryID));
            }
        }

        [Required(ErrorMessage = "יש להזין שם מנה.")]
        [StringLength(100, ErrorMessage = "שם מנה יכול להכיל עד 100 תווים.")]
        public string DishName
        {
            get => dishName;
            set
            {
                dishName = value;
                OnPropertyChanged(nameof(DishName));
            }
        }

        [NonNegativePrice]
        public double Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public bool IsAvailable
        {
            get => isAvailable;
            set
            {
                isAvailable = value;
                OnPropertyChanged(nameof(IsAvailable));
            }
        }
    }
}
