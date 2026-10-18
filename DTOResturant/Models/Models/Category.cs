#nullable enable

using DTOResturant;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.Models
{
    public class Category : Model
    {
        private int categoryID;
        private string categoryName = string.Empty;

        public Category()
        {
            IsNeedValidate = true;
        }

        [Range(0, int.MaxValue, ErrorMessage = "מזהה הקטגוריה אינו יכול להיות שלילי.")]
        public int CategoryID
        {
            get => categoryID;
            set
            {
                categoryID = value;
                OnPropertyChanged(nameof(CategoryID));
            }
        }

        [Required(ErrorMessage = "יש להזין שם קטגוריה.")]
        [StringLength(60, ErrorMessage = "שם קטגוריה יכול להכיל עד 60 תווים.")]
        public string CategoryName
        {
            get => categoryName;
            set
            {
                categoryName = value;
                OnPropertyChanged(nameof(CategoryName));
            }
        }
    }
}
