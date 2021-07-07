using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities;
using Utilities.Results;

namespace Business
{
    public class CustomerManager : IUserManager
    {
        private static CustomerManager _customerManager;
        private ICustomerDal _customerDal;

        private CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public static CustomerManager CreateAsSingleton()
        {
            if (_customerManager == null)
            {
                _customerManager = new CustomerManager(new CustomerDal());
            }
            return _customerManager;
        }

        public IDataResult<User> Login(string email, string password)
        {
            Customer customer = _customerDal.GetByEmail(email);

            if (customer.Id == 0)
            {
                return new ErrorDataResult<User>("This email address doesn't belong to any customer!");
            }

            if (!customer.Password.Equals(password))
            {
                return new ErrorDataResult<User>("Invalid password!");
            }

            return new SuccessDataResult<User>(customer);
        }

        public IResult Register(Customer customer)
        {
            // if a customer with the same email exists customer can't register
            if (CheckIfEmailExists(customer.Email))
            {
                return new ErrorResult("This email already exists!");
            }

            _customerDal.Add(customer);
            return new SuccessResult();
        }

        // updating needs id
        public void Update(Customer customer)
        {
            _customerDal.Update(customer);
        }

        public void UpdatePassword(int customerId, string newPassword)
        {
            _customerDal.UpdatePassword(customerId, newPassword);
        }

        public void RemoveAccount(int customerId)
        {
            _customerDal.Delete(customerId);
        }

        private bool CheckIfEmailExists(string email)
        {
            Customer result = _customerDal.GetByEmail(email);
            return result.Id != 0;
        }
    }
}
