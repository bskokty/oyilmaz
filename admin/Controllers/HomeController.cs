using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oylmData.Data;
using System.Data.Entity;

namespace admin.Controllers
{
    public class HomeController : Controller
    {

        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: Home
        public ActionResult Index()
        {
           


            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<Page> pages = datas.Pages.ToList();


            return View(pages);
        }

   

        // GET: Home/Create
        public ActionResult Create()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {

                Page pages = new Page();
                pages.name = frm[1].ToString();
                datas.Pages.Add(pages);
                datas.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            if (id == 0) { return RedirectToAction("Create"); }
            Page pages=datas.Pages.Where(a => a.ID == id).FirstOrDefault();
            return View(pages);
        }

        // POST: Home/Edit/5
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
                Page pages = datas.Pages.Where(a => a.ID == id).FirstOrDefault();
                pages.name = frm[2].ToString();
                datas.SaveChanges();
                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (datas.Contents.Where(a => a.pageId == id).FirstOrDefault()!=null)
                {
                    foreach (var item in datas.Contents.Where(a => a.pageId == id).ToList())
                    {
                        datas.Contents.Remove(datas.Contents.Where(a => a.pageId == id).FirstOrDefault());
                    }
                datas.SaveChanges();

            }

                datas.Pages.Remove(datas.Pages.Where(a => a.ID == id).FirstOrDefault());

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
