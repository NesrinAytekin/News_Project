using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Admin.Data.DTO
{
    public class PostDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Type this area is required")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Header { get; set; }
        [Required(ErrorMessage = "Type this area is required")]
        [MinLength(3, ErrorMessage = "Minimum lenght is 3")]
        public string Content { get; set; }
        public string ImagePath { get; set; }
        public DateTime? PublishDate { get; set; }
        public int CategoryId { get; set; }
        public int AppUserId { get; set; }





    }
}