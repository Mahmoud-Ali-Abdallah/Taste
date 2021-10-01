using System;
using System.Collections.Generic;
using System.Text;
using Taste.Models;
using Taste.Models.DTO;

namespace Taste.DataAccessLayer.Data.Repository.IRepository
{
    public interface IShoppingCartRepository : IRepository<ShoppingCart>
    {
        int IncrementCount(ShoppingCart shoppingCart, int count);
        int DecrementCount(ShoppingCart shoppingCart, int count);
    }
}
