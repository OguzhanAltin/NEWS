﻿using News.Model.Option;
using News.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.UI.Areas.Member.Controllers
{
    public class CommentController : Controller
    {
        CommentService _commentService;
        AppUserService _appUserService;
        LikeService _likeService;
        ArticleService _articleService;

        public CommentController()
        {
            _appUserService = new AppUserService();
            _articleService = new ArticleService();
            _commentService = new CommentService();
            _likeService = new LikeService();
        }

        public JsonResult AddComment(string userComment, Guid id)
        {

            Comment comment = new Comment();

            comment.AppUserID = _appUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            comment.ArticleID = id;
            comment.Content = userComment;

            bool isAdded = false;

            try
            {
                _commentService.Add(comment);

                isAdded = true;
            }

            catch (Exception)
            {
               isAdded = false;
            }

            return Json(isAdded, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetArticleComment(string id)
        {
            Guid articleID = new Guid(id);


            Comment comment = _commentService.GetDefault(x => x.ArticleID == articleID && x.Status == Core.Enum.Status.Active).LastOrDefault();

            return Json(new
            {
                AppUserImagePath = comment.AppUser.UserImage,
                FirstName = comment.AppUser.FirstName,
                LastName = comment.AppUser.LastName,
                CreatedDate = comment.CreatedDate.ToString(),
                Content = comment.Content,
                CommentCount = _commentService.GetDefault(x => x.ArticleID == articleID && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count(),
                LikeCount = _likeService.GetDefault(x => x.ArticleID == articleID && (x.Status == Core.Enum.Status.Active || x.Status == Core.Enum.Status.Updated)).Count(),
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteComment(Guid id)
        {
            Guid userID = _appUserService.FindByUserName(HttpContext.User.Identity.Name).ID;
            Comment comment = _commentService.GetByID(id);
            bool isDelete = false;


            if (comment.AppUserID == userID)
            {
                isDelete = true;

                _commentService.Remove(id);

                return Json(isDelete, JsonRequestBehavior.AllowGet);
            }

            else
            {
                isDelete = false;

                return Json(isDelete, JsonRequestBehavior.AllowGet);
            }
        }
    }
}