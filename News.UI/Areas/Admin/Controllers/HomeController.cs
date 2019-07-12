using News.Model.Option;
using News.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.UI.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        AppUserService _appUserService;
        public HomeController()
        {
            _appUserService = new AppUserService();
        }
        public ActionResult Index()
        {
            TempData["class"] = "custom-hide";

            if (!HttpContext.User.Identity.IsAuthenticated)
            {
                return View();
            }

            AppUser user = new AppUser();
            user = _appUserService.FindByUserName(HttpContext.User.Identity.Name);

            if (user.Role == Role.Admin)
            {
                TempData["class"] = "custom-show";
            }
            return View();
        }
    }
}