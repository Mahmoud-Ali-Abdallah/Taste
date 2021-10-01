using System.ComponentModel.DataAnnotations;

namespace Taste.SharedModels.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }
}
