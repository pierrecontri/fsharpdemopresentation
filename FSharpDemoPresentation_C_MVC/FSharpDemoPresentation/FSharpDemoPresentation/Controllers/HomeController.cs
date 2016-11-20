using FSharpDemoPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;

namespace FSharpDemoPresentation.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View(ChaptersPresentationModel.DbChapters);
        }

        public ViewResult DemoContent(string title, string category)
        {
            ViewBag.Title = title;
            ViewBag.ContentPartialView = category;
            return View(ChaptersPresentationModel.DbChapters);
        }

        #region Dynamic view (use partial)
        public ViewResult Presentation()
        {
            var chapters = ChaptersPresentationModel.DbChapters;
            //var rslt = chapters.AsEnumerable<ChapterPresentation>()
            //    .Join((new List<string>() { "Introduction", "Conclusion" }).AsEnumerable<string>(),
            //            chp => chp.Title, sec => sec, (chp, tit) => chp)
            //    .Select(chp => chp)
            //    .ToList<ChapterPresentation>();
            //return View(rslt);
            return View(chapters);
        }

        public PartialViewResult GetCategory(string title, string category)
        {
            ViewBag.Title = title;
            var selectedCategory = ChaptersPresentationModel.DbChapters.Where(chap => chap.Title.Equals(title)).ToList();
            return PartialView(category, selectedCategory);
        }
        #endregion

        #region Contact & About
        public ActionResult About()
        {
            ViewBag.Message = "This application is just a presentation of F# programming.";

            return View(ChaptersPresentationModel.DbChapters);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pierre Contri";

            return View(ChaptersPresentationModel.DbChapters);
        }
        #endregion
    }
}