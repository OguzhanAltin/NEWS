﻿using News.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Model.Option
{
    public enum Gender
    {
        None = 0,
        Male = 1,
        Female = 2
    }

    public enum Role
    {
        None = 0,
        Admin = 1,
        Author = 2,
        Member = 3
    }

    public class AppUser : CoreEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string ImagePath { get; set; }
        public string UserImage { get; set; }
        public string XSmallUserImage { get; set; }
        public string CruptedUserImage { get; set; }

        public Role Role { get; set; }
        public Gender Gender { get; set; }

        public virtual List<Article> Articles { get; set; }
        public virtual List<Like> Likes { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}