using SocialNetwork.DAL;
using System;
using System.Linq;
using System.Text;

namespace SocialNetwork.BL
{
    public class UserManager
    {
        private readonly IRepository<DAL.UserProfile> _profileRepo = Repository<DAL.UserProfile>.Instance;
        private readonly IRepository<DAL.User> _userRepo = Repository<DAL.User>.Instance;

        public UserProfile GetUserProfileByName(string userIdentity)
        {
            var user = _userRepo.Entities.Single(x => x.AppAuthId == userIdentity);

            if (user.ProfileId == null)
            {
                return null;
            }

            return new UserProfile(GetProfileById((int)user.ProfileId));
        }

        public void EditUserProfile(string userIdentity, UserProfile profile)
        {
            var user = _userRepo.Entities.Single(x => x.AppAuthId == userIdentity);


            if (user.ProfileId == null)
            {
                user.Profile = new DAL.UserProfile()
                {
                    About = profile.About,
                    DateOfBirth = profile.DateOfBirth,
                    Name = profile.Name,
                    Photo = Convert.FromBase64String(profile.Photo),
                    Surname = profile.Surname
                };

                _userRepo.Update(user);
            }
            else
            {
                var exsistingProfile = GetProfileById((int)user.ProfileId);

                exsistingProfile.About = profile.About;
                exsistingProfile.DateOfBirth = profile.DateOfBirth;
                exsistingProfile.Name = profile.Name;
                exsistingProfile.Photo = Convert.FromBase64String(profile.Photo);
                exsistingProfile.Surname = profile.Surname;

                _profileRepo.Update(exsistingProfile);
            }
        }

        public void CreateUser(string userIdentity)
        {
            _userRepo.Create(new User { AppAuthId = userIdentity });
        }

        public UserProfile GetUserProfileById(int id)
        {
            var profileId = _userRepo.Entities.SingleOrDefault(x => x.Id == id)?.ProfileId;

            if (profileId == null)
            {
                return null;
            }

            return new UserProfile(GetProfileById((int)profileId));
        }

        private DAL.UserProfile GetProfileById(int id)
        {
            return _profileRepo.Entities.Single(x => x.Id == id);
        }
    }
}
