using System;
using SocialNetwork.DAL;

namespace SocialNetwork.BL
{
    public class UserProfile
    {
        public UserProfile() { }

        public UserProfile(DAL.UserProfile profile)
        {
            Name = profile.Name;
            Surname = profile.Surname;
            About = profile.About;
            DateOfBirth = profile.DateOfBirth;
            Photo = Convert.ToBase64String(profile.Photo);
        }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string About { get; set; }
        public string Photo { get; set; }
    }
}
