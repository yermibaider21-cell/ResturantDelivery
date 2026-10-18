#nullable enable

using DTOResturant;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.Models
{
    public class Status : Model
    {
        private int statusID;
        private string statusName = string.Empty;

        public Status()
        {
            IsNeedValidate = true;
        }

        [Range(0, int.MaxValue, ErrorMessage = "מזהה הסטטוס אינו יכול להיות שלילי.")]
        public int StatusID
        {
            get => statusID;
            set
            {
                statusID = value;
                OnPropertyChanged(nameof(StatusID));
            }
        }

        [Required(ErrorMessage = "יש להזין שם סטטוס.")]
        [StringLength(50, ErrorMessage = "שם סטטוס יכול להכיל עד 50 תווים.")]
        [RegularExpression(@"^(cooking|ready|delivered)$", ErrorMessage = "הסטטוס חייב להיות cooking, ready או delivered.")]
        public string StatusName
        {
            get => statusName;
            set
            {
                statusName = value;
                OnPropertyChanged(nameof(StatusName));
            }
        }
    }
}
