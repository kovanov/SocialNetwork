using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SocialNetwork.Models;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserManager _userManager;

        public ApplicationUserManager AppUserManager
        {
            get { return HttpContext.GetOwinContext().Get<ApplicationUserManager>(); }
        }

        public ProfileController(IUserManager manager)
        {
            _userManager = manager;
        }

        public ActionResult UserProfile(int? id)
        {
            if (id == null || id.Value == 0)
            {
                var profile = _userManager.GetProfileByUserIdentityName(User.Identity.Name);

                return profile == null ? View("NoSelfProfile") : View(profile);
            }
            else
            {
                var profile = _userManager.GetUserProfileById(id.Value);

                if (profile == null)
                {
                    return View("NoProfile");
                }
                else
                {
                    return View(profile);
                }
            }
        }

        public ActionResult Edit()
        {
            var profile = _userManager.GetProfileByUserIdentityName(User.Identity.Name);

            ViewBag.Profile = profile;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(ProfileViewModel model, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                if (photo != null)
                {
                    var stream = new MemoryStream();
                    photo.InputStream.CopyTo(stream);
                    model.PhotoBase64 = Convert.ToBase64String(stream.ToArray());
                }
                else
                {
                    model.PhotoBase64 = WebConfigurationManager.AppSettings["DefaultProfilePhotoBase64"];
                }

                _userManager.EditUserProfile(User.Identity.Name, model);

                return RedirectToAction("UserProfile");
            }

            return View(model);
        }

        public ActionResult Users(string userQuery = null)
        {
            if (string.IsNullOrEmpty(userQuery))
            {
                return View();
            }

            var users = _userManager.SearchUsers(userQuery.ToLower());

            foreach (var user in users)
            {
                var appUser = AppUserManager.Users.Single(x => x.UserName == user.Login);
                user.Role = AppUserManager.GetRoles(appUser.Id).First();
            }

            return View(users);
        }

        [HttpPost]
        [Roles(Role.Admin)]
        public ActionResult ChangeRole(string userLogin, string oldRole, string newRole)
        {
            TempData["Result"] = "Ошибка, обратитесь к администратору";

            var appUser = AppUserManager.Users.SingleOrDefault(x => x.UserName == userLogin);
            if (appUser != null)
            {
                if (AppUserManager.IsInRole(appUser.Id, oldRole) && RolesAttribute.RoleExsist(newRole))
                {
                    AppUserManager.RemoveFromRole(appUser.Id, oldRole);
                    AppUserManager.AddToRole(appUser.Id, newRole);

                    TempData["Result"] = "Роль успешно изменена";
                }
            }

            return View("Users");
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class RolesAttribute : AuthorizeAttribute
    {
        static RolesAttribute()
        {
            _roles = Enum.GetValues(typeof(Role)).OfType<Role>().ToArray();
        }

        public RolesAttribute(Role roleFlags) : base()
        {
            Roles = string.Join(",", (from x in _roles where (x & roleFlags) != 0 select x.ToString()));
        }

        private static Role[] _roles;

        public const string User = "User";
        public const string Moderator = "Moderator";
        public const string Admin = "Admin";

        public static bool RoleExsist(string role)
        {
            return _roles.Where(x => x < Role.All).Any(x => x.ToString() == role);
        }
    }

    public enum Role
    {
        User = 0x1,
        Moderator = 0x2,
        Admin = 0x4,
        All = 0xf
    }
}
