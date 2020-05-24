using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Member.Data.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int PostId { get; set; }
        public int AppUserId { get; set; }

    }
}