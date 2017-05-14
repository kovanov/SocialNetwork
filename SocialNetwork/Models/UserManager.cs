using System;
using System.Threading.Tasks;
using System.Web;

namespace SocialNetwork.Models
{
    public class UserManager : IUserManager
    {
        private readonly BL.UserManager _manager = new BL.UserManager();

        public void EditUserProfile(string userIdentity, ProfileViewModel profile)
        {
            var blProfile = new BL.UserProfile()
            {
                About = profile.About,
                DateOfBirth = profile.DateOfBirth,
                Name = profile.Name,
                Photo = profile.PhotoBase64,
                Surname = profile.Surname
            };

            _manager.EditUserProfile(userIdentity, blProfile);
        }

        public Task CreateUser(string identity)
        {
            return Task.Run(() => _manager.CreateUser(identity));
        }

        public ProfileViewModel GetProfileByUserIdentityName(string name)
        {
            var profile = _manager.GetUserProfileByName(name);

            return profile == null ? null : new ProfileViewModel
            {
                About = profile.About,
                DateOfBirth = profile.DateOfBirth,
                Name = profile.Name,
                PhotoBase64 = profile.Photo,
                Surname = profile.Surname
            };
        }

        public ProfileViewModel GetUserProfileById(int id)
        {
            var profile = _manager.GetUserProfileById(id);

            return profile == null ? null : new ProfileViewModel
            {
                About = profile.About,
                DateOfBirth = profile.DateOfBirth,
                Name = profile.Name,
                PhotoBase64 = profile.Photo,
                Surname = profile.Surname
            };
        }
    }
}
