﻿using News.Model.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace News.UI.Areas.Author.Models.VM
{
    public class AddArticleVM
    {
        public AddArticleVM()
        {
            Categories = new List<Category>();
            SubCategories = new List<SubCategory>();
        }

        public List<Category> Categories { get; set; }
        public List<SubCategory> SubCategories { get; set; }
    }
}