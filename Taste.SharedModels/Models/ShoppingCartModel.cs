namespace Taste.SharedModels.Models
{
    public class ShoppingCartModel
    {
        public int Id { get; set; }
        public int MenuItemId { get; set; }
        public string ApplicationUserId { get; set; }
        public int Count { get; set; }

        public MenuItemModel MenuItemModel { get; set; }

        public ApplicationUserModel ApplicationUserModel { get; set; }
    }
}
