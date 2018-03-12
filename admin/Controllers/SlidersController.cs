using oylmData.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.Controllers
{
    public class SlidersController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: Sliders
        public ActionResult Index()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            List<Slider> slid = datas.Sliders.ToList();
            ViewBag.mesaj = "-";
            return View(slid);
        }

       
        // GET: Sliders/Create
        public ActionResult Create()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<BlogYazi> blogBas = datas.BlogYazis.ToList();

            
            return View(blogBas);
           
        }

        // POST: Sliders/Create
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            //try
            //{
                Slider sli = new Slider();
                sli.buyuk= frm["buyuk"].ToString();
                sli.orta= frm["orta"].ToString();
                sli.kucuk= frm["kucuk"].ToString();

                if (Request.Files.Count > 0)
                {

                //string path = Server.MapPath("/");
                string path = Server.MapPath("/");
                sli.path = path;
                if (Directory.Exists(path + "/SliderPics") == false)
                    {


                        Directory.CreateDirectory(path + "SliderPics/");
                    }
                    if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                    {
                        Request.Files["pic"].SaveAs(path + "SliderPics/" + Request.Files["pic"].FileName);
                    }
                }



                sli.sliderContent = string.IsNullOrEmpty(Request.Files["pic"].FileName) == true ? "" : "SliderPics/" + Request.Files["pic"].FileName;
                if (Convert.ToInt32(frm["baslikSec"])==(-1))
                {
                    sli.byaziid = 22;
                }
                else { 
                sli.byaziid=Convert.ToInt32(frm["baslikSec"]);
                }
                sli.status = Convert.ToInt32(frm["statussec"]);

                datas.Sliders.Add(sli);
                datas.SaveChanges();

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return RedirectToAction("Index");
            //}
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            Models.SlideViewModel sli = new Models.SlideViewModel {
                sliderContent = datas.Sliders.Where(t => t.ID == id).FirstOrDefault().sliderContent,
                buyuk = datas.Sliders.Where(t => t.ID == id).FirstOrDefault().buyuk,
                orta = datas.Sliders.Where(t => t.ID == id).FirstOrDefault().orta,
                kucuk = datas.Sliders.Where(t => t.ID == id).FirstOrDefault().kucuk,
                byaziid = datas.Sliders.Where(t => t.ID == id).FirstOrDefault().byaziid,
                blgyzi = datas.BlogYazis.ToList(),

            };
            return View(sli);
        }

        // POST: Sliders/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm )
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            Slider sli = datas.Sliders.Where(t => t.ID == id).FirstOrDefault();
            sli.buyuk = frm["buyuk"].ToString();
            sli.orta = frm["orta"].ToString();
            sli.kucuk = frm["kucuk"].ToString();
            if (Request.Files.Count > 0)
            {


                string path = Server.MapPath("/");
               
                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                    Request.Files["pic"].SaveAs(path + "SliderPics/" + Request.Files["pic"].FileName);
                }

                if (string.IsNullOrEmpty(Request.Files["pic"].FileName) == false)
                {
                    sli.sliderContent = "SliderPics/" + Request.Files["pic"].FileName;

                }

            }

            if (Convert.ToInt32(frm["baslikSec"]) == (-1))
            {
                sli.byaziid = 22;
            }
            else
            {
                sli.byaziid = Convert.ToInt32(frm["baslikSec"]);
            }
            sli.status = Convert.ToInt32(frm["statussec"]);
            try
            {
                // TODO: Add update logic here
                
                datas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                datas.Sliders.Remove(datas.Sliders.Where(a => a.ID == id).FirstOrDefault());
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
