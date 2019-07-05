using News.Model.Option;
using News.Service.Option;
using News.UI.Areas.Admin.Models.DTO;
using News.Utility.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.UI.Areas.Admin.Controllers
{
    public class AppUserController : Controller
    {
        AppUserService _appUserService;

        public AppUserController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AppUser data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {
                data.UserImage = ImageUploader.DefaultProfileImagePath;
                data.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                data.CruptedUserImage = ImageUploader.DefaultCruptedProfileImage;
            }

            else
            {
                data.XSmallUserImage = UploadedImagePaths[1];
                data.CruptedUserImage = UploadedImagePaths[2];
            }

            data.Status = Core.Enum.Status.Active;

            _appUserService.Add(data);

            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult List()
        {
            List<AppUser> model = _appUserService.GetActive();

            return View(model);
        }

        public ActionResult Update(Guid id)
        {
            AppUser user = _appUserService.GetByID(id);

            AppUserDTO model = new AppUserDTO();

            model.ID = user.ID;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.UserName = user.UserName;
            model.Email = user.Email;
            model.Password = user.Password;
            model.UserImage = user.UserImage;
            model.XSmallUserImage = user.XSmallUserImage;
            model.CruptedUserImage = user.CruptedUserImage;
            model.Gender = user.Gender;
            model.Role = user.Role;

            return View(model);
        }

        [HttpPost]
        public ActionResult Update(AppUserDTO data, HttpPostedFileBase Image)
        {
            List<string> UploadedImagePaths = new List<string>();

            UploadedImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            data.UserImage = UploadedImagePaths[0];


            AppUser user = _appUserService.GetByID(data.ID);

            if (data.UserImage == "0" || data.UserImage == "1" || data.UserImage == "2")
            {

                if (user.UserImage == null || user.UserImage == ImageUploader.DefaultProfileImagePath)
                {
                    user.UserImage = ImageUploader.DefaultProfileImagePath;
                    user.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                    user.CruptedUserImage = ImageUploader.DefaultCruptedProfileImage;
                }
                else
                {
                    user.UserImage = user.UserImage;
                    user.XSmallUserImage = user.XSmallUserImage;
                    user.CruptedUserImage = user.CruptedUserImage;
                }

            }
            else
            {
                user.UserImage = UploadedImagePaths[0];
                user.XSmallUserImage = UploadedImagePaths[1];
                user.CruptedUserImage = UploadedImagePaths[2];
            }

            user.FirstName = data.FirstName;
            user.LastName = data.LastName;
            user.UserName = data.UserName;
            user.Email = data.Email;
            user.Password = data.Password;
            user.ImagePath = data.ImagePath;
            user.Gender = data.Gender;
            user.Role = data.Role;

            _appUserService.Update(user);

            return Redirect("/Admin/AppUser/List");
        }

        public ActionResult Delete(Guid id)
        {
            _appUserService.Remove(id);

            return Redirect("/Admin/AppUser/List");
        }
    }
}