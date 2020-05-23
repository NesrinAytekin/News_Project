using News_Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Admin.Data.VM
{
    public class CreatePostVM //VM=View Model:Modelleri Görüntüle Demek
    {
        public CreatePostVM()
        {
            Categories = new List<Category>(); //Category'sına liste çekmemiz lazm combox'lara getirebilmem için
            AppUsers = new List<AppUser>();//AppUsers'ına liste çekmemiz lazm combox'lara getirebilmem için

        }
        //Post gönderebilmem için gerekli herseyi tek model üzerinden taşımıs olacagım böylece.
        //Böylece tek bir model olusturarak o model üzerinden taşıma işlemini yapmış oluyoruz BU Classla bu sınıfı model olarak view de gösterip işlem yapabiliriz.
        //Çokulu liste oldugu için Liste Çektik Tek olsaydı o class'ın tipinde property ekleriz
        //örnek:Public class AppUser AppUser{ get; set; } ...vb.
        public List<Category> Categories { get; set; } 
        public List<AppUser> AppUsers { get; set; }

    }
}