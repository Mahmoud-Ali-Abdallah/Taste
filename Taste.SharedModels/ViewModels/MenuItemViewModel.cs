using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Taste.SharedModels.Models;

namespace Taste.SharedModels.ViewModels
{
    public class MenuItemViewModel
    {
        [ValidateComplexType]
        public MenuItemModel MenuItem { get; set; } = new();
        
        public IEnumerable<SelectedListItemViewModel> CategoryList { get; set; }
        
        public IEnumerable<SelectedListItemViewModel> FoodTypeList { get; set; } 

    }
}
