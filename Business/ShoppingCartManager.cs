using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class ShoppingCartManager
    {
        private static ShoppingCartManager _shoppingCartManager;
        private IShoppingCartDal _shoppingCartDal;

        public ShoppingCartManager(IShoppingCartDal shoppingCartDal)
        {
            _shoppingCartDal = shoppingCartDal;
        }

        public static ShoppingCartManager CreateAsSingleton()
        {
            if (_shoppingCartManager == null)
            {
                _shoppingCartManager = new ShoppingCartManager(new ShoppingCartDal());
            }
            return _shoppingCartManager;
        }

        public List<ShoppingCart> GetCustomerCart(int customerId)
        {
            return _shoppingCartDal.GetByCustomerId(customerId);
        }

        public void Add(ShoppingCart shoppingCart)
        {
            ShoppingCart sp = _shoppingCartDal.Get(shoppingCart.CustomerId,shoppingCart.Product.Id);

            if (sp.CustomerId == 0)
            {
                _shoppingCartDal.Add(shoppingCart);
                return;
            }

            sp.Amount++;
            _shoppingCartDal.Update(sp);
        }

        public void UpdateAmount(ShoppingCart shoppingCart)
        {
            _shoppingCartDal.Update(shoppingCart);
        }

        public void DeleteProduct(ShoppingCart shoppingCart)
        {
            _shoppingCartDal.Delete(shoppingCart);
        }
    }
}
