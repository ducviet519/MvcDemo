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
            using (MVCDemoEntities db = new MVCDemoEntities())
            {

                var lstArticles = db.Articles.Select(x => new
                {
                    Id123 = x.Id,
                    Title123 = x.Title,
                    CategoryId123 = x.CategoryId
                }).ToList();

                return Json(new { Articles123 = lstArticles }, JsonRequestBehavior.AllowGet);
            }

        }

        //POST: //Aricle/AddArticle/
        public JsonResult AddArticle(string tieude, string chuyenmuc)
        {
            using (MVCDemoEntities db = new MVCDemoEntities())
            {
                try
                {
                    //B1 Khoi tao doi tuong can them
                    Article article = new Article();

                    //B2 Gan cac gia tri cho cac thuoc tinh tuong ung
                    article.Title = tieude;
                    article.CategoryId = chuyenmuc != null ? Convert.ToInt32(chuyenmuc) : 0;

                    //B3 Them doi tuong vao csdl
                    db.Articles.Add(article);
                    db.SaveChanges();

                    return Json(new
                    {
                        ID = article.Id,
                        Title = article.Title,
                        CategoryID = article.CategoryId
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
            using (MVCDemoEntities db = new MVCDemoEntities())
            {
                Article article = db.Articles.SingleOrDefault(x => x.Id == id);
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
            using (MVCDemoEntities db = new MVCDemoEntities())
            {
                try
                {
                    Article editArticle = db.Articles.SingleOrDefault(n => n.Id == id);
                    editArticle.Title = tieude;
                    editArticle.CategoryId = machuyenmuc != null ? Convert.ToInt32(machuyenmuc) : 0;
                    db.SaveChanges();
                    return Json(new
                    {
                        ID = editArticle.Id,
                        Title = editArticle.Title,
                        CategoryID = editArticle.CategoryId
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