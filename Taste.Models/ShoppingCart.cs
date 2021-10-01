using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taste.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string ApplicationUserId { get; set; }
        public int Count { get; set; }

        [ForeignKey("MenuItemId")]
        public virtual MenuItem MenuItem { get; set; }
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
