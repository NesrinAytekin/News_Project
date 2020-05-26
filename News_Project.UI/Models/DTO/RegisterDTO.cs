using News_Project.Entity.Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Project.UI.Models.DTO
{
    public class RegisterDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Type this area is required")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Type this area is required")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "Type this area is required")]
        [MinLength(2, ErrorMessage = "Minimum lenght is 2")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Type this area is required")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Password { get; set; }


        public Role Role { get; set; }
        public Gender Gender { get; set; }
        public string ImagePath { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; } //Görüntüyü küçültmek için
        public string CruptedUserImage { get; set; }
    }
}