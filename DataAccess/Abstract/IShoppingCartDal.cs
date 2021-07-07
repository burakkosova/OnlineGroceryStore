using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IShoppingCartDal
    {
        List<ShoppingCart> GetByCustomerId(int customerId);
        ShoppingCart Get(int customerId, int productId);
        void Add(ShoppingCart shoppingCart);
        void Update(ShoppingCart shoppingCart);
        void Delete(ShoppingCart shoppingCart);
        void ClearCart(int customerId);
    }
}
