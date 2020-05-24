using News_Project.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Member.Data.VM
{
    public class HomePageVM
    {
        public HomePageVM()
        {
            Posts = new List<Post>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }
    }
}