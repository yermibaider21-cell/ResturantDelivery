#nullable enable

using DTOResturant;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.Models
{
    public class Order : Model
    {
        private int orderID;
        private int userID;
        private string orderDate = string.Empty;
        private int statusID;

        public Order()
        {
            IsNeedValidate = true;
        }

        [Range(0, int.MaxValue, ErrorMessage = "מזהה ההזמנה אינו יכול להיות שלילי.")]
        public int OrderID
        {
            get => orderID;
            set
            {
                orderID = value;
                OnPropertyChanged(nameof(OrderID));
            }
        }

        [PositiveId(ErrorMessage = "יש לבחור משתמש תקין.")]
        public int UserID
        {
            get => userID;
            set
            {
                userID = value;
                OnPropertyChanged(nameof(UserID));
            }
        }

        [Required(ErrorMessage = "יש להזין תאריך הזמנה.")]
        [StringLength(255, ErrorMessage = "תאריך ההזמנה ארוך מדי.")]
        [ValidOrderDate]
        public string OrderDate
        {
            get => orderDate;
            set
            {
                orderDate = value;
                OnPropertyChanged(nameof(OrderDate));
            }
        }

        [PositiveId(ErrorMessage = "יש לבחור סטטוס תקין.")]
        public int StatusID
        {
            get => statusID;
            set
            {
                statusID = value;
                OnPropertyChanged(nameof(StatusID));
            }
        }
    }
}
