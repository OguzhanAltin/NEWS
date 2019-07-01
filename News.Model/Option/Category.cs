﻿using News.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model.Option
{
    public class Category : CoreEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }
    }
}
