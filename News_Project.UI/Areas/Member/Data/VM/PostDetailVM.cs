using News_Project.Entity.Entities;
using News_Project.UI.Areas.Member.Data.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News_Project.UI.Areas.Member.Data.VM
{
    public class PostDetailVM
    {
        public PostDetailVM()
        {
            AppUsers = new List<AppUser>();
            Posts = new List<Post>();
            Comments = new List<Comment>();
            Likes = new List<Like>();
        }
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

        public List<AppUser> AppUsers { get; set; }
        public List<Post> Posts { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

        //public AppUserDTO AppUserDTO { get; set; }
        //public CommentDTO CommentDTO { get; set; }
        //public LikeDTO LikeDTO { get; set; }
        //public PostDTO PostDTO { get; set; }

        public Like Like { get; set; }
        public Post Post { get; set; }
        public AppUser AppUser { get; set; }
        public Comment Comment { get; set; }


    }
}