﻿
using News_Project.Entity.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News_Project.Entity.Entities
{
   
    public class AppUser:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public Gender Gender { get; set; }


        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

        public string ImagePath { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; } //Görüntüyü küçültmek için
        public string CruptedUserImage { get; set; }

    }
}
