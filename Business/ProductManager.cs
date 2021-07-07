using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using System;
using System.Collections.Generic;
using System.IO;

namespace Business
{
    public class ProductManager
    {
        private static ProductManager _productManager;
        private IProductDal _productDal;

        private ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }
        public static ProductManager CreateAsSingleton()
        {
            if (_productManager == null)
            {
                _productManager = new ProductManager(new ProductDal());
            }
            return _productManager;
        }
        public bool AddProduct(Product product)
        {
            CheckFileName(product);

            if (CheckPrice(product.Price))
            {
                return false;
            }

            _productDal.Add(product);
            return true;
        }

        public bool UpdateProduct(Product product)
        {
            CheckFileName(product);

            if (CheckPrice(product.Price) || product.Id <= 0)
            {
                return false;
            }

            _productDal.Update(product);
            return true;
        }

        private static void CheckFileName(Product product)
        {
            if (string.IsNullOrEmpty(product.FileName))
            {
                product.FileName = "null.png";
            }
        }

        public void DeleteProduct(int productId)
        {
            _productDal.Delete(productId);
        }

        public List<Product> GetAll()
        {
            return _productDal.GetAll();
        }

        private bool CheckPrice(double price)
        {
            return price <= 0;
        }
    }
}
