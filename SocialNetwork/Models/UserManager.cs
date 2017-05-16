using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

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

        public List<UserSearchViewModel> SearchUsers(string userQuery)
        {
            var userInfos = _manager.Search(userQuery);

            return userInfos.Select(x => new UserSearchViewModel
            {
                Id = x.Id,
                Login = x.Login,
                Name = x.Name,
                PhotoBase64 = string.IsNullOrEmpty(x.PhotoBase64) ? WebConfigurationManager.AppSettings["DefaultProfilePhotoBase64"] : x.PhotoBase64,
                Surname = x.Surname
            }).ToList();
        }
    }
}
