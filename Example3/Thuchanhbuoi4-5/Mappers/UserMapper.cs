using Thuchanhbuoi4_5.Models;
using Thuchanhbuoi4_5.ViewModels;

namespace Thuchanhbuoi4_5.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToViewModel(User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email
            };
        }
    }
}
