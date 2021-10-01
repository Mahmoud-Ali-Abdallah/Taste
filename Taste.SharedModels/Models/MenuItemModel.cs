using System;
using System.ComponentModel.DataAnnotations;

namespace Taste.SharedModels.Models
{
    public class MenuItemModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; } = "test";
        [Required(ErrorMessage = "Must upload image")]
        public string Image { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Price should be greater than $1")]
        public double Price { get; set; }

        [Required(ErrorMessage ="Must select category")]
        public int CategoryId { get; set; }

        public virtual CategoryModel Category { get; set; }

        [Required(ErrorMessage = "Must select FoodType")]
        public int FoodTypeId { get; set; }

        public virtual FoodTypeModel FoodType { get; set; }
    }
}
