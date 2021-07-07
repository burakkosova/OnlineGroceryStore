using Entities;
using System;
using System.Net.Mail;
using Utilities.Results;

namespace Utilities.Validation
{
    public static class Validation
    {
        public static IResult ValidatePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return new ErrorResult("Password field can't be empty");
            }

            if (password.Length < 3 || password.Length > 20)
            {
                return new ErrorResult("Password field must be between 3 and 20 characters long");
            }

            return new SuccessResult();
        }

        public static IResult ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return new ErrorResult("Email field can't be empty");
            }

            try
            {
                MailAddress mail = new MailAddress(email);
            }
            catch (FormatException)
            {
                return new ErrorResult("Please enter valid email");
            }

            return new SuccessResult();
        }

        public static IResult ValidateCustomer(Customer customer)
        {
            if (string.IsNullOrEmpty(customer.FirstName) || string.IsNullOrEmpty(customer.LastName))
            {
                return new ErrorResult("Name and Surname fields must be filled");
            }

            if (!long.TryParse(customer.PhoneNumber, out _) || customer.PhoneNumber.Length > 15)
            {
                return new ErrorResult("Please provide valid phone number");
            }

            if (string.IsNullOrEmpty(customer.Address))
            {
                return new ErrorResult("Please provide address");
            }

            return ValidateLogin(customer.Email, customer.Password);
        }

        public static IResult ValidateLogin(string email, string password)
        {
            IResult emailResult = ValidateEmail(email);
            IResult passwordResult = ValidatePassword(password);
            if (!emailResult.Success)
            {
                return emailResult;
            }

            if (!passwordResult.Success)
            {
                return passwordResult;
            }
            return new SuccessResult();
        }
    }
}
