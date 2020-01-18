using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.IO;

namespace FSharpDemoPresentation.Models
{
    public class ChapterPresentation
    {
        public string View { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
    }

    public class ChaptersPresentationModel
    {
        static private DataSet dsChapters = null;

        static internal IList<ChapterPresentation> DbChapters
        {
            get
            {
                if (dsChapters == null)
                {
                    string chaptersPath = HttpContext.Current.Server.MapPath("~/App_Data/XMLChapters.xml");
                    if (File.Exists(chaptersPath))
                    {
                        dsChapters = new DataSet();
                        dsChapters.ReadXml(chaptersPath);
                    }
                }
                IList<ChapterPresentation> chaptersLists = null; // = new List<ChapterPresentation>();
                chaptersLists = (from DataRow row in dsChapters.Tables["Chapter"].Rows
                                   select new ChapterPresentation
                                   {
                                       View = row["View"] as string,
                                       Title = row["Title"]as string,
                                       Description = row["Description"] as string,
                                       Picture = row["Picture"] as string
                                   }).ToList();
                return chaptersLists;
            }
        }

    }
}