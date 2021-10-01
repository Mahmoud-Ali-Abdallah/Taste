using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taste.DataAccessLayer.Data.Repository.IRepository;
using Taste.Models;
using Taste.Models.DTO;

namespace Taste.DataAccessLayer.Data.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private readonly ApplicationDbContext db;


        public ShoppingCartRepository(ApplicationDbContext _db) : base(_db)
        {
            db = _db;
        }

        public int DecrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count -= count;
            return shoppingCart.Count;

        }

        public int IncrementCount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.Count += count;
            return shoppingCart.Count;

        }
    }
}
