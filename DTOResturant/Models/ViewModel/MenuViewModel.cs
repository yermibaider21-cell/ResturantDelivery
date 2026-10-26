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
        
        List<Category> categories { get; set; } 
        List<Dish> dishes { get; set; }
    }
}
