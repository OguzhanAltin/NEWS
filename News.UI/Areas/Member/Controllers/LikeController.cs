﻿using News.Model.Option;
using News.Service.Option;
using News.UI.Areas.Member.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.UI.Areas.Member.Controllers
{
    public class LikeController : Controller
    {
        AppUserService _appUserService;
        LikeService _likeService;
        CommentService _commentService;

        public LikeController()
        {
            _appUserService = new AppUserService();
            _likeService = new LikeService();
            _commentService = new CommentService();
        }

        public JsonResult AddLike(Guid id)
        {
            JsonLikeVM jr = new JsonLikeVM();
            Guid appUserID = _appUserService.FindByUserName(HttpContext.User.Identity.Name).ID;

            if (!(_likeService.Any(x => x.AppUserID == appUserID && x.ArticleID == id)))
            {
                Like like = new Like();
                like.ArticleID = id;
                like.AppUserID = appUserID;

                _likeService.Add(like);

                jr.Likes = _likeService.GetDefault(x => x.ArticleID == id).Count();

                jr.userMessage = "likes it";
                jr.isSuccess = true;

                jr.Likes = _likeService.GetDefault(x => x.ArticleID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count();
                jr.Comments = _commentService.GetDefault(x => x.ArticleID == id && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count();

                return Json(jr, JsonRequestBehavior.AllowGet);
            }

            else
            {
                jr.isSuccess = false;
                jr.userMessage = "You've liked this article before!";

                return Json(jr, JsonRequestBehavior.AllowGet);
            }
        }
    }
}