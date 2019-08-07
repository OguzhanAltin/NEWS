using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.UI.Areas.Author.Models.DTO
{
    public class ArticleDTO
    {
        public Guid ID { get; set; }
        public Guid CategoryID { get; set; }
        public Guid SubCategoryID { get; set; }
        public Guid AppUserID { get; set; }
        public DateTime? PublishDate { get; set; }

        public string Header { get; set; }
        public string Content { get; set; }
        public string ImagePath { get; set; }
    }
}