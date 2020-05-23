using News_Project.Entity.Entities;
using News_Project.Entity.Entities.Enums;
using News_Project.Service.Repository;
using News_Project.UI.Areas.Admin.Data.DTO;
using News_Project.UI.Areas.Admin.Data.VM;
using News_Project.Utility.ImagePocessesing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News_Project.UI.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        //Post gönderilebilmesi için aşağıdakilere ihtiyacım var
        PostRepository _postRepository;
        CategoryRepository _categoryRepository;
        AppUserRepository _appUserRepository;
        public PostController()
        {
            _postRepository = new PostRepository();
            _categoryRepository = new CategoryRepository(); //Category Id'sine ihtiyacım var
            _appUserRepository = new AppUserRepository();  //User Id 'sine ihtiyacım var 
        }
        public ActionResult Create()
        {
            //Normalde CategoryControllerde Get ettiğimiz Create() Metodundaki ActionResult'ta herhangi bir veri girişi yapmamıştık çünkü sadece boş bir ekran getirtmak istiyorduk oysaki PostControllerın Get kısmında Create() metodundaki ActionResultta bir veri girişi var oda ekran düşer düşmez AppUser ve Category sınıfındakilerin isimlerinin dolmasını istiyoruz yani DM'den veri getirtme işlemi var oyüzden burada bir operasyon var.Bu verileride toplu model olusturdugumuz CreatePostVM sınıfından çoklu model taşıma işlemini gerçekleştiririz.
            //Post'ta çoklu model taşıma işlemini gerçekleştirmiş oluyoruz.
           
            CreatePostVM model = new CreatePostVM()  //Genişleterek New'ledik 
            {
                Categories = _categoryRepository.GetActive(),
                AppUsers=_appUserRepository.GetDefault(x=>x.Role !=Role.Member) //Member olan post(news) atamayacagından bu metod kullanılır yani member dısındakileri post atabilecek kişileri(Author ve admin)  aksi halde GetActive() metodunu kullansaydık o zamn member olanlarda kafasına göre haber yayınlardı.
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(Post model,HttpPostedFileBase Image)
        {

            List<string> UploadImagePaths = new List<string>();

            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            model.ImagePath = UploadImagePaths[0];

            if (model.ImagePath == "0" || model.ImagePath == "1" || model.ImagePath == "2")
            {
                model.ImagePath = ImageUploader.DefaultProfileImagePath;
                model.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                model.ImagePath = ImageUploader.DefaulCruptedProfileImage;
            }
            else
            {
                model.ImagePath = UploadImagePaths[1];
                model.ImagePath = UploadImagePaths[2];
            }

            model.PublishDate = DateTime.Now;

            _postRepository.Add(model);
            return Redirect("/Admin/Post/List");
        }
        public ActionResult List()
        {
            List<Post> model = _postRepository.GetActive();
            return View(model);
        }
        public ActionResult Detail(int id)
        {
            Post post = _postRepository.GetById(id);
            return View(post);
        }
        [HttpGet]
        public ActionResult Update (int id)
        {

            //Bu aşamada öncelikle Post Classımdan yeni bir sınıf yaratıp _postRepository'nin GetById() metodu ile update etmek istediğim Post'u yakalayıp örneklem aldıgım ve adı post olan classıma atarım. 
            Post post = _postRepository.GetById(id);
            //Burada normalde tek model oldugunda UpdateDTO dediğim clasın örneğinden yararlanıp onun üzernden yeni oluşturdugum modeli taşırdım ancak toplu model devreye girdiğinde olsturdugum VM Classından örneklem alıp onun üzerinden modele ulaşırım. Modelede UpdatePostModel içerinde olusturmus oldugum PostDTO'nun clasından yine kedni isminden oluşturduğum PostDTO üzerinden ulaşırım.
            UpdatePostVM model = new UpdatePostVM();
            model.PostDTO.Id = post.Id;
            model.PostDTO.Header = post.Header;
            model.PostDTO.Content = post.Content;
            model.PostDTO.PublishDate = post.PublishDate;
            model.PostDTO.ImagePath = post.ImagePath;
            List<Category> categories = _categoryRepository.GetActive(); //Category sınıfından yeni bir sınıf olusturup PostModelDTO'class'ında oluşturmuş oldugugum Liste seklindeki Category sınıfına aktarırız.
            model.Categories = categories;
            List<AppUser> appUsers =_appUserRepository.GetActive();
            model.AppUsers = appUsers;
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Post model,HttpPostedFileBase Image)
        {
            List<string> UploadImagePaths = new List<string>();

            UploadImagePaths = ImageUploader.UploadSingleImage(ImageUploader.OriginalProfileImagePath, Image, 1);

            model.ImagePath = UploadImagePaths[0];

            Post post = _postRepository.GetById(model.Id);

            if (model.ImagePath == "0" || model.ImagePath == "1" || model.ImagePath == "2")
            {
                if (post.ImagePath == null || post.ImagePath == ImageUploader.DefaultProfileImagePath)
                {
                    post.ImagePath = ImageUploader.DefaultProfileImagePath;
                    post.ImagePath = ImageUploader.DefaultXSmallProfileImage;
                    post.ImagePath = ImageUploader.DefaulCruptedProfileImage;
                }
                else
                {
                    post.ImagePath = post.ImagePath;
                }
            }
            else
            {
                model.ImagePath = UploadImagePaths[1];
                model.ImagePath = UploadImagePaths[2];
            }

            //Bu defa yukarıda yaptıgım işlemin tam tersini yapıyoruz değiştirdiğimiz modeli db'ye aktarıyoruz _postRepository'nin Update() Metodu saayesinde.

            post.Header = model.Header;
            post.Content = model.Content;
            post.PublishDate = DateTime.Now;
            post.Status = Status.Modified;
            post.UpdateDate = DateTime.Now;
            post.CategoryId = model.CategoryId;
            post.AppUserId = model.AppUserId;
            _postRepository.Update(post);
            return Redirect("/Admin/Post/List");
        }
        public ActionResult Delete(int id)
        {
            _postRepository.Remove(id);
            return Redirect("/Admin/Post/List");
        }

    }
}