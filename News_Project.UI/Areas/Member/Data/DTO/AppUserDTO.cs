using News_Project.Entity.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Member.Data.DTO
{
    public class AppUserDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }

        public string ImagePath { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; } //Görüntüyü küçültmek için
        public string CruptedUserImage { get; set; }
    }
}