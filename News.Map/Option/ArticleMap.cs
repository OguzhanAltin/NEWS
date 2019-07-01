using News.Core.Map;
using News.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Map.Option
{
    public class ArticleMap : CoreMap<Article>
    {
        public ArticleMap()
        {
            ToTable("dbo.Articles");

            Property(x => x.Header).IsOptional();
            Property(x => x.Content).IsOptional();
            Property(x => x.ImagePath).IsOptional();
            Property(x => x.PublishDate).IsOptional();

            HasRequired(x => x.AppUser)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.AppUserID)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.SubCategory)
                .WithMany(x => x.Articles)
                .HasForeignKey(x => x.SubCategoryID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Likes)
                .WithRequired(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Article)
                .HasForeignKey(x => x.ArticleID)
                .WillCascadeOnDelete(false);
        }
    }
}
