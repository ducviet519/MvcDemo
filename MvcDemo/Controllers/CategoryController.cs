﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemo.Models;

namespace MvcDemo.Controllers
{
    public class CategoryController : Controller
    {
        // GET: /Category/
        [HttpGet]
        public ActionResult Index()
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                List<Category> lstCategory = db.Categories.ToList();
                return View(lstCategory);
            }
        }

        // POST: /Category/Index/
        [HttpPost]
        public ActionResult Index(FormCollection collection)
        {
            //Lay du lieu tu tren view
            string tenChuyenMuc = collection["TenChuyenMuc"].ToString();
            int chuyenMucCha = collection["ChuyenMucCha"].ToString() != "" ? Convert.ToInt32(collection["ChuyenMucCha"].ToString()) : 0;

            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                //Them chuyen muc vao csdl
                //Khoi tao doi tuong muon them vao csdl
                Category cate = new Category();
                cate.Name = tenChuyenMuc;
                cate.Parent = chuyenMucCha;

                //Them doi tuong vao csdl
                db.Categories.Add(cate);
                //Thuc hien ghi vao csdl
                db.SaveChanges();

                //Lay danh sach chuyen muc trong csdl tra ve view
                List<Category> lstCategory = db.Categories.ToList();
                return View(lstCategory);
            }
        }

        //Category/Edit/123/
        [HttpGet]
        public ActionResult Edit(int id)
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                Category cate = db.Categories.FirstOrDefault(x => x.ID == id);
                return View(cate);
            }
        }

        //Category/Edit/123/
        [HttpPost]
        public ActionResult Edit(FormCollection collection, int id)
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                //Lay du lieu tu tren view
                string tenChuyenMuc = collection["TenChuyenMuc"].ToString();
                int chuyenMucCha = collection["ChuyenMucCha"].ToString() != "" ? Convert.ToInt32(collection["ChuyenMucCha"].ToString()) : 0;

                //Lấy đối tượng cần sửa
                Category cate = db.Categories.FirstOrDefault(x => x.ID == id);

                //Gán lại thông tin cần sửa
                cate.Name = tenChuyenMuc;
                cate.Parent = chuyenMucCha;

                //Thực hiện thay đổi trong csdl
                db.SaveChanges();

                //Lay danh sach chuyen muc trong csdl tra ve view
                List<Category> lstCategory = db.Categories.ToList();
                return RedirectToAction("Index", lstCategory);
            }
        }

        public ActionResult Delete(int id)
        {
            using (MVC_Demo2Entities db = new MVC_Demo2Entities())
            {
                //Lấy đối tượng cần sửa
                Category cate = db.Categories.FirstOrDefault(x => x.ID == id);

                //Thực hiện xóa đối tượng
                db.Categories.Remove(cate);

                //Thực hiện thay đổi trong csdl
                db.SaveChanges();

                //Lay danh sach chuyen muc trong csdl tra ve view
                List<Category> lstCategory = db.Categories.ToList();
                return RedirectToAction("Index", lstCategory);
            }
        }
    }
}