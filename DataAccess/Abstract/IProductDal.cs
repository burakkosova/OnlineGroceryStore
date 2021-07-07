using Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IProductDal
    {
        List<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int productId);
    }
}
