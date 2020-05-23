using News_Project.Entity.Entities;
using News_Project.UI.Areas.Admin.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Admin.Data.VM
{
    public class UpdatePostVM
    {
        public UpdatePostVM()
        {
            //Bu Vm Sınıfını açmamızın sebebi CategoryDTO ile çoklu model taşıma işlemini MVC Pattern gereği gerçekleştiremiyor olmamdan kaynaklıdır. UpdatePostVM sayesinde birden fazla modeli tek başına taşıyarak işlem yapabilirim.
            //Her  Postun bağlı oldugu bir categori ve bir user'ı olması gerektiğinden ve Post modelinide PostDTO üzerinden taşıdıgımdan bu 3 sınıfı newlerim yapıcı metod üzerinden.

            Categories = new List<Category>(); //Bunlar liste şeklinde olmasının sebebi comboboxlara girdiricez.
            AppUsers = new List<AppUser>();//Bunlar liste şeklinde olmasının sebebi comboboxlara girdiricez
            PostDTO = new PostDTO(); //Liste olarak göstermedik categori ve appuser gibi tekil bir post yani article getiritorum.
        }

        public List<Category>Categories  { get; set; } //Bunlar liste şeklinde olmasının sebebi comboboxlara girdiricez
        public List<AppUser> AppUsers { get; set; }//Bunlar liste şeklinde olmasının sebebi comboboxlara girdiricez
        public PostDTO PostDTO { get; set; }//Tek bir Post için burada Update işlemi gereçekleşeceği için tekil oluyor.
        //Bu kısımda PostDTO girişi yapmasaydım tek tek postId , Content, Header diye yazmmam gerekir PostDTO'dan çekerek buna ihtiyaç kalmıyor.
    }
}