using News_Project.Entity.Entities;
using News_Project.Entity.Entities.Enums;
using News_Project.Service.Repository;
using News_Project.UI.Areas.Member.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News_Project.UI.Areas.Member.Controllers
{
    public class LikeController : Controller
    {
        AppUserRepository _appUserRepository;
        LikeRepository _likeRepository;
        CommentRepository _commentRepository;
        public LikeController()
        {
            _appUserRepository = new AppUserRepository();
            _likeRepository = new LikeRepository();
            _commentRepository = new CommentRepository();
        }
        // GET: Member/Like
        public JsonResult AddLike(int id)
        {
            JsonLikeVM jr = new JsonLikeVM();
            int appUserId = _appUserRepository.FindByUserName(HttpContext.User.Identity.Name).Id;

            if (!(_likeRepository.Any(x => x.AppUserId == appUserId)))
            {
                Like like = new Like();
                like.AppUserId = appUserId;
                like.PostId = id;
                _likeRepository.Add(like);

                jr.Likes = _likeRepository.GetDefault(x => x.PostId == id && x.Status != Status.Passive).Count();
                jr.userMessage = "Like İt";
                jr.isSuccess = true;
                jr.Comments = _commentRepository.GetDefault(x => x.PostId == id && x.Status != Status.Passive).Count();

                return Json(jr, JsonRequestBehavior.AllowGet);


            }
            else
            {
                jr.isSuccess = false;
                jr.userMessage = "You Have Been Liked this post";
                return Json(jr, JsonRequestBehavior.AllowGet);
            }


        }
    }
}