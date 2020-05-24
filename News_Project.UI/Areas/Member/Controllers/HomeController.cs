using News_Project.Service.Repository;
using News_Project.UI.Areas.Member.Data.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News_Project.UI.Areas.Member.Controllers
{
    public class HomeController : Controller
    {

        PostRepository _postRepository;
        CommentRepository _commentRepository;
        LikeRepository _likeRepository;
        public HomeController()
        {
            //AppUser instance almadık çünkü sadece postu getir diyoruz. Postu paylaşan kişiye zaten PostDTO'dan ulaşabibiliriz LazyLoadingle virtual olaraak AppUser Tanımlanmıştı.
            _postRepository = new PostRepository();
            _commentRepository = new CommentRepository();
            _likeRepository = new LikeRepository();
        }
        // GET: Member/Home
        public ActionResult Index()
        {
           HomePageVM model = new HomePageVM();
            model.Posts = _postRepository.GetActive();
            foreach (var item in model.Posts)
            {
                //modelime commentlerin postıd'si itemİd'ye eşitle yani yakala buradan ve eklenme tarihi sondan başa doğru sırala taka(10) diyerek yani ilk 10 postu home ekranında listele diyoruz.
                model.Comments = _commentRepository.GetDefault(x => x.PostId == item.Id).OrderByDescending(x => x.CreateDate).Take(10).ToList();

                model.CommentCount = _commentRepository.GetDefault(x => x.PostId == item.Id).Count;
                model.LikeCount = _likeRepository.GetDefault(x => x.PostId == item.Id).Count;

            }
            return View(model);
        }
    }
}