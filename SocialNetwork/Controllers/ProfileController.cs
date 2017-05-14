using SocialNetwork.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace SocialNetwork.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly IUserManager _userManager;
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
                    return RedirectToAction("UserProfile", new { id = 0 });
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
                var photoBytes = new byte[0];
                if (photo != null)
                {
                    var stream = new MemoryStream();
                    photo.InputStream.CopyTo(stream);
                    photoBytes = stream.ToArray();
                }

                model.PhotoBase64 = Convert.ToBase64String(photoBytes);
                _userManager.EditUserProfile(User.Identity.Name, model);

                return RedirectToAction("UserProfile");
            }
            
            return View(model);
        }
    }
}
