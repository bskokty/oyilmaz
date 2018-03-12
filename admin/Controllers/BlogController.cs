using oylmData.Data;
using Commonn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.IO;

namespace admin.Controllers
{
    public class BlogController : Controller 
    {
        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: Blog
        public ActionResult Index()
        {


            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<BlogYazi> byazi = datas.BlogYazis.Where(t=>t.id!=22).ToList();

            return View(byazi);
        }

     

        // GET: Blog/Create
        public ActionResult Create()
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            return View();
        }

        // POST: Blog/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            BlogYazi blg = new BlogYazi();


            blg.Baslik = frm["Baslik"].ToString();
            blg.Content = frm["editor1"].ToString();
            blg.tanitimYazi = frm["tanitim"].ToString();
            blg.tarih = DateTime.Now;
            blg.aySira = DateTime.Now.Month;
            switch (DateTime.Now.Month)
            {
                case 1:
                    blg.aylar = "Ocak";
                    break;
                case 2:
                    blg.aylar = "Şubat";
                    break;
                case 3:
                    blg.aylar = "Mart";
                    break;
                case 4:
                    blg.aylar = "Nisan";
                    break;
                case 5:
                    blg.aylar = "Mayıs";
                    break;
                case 6:
                    blg.aylar = "Haziran";
                    break;
                case 7:
                    blg.aylar = "Temmuz";
                    break;
                case 8:
                    blg.aylar = "Ağustos";
                    break;
                case 9:
                    blg.aylar = "Eylül";
                    break;
                case 10:
                    blg.aylar = "Ekim";
                    break;
                case 11:
                    blg.aylar = "Kasım";
                    break;

                case 12:
                    blg.aylar = "Aralık";
                    break;

                default:
                    break;
            }



            if (Request.Files.Count > 0)
            {  string path = Server.MapPath("/");
                blg.path = path;


                if (Directory.Exists(path + "/BlogPics") == false)
                {


                    Directory.CreateDirectory(path + "BlogPics/");
                }
                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                    Request.Files["pic"].SaveAs(path + "BlogPics/" + Request.Files["pic"].FileName);
                }
            }
            


            blg.folder = string.IsNullOrEmpty(Request.Files["pic"].FileName) == true ? "" : " BlogPics/" + Request.Files["pic"].FileName;
          


            try
            {
                // TODO: Add insert logic here
                datas.BlogYazis.Add(blg);
          
                datas.SaveChanges();
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Edit/5
        public ActionResult Edit(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            BlogYazi co = datas.BlogYazis.Where(t => t.id == id).FirstOrDefault();
          
            return View(co);
        }

        // POST: Blog/Edit/5
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                // TODO: Add update logic here
                BlogYazi blg = datas.BlogYazis.Where(t => t.id == id).FirstOrDefault();
                blg.Baslik = frm["Baslik"].ToString();
                blg.Content = frm["editor1"].ToString();
                blg.tanitimYazi = frm["tanitimYazi"].ToString();
                blg.tarih = DateTime.Now;
                blg.aySira = DateTime.Now.Month;

                if (Request.Files.Count > 0)
                {
                   
                    
                        string path = Server.MapPath("/");
                        if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                        {
                            Request.Files["pic"].SaveAs(path + "BlogPics/" + Request.Files["pic"].FileName);
                        }

                    if (string.IsNullOrEmpty(Request.Files["pic"].FileName) == false)
                    {
                        blg.folder = "BlogPics/" + Request.Files["pic"].FileName;

                    }

                }

                datas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blog/Delete/5
        public ActionResult Delete(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                datas.BlogYazis.Remove(datas.BlogYazis.Where(a => a.id == id).FirstOrDefault());
                datas.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        
       
    }
}
