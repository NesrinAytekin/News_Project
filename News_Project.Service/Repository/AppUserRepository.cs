using News_Project.Entity.Entities;
using News_Project.Service.BaseRepository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Project.Service.Repository
{
    public class AppUserRepository:CoreRepository <AppUser>
    {
        //Direk AppUser'ı ilgilendiren bir metod oldugu için ortak alana değilde yani ICoreRepository'e değil AppUserRepository'e yazıyorum.Bu Metodu
        public AppUser FindByUserName(string userName)
        {
            return GetByDefault(x => x.UserName == userName);

            //Neden GetByDefault() metodunu kullandım ama GetDefault() Metodunu kullanmadım sorusuna gelince sebebi ben sonucun true or false dönmesini istiyorum böyle bir id var mı yok mu onu öğrenmek istiyorum çünkü.           
        }
        //Aşağıdaki metodla member login oldugunda username ve password'u check ettiğimde kullanacağım metod
        //Credential:Login Olacağı bilgilere Credential(Kimlik Bilgileri bir nevi) denir.
        public bool CheckCredentials(string userName, string password)
        {
            return Any(x => x.UserName == userName && x.Password == password);//Username ve password'ü eşleştirip ona göre db de bu kullanıcı bilgisi varsa login işlemi gerçekleşecek.
        }
    }
}
