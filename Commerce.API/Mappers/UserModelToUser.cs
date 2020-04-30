using Commerce.API.Models;
using Commerce.Data.Entities;

namespace Commerce.API.Mappers
{
    public class UserModelToUser : IMapper<UserModel, User>
    {
        public void Fill(UserModel input, User output)
        {
            output.Firstname = input.Firstname;
            output.Lastname = input.Lastname;
            output.EmailAddress = input.EmailAddress;
            output.PhoneNumber = input.PhoneNumber;
            output.Address = input.Address;
            output.Password = input.Password;
        }

        public User Map(UserModel input)
        {
            var output = new User()
            {
                Firstname = input.Firstname,
                Lastname = input.Lastname,
                EmailAddress = input.EmailAddress,
                PhoneNumber = input.PhoneNumber,
                Address = input.Address,
                Password = input.Password
            };

            return output;
        }
    }
}
