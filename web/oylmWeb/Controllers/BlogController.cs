using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oylmWeb.Controllers
{
    public class BlogController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        // GET: Blog
        public ActionResult Index()
        {
            List<BlogYazi> blg = datas.BlogYazis.Where( t=> t.id!=22).OrderByDescending(t => t.id).Take(3).ToList();
            return View(blg);
        }
        public ActionResult yorum(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }
        // GET: Blog/Details/5
        public ActionResult detay(int id)
        {
            BlogYazi blg = datas.BlogYazis.Where(t => t.id == id).FirstOrDefault();
            List<yorumlar> yrm = datas.yorumlars.Where(t => t.blogid == id && t.satutus==1).ToList();
            Models.BlogViewMoldels blgg = new Models.BlogViewMoldels();
            blgg.yrms = yrm;
            blgg.blogid = id;
            blgg.Baslik = blg.Baslik;
            blgg.aySira=blg.aySira;
            blgg.Content = blg.Content;
            blgg.folder = blg.folder;
            blgg.path = blg.path;
        


            return View(blgg);
        }
        public ActionResult yorumgnder(FormCollection frm)
        {
            int blgid = Convert.ToInt32(frm[0]);

            if (frm[2] != "")
            {

                if (frm[1] != "")
                {
                    if (ModelState.IsValid)
                    {
                        yorumlar yrm = new yorumlar
                        {
                            mail = frm[1],
                            content = frm[2],
                            satutus = 2,
                            blogid = Convert.ToInt32(frm[0]),
                            date = DateTime.Now.Date,

                        };

                        try
                        {
                            datas.yorumlars.Add(yrm);
                            datas.SaveChanges();
                            ViewBag.mesaj = "Yorumunuz Başarıyla Kaydedilmiştir.";
                            BlogYazi blg = datas.BlogYazis.Where(t => t.id == blgid).FirstOrDefault();
                            List<yorumlar> yorm = datas.yorumlars.Where(t => t.blogid == blgid && t.satutus == 1).OrderBy(t => t.id).ToList();
                            Models.BlogViewMoldels blgg = new Models.BlogViewMoldels();
                            blgg.yrms = yorm;
                            blgg.blogid = blgid;
                            blgg.Baslik = blg.Baslik;
                            blgg.aySira = blg.aySira;
                            blgg.Content = blg.Content;
                            blgg.folder = blg.folder;
                            blgg.path = blg.path;


                            return View("detay", blgg);
                        }
                        catch (Exception ex)
                        {
                            ViewBag.mesaj = "Bilgilerinizi eksik veya hatalı girdiniz.";
                            BlogYazi blg = datas.BlogYazis.Where(t => t.id == blgid).FirstOrDefault();
                            List<yorumlar> yorm = datas.yorumlars.Where(t => t.blogid == blgid && t.satutus == 1).OrderBy(t => t.id).ToList();
                            Models.BlogViewMoldels blgg = new Models.BlogViewMoldels();
                            blgg.yrms = yorm;
                            blgg.blogid = blgid;
                            blgg.Baslik = blg.Baslik;
                            blgg.aySira = blg.aySira;
                            blgg.Content = blg.Content;
                            blgg.folder = blg.folder;
                            blgg.path = blg.path;


                            return View("detay", blgg);
                        }

                    }
                }
            }
            BlogYazi blggg = datas.BlogYazis.Where(t => t.id == blgid).FirstOrDefault();
            List<yorumlar> yormm = datas.yorumlars.Where(t => t.blogid == blgid && t.satutus == 1).OrderBy(t => t.id).ToList();
            Models.BlogViewMoldels blgggg = new Models.BlogViewMoldels();
            blgggg.yrms = yormm;
            blgggg.blogid = blgid;
            blgggg.Baslik = blggg.Baslik;
            blgggg.aySira = blggg.aySira;
            blgggg.Content = blggg.Content;
            blgggg.folder = blggg.folder;
            blgggg.path = blggg.path;

            ViewBag.mesaj = "Bilgilerinizi eksik veya hatalı girdiniz.";
            return View("detay", blgggg);

        }
        public ActionResult menu()
        {
        
            List<BlogYazi> blg = datas.BlogYazis.Where(a=>a.id!=22).ToList();
            Models.BlogViewMoldels blgg = new Models.BlogViewMoldels();
            blgg.byzi = blg;

           var blg2 = (from d in datas.BlogYazis select d.aylar).Distinct();






            foreach (var item in blg2)
            {
                blgg.msk.Add(item);
            }


            return PartialView(blgg);
        }
        // GET: Blog/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blog/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: Blog/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: Blog/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
