using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using System;
using System.Web.Mvc;

namespace MVCLucene.Controllers
{
    public class HomeController : Controller
    {
        private static IndexWriter indexWriter = null;



        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search()
        {
            return Json(new {data="datastring"});
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }



        public ActionResult Test()
        {
            //这里故意出错
            int a=100, b=0;
            int c = a / b;
            return Content("test");
        }
       


        /// <summary>
        /// 添加索引
        /// </summary>
        /// <param name="indexWriter"></param>
        /// <param name="Title"></param>
        /// <param name="Content"></param>
        /// <param name="Datetime"></param>
        /// <param name="URL"></param>
        private void AddIndex(IndexWriter indexWriter,string Title,string Content,string Datetime,string URL)
        {
            try
            {
                Document document = new Document();
                document.Add(new Field("Title", Title, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field("Content", Content, Field.Store.YES, Field.Index.ANALYZED));
                document.Add(new Field("Datetime", Datetime, Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("URL", URL, Field.Store.YES, Field.Index.NOT_ANALYZED)); //不会生产索引
                indexWriter.AddDocument(document);

            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        
    }
}