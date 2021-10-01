using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Taste.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int DisplayOrder { get; set; }
    }
}
