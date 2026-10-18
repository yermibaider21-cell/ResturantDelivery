using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOResturant.Models.Models;

namespace DTOResturant.Models.ViewModel
{
    internal class MenuViewModel
    {
        public Category catagory { get; set; }
        public  Dish dish { get; set; } 
    }
}
