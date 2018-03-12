using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oylmWeb.Controllers
{
    public class HomeController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        public ActionResult Index()
        {
            List<Slider> sli = datas.Sliders.Where(t => t.status == 1).ToList();
            return View(sli);
        }
        public ActionResult duyuru()
        {
  
            return View();
        }
        [ChildActionOnly]
        public PartialViewResult Menu()
        {
            List<Content> pge = datas.Contents.Where(t=>t.status==1).ToList();

            return PartialView(pge);
        }
        [HttpGet]
        public ActionResult DanısanYorum()
        {
          
            return View();
        }
        [HttpPost]
        public ActionResult DanısanYorum(FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                if (frm[1]!="" || frm[0] != "")
                {
                    yorumDanisan yrm = new yorumDanisan
                    {
                        email = frm[0],
                        kadi = frm[1],
                        status = 2,
                        comment = frm[2]

                    };
                    try
                    {
                        datas.yorumDanisans.Add(yrm);
                        datas.SaveChanges();
                        ViewBag.mesaj = "Yorumunuz Başarıyla Kaydedilmiştir.";
                        return View();
                    }
                    catch (Exception ex)
                    {
                        ViewBag.mesaj = "Bilgilerinizi eksik veya hatalı girdiniz.";
                    }
                }
               

               

            }





            ViewBag.mesaj = "Bilgilerinizi eksik veya hatalı girdiniz.";

            return View();
        }
    }
}