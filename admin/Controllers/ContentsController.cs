using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using oylmData.Data;
using System.Data.Entity;


namespace admin.Controllers
{
    public class ContentsController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: Contents
        public ActionResult Index()
        {
          


            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<Content> cont = datas.Contents.ToList();


            return View(cont);
         
        }

  

        // GET: Contents/Create
        public ActionResult Create()
        {

           
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<Page> pages = datas.Pages.ToList();


            return View(pages);
        }

        // POST: Contents/Create
        [ValidateInput(false)]
        public PartialViewResult createCont(int pageID,string cont,int aktif)
        {

           
            try
            {
                //int a = Convert.ToInt32(collection[0]);
                List<Content> co = datas.Contents.Where(t => t.pageId == pageID).ToList();
                foreach (var item in co )
                {
                    item.status = 2;
                }
                Content conte= new Content
                {
                    pageId = pageID,
                    contenttext = cont,
                    status = 1

                };
                datas.Contents.Add(conte);
                datas.SaveChanges();

                List<Content> contig = datas.Contents.ToList();
                return PartialView("createCont", contig);
            }
            catch
            {
                return PartialView("createCont");
            }
            return PartialView("createCont");
        }



        // GET: Contents/Edit/5
   
        public ActionResult Edit(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            List<Content> co = datas.Contents.Where(t => t.pageId == id).ToList();
            Models.PageViewModel gelen = new Models.PageViewModel {

                pge = datas.Pages.ToList(),
                contenttext = datas.Contents.Where(t => t.ID==id).FirstOrDefault().contenttext,
                status = datas.Contents.Where(t => t.ID == id).FirstOrDefault().status,
               pageId = datas.Contents.Where(t => t.ID == id).FirstOrDefault().pageId,
               

            };


            ViewBag.id = id;
            return View(gelen);
        }

        public PartialViewResult sirala()
        {
            List<Page> blg = datas.Pages.ToList();
            return PartialView(blg);
        }

        public PartialViewResult siralaa(int id)
        {
            if (id==-1)
            {
                List<Content> blgi = datas.Contents.ToList();
                return PartialView(blgi);

            }
            List<Content> blg = datas.Contents.Where(t => t.pageId == id).ToList();
            return PartialView(blg);
        }

        [ValidateInput(false)]
        public PartialViewResult Guncelle(int id, int pageID, string cont, int aktif)
        {
            try
            {
                // TODO: Add update logic here


                Content conte = datas.Contents.Where(t => t.ID == id).FirstOrDefault();

                conte.pageId = pageID;
                conte.contenttext = cont;
           

                if (aktif==1)
                {
                    List<Content> co = datas.Contents.Where(t => t.pageId == pageID).ToList();
                    foreach (var item in co)
                    {
                        item.status = 2;
                    }

                }
                conte.status = aktif;
                datas.SaveChanges();

                List<Content> contig = datas.Contents.ToList();
                return PartialView("createCont", contig);
            
            }
            catch
            {
                return PartialView("createCont");
            }
        }

        // GET: Contents/Delete/5
        public ActionResult Delete(int id)
        {

          
            try
            {
                datas.Contents.Remove(datas.Contents.Where(a => a.ID == id).FirstOrDefault());
                datas.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        // POST: Contents/Delete/5
        [HttpPost]
     
        public PartialViewResult PageGetir()
        {

            List<Page> pages = datas.Pages.ToList();
            return PartialView("PageGetir",pages);
        }
        public PartialViewResult StatusGetir()
        {

            List<Status> stas = datas.Status.ToList();
            return PartialView("StatusGetir", stas);
        }


    }
}
