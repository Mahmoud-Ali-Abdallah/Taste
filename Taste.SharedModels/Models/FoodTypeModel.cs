using System.ComponentModel.DataAnnotations;

namespace Taste.SharedModels.Models
{
    public class FoodTypeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
