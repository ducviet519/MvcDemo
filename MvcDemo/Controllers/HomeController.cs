﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class HomeController : Controller
    {
        //GET: /Home/
        public ActionResult Index()
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                List<Category> lstCategory = db.Categories.Where(x=>x.Parent==null).ToList();
                return View(lstCategory);
            }
        }
    }
}