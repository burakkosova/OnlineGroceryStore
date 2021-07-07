using DataAccess.Abstract;
using Entities;
using Utilities.Results;

namespace Business
{
    public class AdminManager : IUserManager
    {
        private IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public IDataResult<User> Login(string email, string password)
        {
            Admin admin = _adminDal.GetByEmail(email);

            if (admin.Id == 0)
            {
                return new ErrorDataResult<User>("This email address doesn't belong to any admin!");
            }

            if(!admin.Password.Equals(password))
            {
                return new ErrorDataResult<User>("Invalid password!");
            }

            return new SuccessDataResult<User>(admin);
        }

        public IResult Register(Customer customer)
        {
            return new ErrorResult("Admins can't register from here!");
        }
    }
}
