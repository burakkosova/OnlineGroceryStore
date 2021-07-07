using Entities;

namespace DataAccess.Abstract
{
    public interface ICustomerDal
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void UpdatePassword(int customerId, string newPassword);
        void Delete(int customerId);
        Customer GetByEmail(string email);
    }
}
