using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.Controllers
{
    public class CommentsController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: Comments
        public ActionResult Index()
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<yorumlar> yrm = datas.yorumlars.OrderByDescending(t=>t.id).ToList();

            return View(yrm);
        }

        public ActionResult Indextwo()
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<yorumDanisan> yrm = datas.yorumDanisans.OrderByDescending(t => t.id).ToList();

            return View(yrm);
        }
        // GET: Comments/Details/5
        public ActionResult Details(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            yorumlar yrm = datas.yorumlars.Where(t => t.id == id).FirstOrDefault();
            return View(yrm);
        }
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
                yorumlar blg = datas.yorumlars.Where(t => t.id == id).FirstOrDefault();
                blg.satutus = Convert.ToInt32(frm["statussec"]);

                datas.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult DetailsD(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            yorumDanisan yrm = datas.yorumDanisans.Where(t => t.id == id).FirstOrDefault();
            return View(yrm);
        }

        // POST: Comments/Edit/5
        [HttpPost]
        public ActionResult EditD(int id,FormCollection frm)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            //try
            //{
            // TODO: Add update logic here
    
            datas.yorumDanisans.Where(t => t.id == id).FirstOrDefault().status = Convert.ToInt32(frm["statussec"]);
            datas.SaveChanges();
            //ViewBag.abc = Convert.ToInt32(frm["statussec"]);
            return RedirectToAction("Indextwo");
            //}
            //catch
            //{
            //    return View();
            //}
        }
        public ActionResult DeleteD(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                datas.yorumDanisans.Remove(datas.yorumDanisans.Where(a => a.id == id).FirstOrDefault());
                datas.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Indextwo");
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                datas.yorumlars.Remove(datas.yorumlars.Where(a => a.id == id).FirstOrDefault());
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
