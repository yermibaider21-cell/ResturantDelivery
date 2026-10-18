#nullable enable

using DTO;
using System.ComponentModel.DataAnnotations;

namespace DTOResturant.Models.Models
{
    public class OrderDish : Model
    {
        private int orderID;
        private int dishID;
        private int quantity = 1;
        private double unitPrice;

        public OrderDish()
        {
            IsNeedValidate = true;
        }

        [PositiveId(ErrorMessage = "יש לבחור הזמנה תקינה.")]
        public int OrderID
        {
            get => orderID;
            set
            {
                orderID = value;
                OnPropertyChanged(nameof(OrderID));
            }
        }

        [PositiveId(ErrorMessage = "יש לבחור מנה תקינה.")]
        public int DishID
        {
            get => dishID;
            set
            {
                dishID = value;
                OnPropertyChanged(nameof(DishID));
            }
        }

        [Range(1, int.MaxValue, ErrorMessage = "הכמות חייבת להיות מספר שלם הגדול מ־0.")]
        public int Quantity
        {
            get => quantity;
            set
            {
                quantity = value;
                OnPropertyChanged(nameof(Quantity));
            }
        }

        [NonNegativePrice]
        public double UnitPrice
        {
            get => unitPrice;
            set
            {
                unitPrice = value;
                OnPropertyChanged(nameof(UnitPrice));
            }
        }
    }
}
