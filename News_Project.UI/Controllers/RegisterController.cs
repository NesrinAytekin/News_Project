using News_Project.Entity.Entities;
using News_Project.Entity.Entities.Enums;
using News_Project.Service.Repository;
using News_Project.UI.Models.DTO;
using News_Project.Utility.ImagePocessesing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News_Project.UI.Controllers
{
    public class RegisterController : Controller
    {
        AppUserRepository _appUserRepository;
        public RegisterController()
        {
            _appUserRepository = new AppUserRepository();
        }
        // GET: Register
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RegisterDTO model, HttpPostedFileBase Image)
        {
            
            if (ModelState.IsValid)
            {
                List<string> UploadImagePaths = new List<string>();
                UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);
                model.UserImage = UploadImagePaths[0];
                if (model.UserImage == "0" || model.UserImage == "1" | model.UserImage == "2")
                {
                    model.UserImage = ImageUploader.DefaultProfileImagePath;
                    model.XSmallUserImage = ImageUploader.DefaultXSmallProfileImage;
                    model.CruptedUserImage = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    model.XSmallUserImage = UploadImagePaths[1];
                    model.CruptedUserImage = UploadImagePaths[2];
                }
                AppUser appUser = new AppUser();
                appUser.Id = model.Id;
                appUser.FirstName = model.FirstName;
                appUser.LastName = model.LastName;
                appUser.UserName = model.UserName;
                appUser.Password = model.Password;
                appUser.Gender = model.Gender;
                appUser.Role = Role.Member;
                appUser.UserImage = model.UserImage;
                appUser.XSmallUserImage = model.XSmallUserImage;
                appUser.CruptedUserImage = model.CruptedUserImage;
                _appUserRepository.Add(appUser);
                return Redirect("/Member/Home/Index");//Member home page yönlendirilecek
            }
            else
            {
                return View(model);
            }
        }

    }
}