using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Member.Data.DTO
{
    public class LikeDTO
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int AppUserId { get; set; }

    }
}