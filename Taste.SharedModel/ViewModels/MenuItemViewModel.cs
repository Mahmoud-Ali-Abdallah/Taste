using System.Collections.Generic;

namespace Taste.UI.ViewModels
{
    public class MenuItemViewModel
    {
        public MenuItem  MenuItem  { get; set; }

        public IEnumerable<SelectedListItemViewModel> CategoryList { get; set; }

        public IEnumerable<SelectedListItemViewModel> FoodTypeList { get; set; }

    }
}
