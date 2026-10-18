#nullable enable

using DTOResturant;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.Models
{
    public class User : Model
    {
        private int userID;
        private string fullName = string.Empty;
        private string email = string.Empty;
        private string passwordHash = string.Empty;
        private bool isManager;
        private bool isActive = true;
        private string address = string.Empty;

        public User()
        {
            IsNeedValidate = true;
        }

        [Range(0, int.MaxValue, ErrorMessage = "מזהה המשתמש אינו יכול להיות שלילי.")]
        public int UserID
        {
            get => userID;
            set
            {
                userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        [Required(ErrorMessage = "יש להזין שם מלא.")]
        [StringLength(100, ErrorMessage = "שם מלא יכול להכיל עד 100 תווים.")]
        public string FullName
        {
            get => fullName;
            set
            {
                fullName = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        [Required(ErrorMessage = "יש להזין כתובת אימייל.")]
        [EmailAddress(ErrorMessage = "כתובת האימייל אינה תקינה.")]
        [StringLength(150, ErrorMessage = "כתובת אימייל יכולה להכיל עד 150 תווים.")]
        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        [Required(ErrorMessage = "חסר ערך גיבוב הסיסמה.")]
        [StringLength(255, ErrorMessage = "גיבוב הסיסמה יכול להכיל עד 255 תווים.")]
        public string PasswordHash
        {
            get => passwordHash;
            set
            {
                passwordHash = value;
                OnPropertyChanged(nameof(PasswordHash));
            }
        }

        public bool IsManager
        {
            get => isManager;
            set
            {
                isManager = value;
                OnPropertyChanged(nameof(IsManager));
            }
        }

        public bool IsActive
        {
            get => isActive;
            set
            {
                isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        [StringLength(255, ErrorMessage = "כתובת יכולה להכיל עד 255 תווים.")]
        public string Address
        {
            get => address;
            set
            {
                address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
    }
}
