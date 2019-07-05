using News.Model.Option;
using News.Service.Option;
using News.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace News.UI.Controllers
{
    public class AccountController : Controller
    {
        AppUserService _appUserService;

        public AccountController()
        {
            _appUserService = new AppUserService();
        }

        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                AppUser user = _appUserService.FindByUserName(User.Identity.Name);

                if (user.Status == Core.Enum.Status.Active || user.Status == Core.Enum.Status.Updated)
                {
                    if (user.Role == Role.Admin)
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Admin/Home/Index");
                    }
                    else if (user.Role == Role.Author)
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Author/Home/Index");
                    }
                    else
                    {
                        string cookie = user.UserName;
                        FormsAuthentication.SetAuthCookie(cookie, true);
                        Session["FullName"] = user.FirstName + ' ' + user.LastName;
                        Session["ImagePath"] = user.UserImage;
                        return Redirect("/Member/Home/Index");
                    }
                }

                else
                {
                    ViewData["error"] = "Username or Password is wrong";
                    return View();
                }
            }

            else
            {
                TempData["class"] = "cutom-hide";
                return View();
            }
        }

        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Login(LoginVM credential)
        {
            if (ModelState.IsValid)
            {
                if (_appUserService.CheckCredentials(credential.UserName, credential.Password))
                {
                    AppUser user = _appUserService.FindByUserName(credential.UserName);

                    if (user.Status == Core.Enum.Status.Active || user.Status == Core.Enum.Status.Updated)
                    {
                        if (user.Role == Role.Admin)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Admin/Home/Index");
                        }
                        else if (user.Role == Role.Author)
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Author/Home/Index");
                        }
                        else
                        {
                            string cookie = user.UserName;
                            FormsAuthentication.SetAuthCookie(cookie, true);
                            Session["FullName"] = user.FirstName + ' ' + user.LastName;
                            Session["ImagePath"] = user.UserImage;
                            return Redirect("/Member/Home/Index");
                        }
                    }
                    else
                    {
                        ViewData["error"] = "Username or Password is wrong!";
                        return View();
                    }

                }
                else
                {
                    ViewData["error"] = "Username or Password is wrong!";
                    return View();
                }
               
            }

            else
            {
                TempData["class"] = "custom-hide";
                return View();
            }
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Account/Login");
        }
    }
}
    
