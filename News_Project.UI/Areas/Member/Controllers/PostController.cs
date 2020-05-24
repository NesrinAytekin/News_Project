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
    public class PostController : Controller
    {
        PostRepository _postRepository;
        AppUserRepository _appUserRepository;
        CommentRepository _commentRepository;
        LikeRepository _likeRepository;
        public PostController()
        {
            _postRepository = new PostRepository();
            _appUserRepository = new AppUserRepository();
            _commentRepository = new CommentRepository();
            _likeRepository = new LikeRepository();

        }
        // GET: Member/Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PostDetails(int id)
        {
            //Post post = _postRepository.GetById(id);
            PostDetailVM model = new PostDetailVM();
            //model.PostDTO.Id = post.Id;
            //model.AppUserDTO.Id = _appUserRepository.GetById(model.PostDTO.AppUserId);

            model.Post = _postRepository.GetById(id); //Önce Postu Id'sinden yakalarım
            model.AppUser = _appUserRepository.GetById(model.Post.AppUser.Id); //Daha Sonra Bu Postu hangi AppUser atmış onu bulmak içim Id'leri eşitlerim

            model.Comments = _commentRepository.GetDefault(x => x.PostId == id && x.Status != Status.Passive);
            model.CommentCount = _commentRepository.GetDefault(x => x.PostId == id && x.Status != Status.Passive).Count;

            model.Likes = _likeRepository.GetDefault(x => x.PostId == id && x.Status != Status.Passive);
            model.LikeCount = _likeRepository.GetDefault(x => x.PostId == id && x.Status != Status.Passive).Count;

            return View(model);
        }
    }
}