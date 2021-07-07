using Entities;
using Utilities.Results;

namespace Business
{
    public interface IUserManager
    {
        IDataResult<User> Login(string email, string password);
        IResult Register(Customer customer);
    }
}
