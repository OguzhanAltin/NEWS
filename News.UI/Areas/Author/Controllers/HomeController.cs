using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace News.UI.Areas.Author.Controllers
{
    public class HomeController : Controller
    {
        // GET: Author/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}