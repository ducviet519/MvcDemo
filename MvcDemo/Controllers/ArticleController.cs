using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class ArticleController : Controller
    {
        // GET: /Article/
        public ActionResult Index()
        {
            return View();
        }

        // GET: //Article/LoadArticle/
        public JsonResult LoadArticle()
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {

                var lstArticles = db.Articles.Select(x => new
                {
                    Id123 = x.ID,
                    Title123 = x.Title,
                    CategoryId123 = x.CategoryID
                }).ToList();

                return Json(new { Articles123 = lstArticles }, JsonRequestBehavior.AllowGet);
            }

        }

        //POST: //Aricle/AddArticle/
        public JsonResult AddArticle(string tieude, string chuyenmuc)
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                try
                {
                    //B1 Khoi tao doi tuong can them
                    Article article = new Article();

                    //B2 Gan cac gia tri cho cac thuoc tinh tuong ung
                    article.Title = tieude;
                    article.CategoryID = chuyenmuc != null ? Convert.ToInt32(chuyenmuc) : 0;

                    //B3 Them doi tuong vao csdl
                    db.Articles.Add(article);
                    db.SaveChanges();

                    return Json(new
                    {
                        ID = article.ID,
                        Title = article.Title,
                        CategoryID = article.CategoryID
                    });
                }
                catch
                {
                    return null;
                }

            }
        }
        //POST: //Aricle/DeleteArticle/
        public int DeleteArticle(int id)
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                Article article = db.Articles.SingleOrDefault(x => x.ID == id);
                if (article != null)
                {
                    db.Articles.Remove(article);
                    db.SaveChanges();
                    return id;
                }
                else return -1;
            }
        }
        //Post: //Article/Edit/
        public JsonResult EditArticle(int id, string tieude, string machuyenmuc)
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                try
                {
                    Article editArticle = db.Articles.SingleOrDefault(n => n.ID == id);
                    editArticle.Title = tieude;
                    editArticle.CategoryID = machuyenmuc != null ? Convert.ToInt32(machuyenmuc) : 0;
                    db.SaveChanges();
                    return Json(new
                    {
                        ID = editArticle.ID,
                        Title = editArticle.Title,
                        CategoryID = editArticle.CategoryID
                    });
                }
                catch
                {
                    return null;
                }
            }
        }
        public int TinhTong(int a1, int b1)
        {
            return a1 + b1;

        }

        //GET : Article/DemXau
        public int DemXau(string s)
        {
            return s.Length;
        }
    }
}