using News.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.UI.Areas.Member.Models.VM
{
    public class ArticleDetailVM
    {
        public ArticleDetailVM()
        {
            AppUsers = new List<AppUser>();
            Articles = new List<Article>();
            Comments = new List<Comment>();
            Likes = new List<Like>();

            AppUser = new AppUser();
            Article = new Article();
            Comment = new Comment();
            Like = new Like();
        }

        public int LikeCount { get; set; }
        public int CommentCount { get; set; }

        public List<AppUser> AppUsers { get; set; }
        public List<Article> Articles { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

        public AppUser AppUser { get; set; }
        public Article Article { get; set; }
        public Comment Comment { get; set; }
        public Like Like { get; set; }
    }
}