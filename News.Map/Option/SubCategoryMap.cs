using News.Core.Map;
using News.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Map.Option
{
    public class SubCategoryMap : CoreMap<SubCategory>
    {
        public SubCategoryMap()
        {
            ToTable("dbo.SubCategories");

            Property(x => x.Name).IsOptional();
            Property(x => x.Description).IsOptional();

            HasRequired(x => x.Category)
                .WithMany(x => x.SubCategories)
                .HasForeignKey(x => x.CategoryID)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Articles)
                .WithRequired(x => x.SubCategory)
                .HasForeignKey(x => x.SubCategoryID)
                .WillCascadeOnDelete(false);
        }
    }
}
