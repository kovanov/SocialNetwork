using System.Collections.Generic;
using System.Threading.Tasks;

namespace SocialNetwork.Models
{
    public interface IUserManager
    {
        ProfileViewModel GetProfileByUserIdentityName(string identity);
        ProfileViewModel GetUserProfileById(int id);
        Task CreateUser(string identity);
        void EditUserProfile(string userIdentity, ProfileViewModel profile);
        List<UserSearchViewModel> SearchUsers(string userQuery);
    }
}
