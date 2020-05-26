using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Project.UI.Models.DTO
{
    public class LoginDTO //LoginDTO oluşturmamın sebebi login yaparken ihtiyacım olan propertyleri getirmek için aksi halde tüm veriler gelmek zorunda kalırdı.
    {
        [Required(ErrorMessage = "User name is wrong..!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is wrong..!")]
        public string Password { get; set; }
    }
}