using News_Project.Entity.Entities;
using News_Project.Entity.Entities.Enums;
using News_Project.Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News_Project.UI.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        CommentRepository _commentRepository;
        AppUserRepository _appUserRepository;
        LikeRepository _likeRepository;
        PostRepository _postRepository;

        public CommentController()
        {
        _commentRepository = new CommentRepository();
        _appUserRepository = new AppUserRepository();
        _likeRepository = new LikeRepository();
        _postRepository = new PostRepository();
        }
        // GET: Member/Comment

        //JsonResult kullanmamızın sebebi sayfanın post back olup sürekli servera gidip gelme işlemini yapmasın diye Javascrip zaten bu işlemi yapıyorJavascript dbye post etmeden gönderiyor veriyor
        public JsonResult AddComment(string userComment,int id) //Json ile yeni comment oluşturma yani ekleme
        {
            Comment comment = new Comment();
            comment.AppUserId = _appUserRepository.FindByUserName(HttpContext.User.Identity.Name).Id;
            comment.PostId = id;
            comment.Content = userComment;

            bool isAdded = false; //bool tipinde isAdded değişkeni tanımlayıp başlangıç değerini false olarak verdik.
            try
            {
                _commentRepository.Add(comment);
                isAdded = true;
            }
            catch (Exception)
            {
                isAdded = false;
            }

            return Json(isAdded, JsonRequestBehavior.AllowGet); 

        }
       
        public JsonResult GetPostComment(int postId) //PostId'den yakalancağı için int tipinde postid tanımlanır.
        {
            //Aşağıda ilgili postun yani seçilen postun tüm commentlerini getirmiş olduk.
            Comment comment = _commentRepository.GetDefault(x => x.PostId == postId && x.Status != Status.Passive).LastOrDefault();

            return Json(new
            {
                AppUserImagePath = comment.AppUser.UserImage,
                UserName = comment.AppUser.UserName,
                CreateDate = comment.CreateDate.ToShortDateString(),
                Content = comment.Content,
                CommentCount = _commentRepository.GetDefault(x => x.PostId == postId && x.Status != Status.Passive).Count,
                LikeCount = _likeRepository.GetDefault(x => x.PostId == postId && x.Status != Status.Passive).Count,
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult DeleteComment(int id)
        {
            int userId = _appUserRepository.FindByUserName(HttpContext.User.Identity.Name).Id;
            Comment comment = _commentRepository.GetById(id);
            bool isDelete = false;
            if (comment.AppUserId==userId)
            {
                isDelete = true;
                _commentRepository.Remove(id);
                return Json(isDelete, JsonRequestBehavior.AllowGet);

                //bool tipinde bir alan tanımlamamın sebebi tamamen Json yanında 2 parametre istediği için kurtarıcı olrak bir alan tanımladım back end'e bir etkisi yok.
            }
            else
            {
                isDelete = false;
                return Json(isDelete, JsonRequestBehavior.AllowGet);
            }
        }
    }
}