using oylmData.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.Controllers
{
    public class FilesController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: Files
        public ActionResult Index()
        {
            List<sertifikalar> srf = datas.sertifikalars.ToList();
            return View(srf);
        }

        // GET: Files/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Files/Create
        public ActionResult Create()
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            return View();
        }

        // POST: Files/Create
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            sertifikalar srf = new sertifikalar();


            srf.name = frm["name"].ToString();
    
           



            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("/");
                srf.folder = path;


                if (Directory.Exists(path + "/Belgeler") == false)
                {


                    Directory.CreateDirectory(path + "Belgeler/");
                }
                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                    Request.Files["pic"].SaveAs(path + "Belgeler/" + Request.Files["pic"].FileName);
                }
            }



            srf.folder = string.IsNullOrEmpty(Request.Files["pic"].FileName) == true ? "" : "Belgeler/" + Request.Files["pic"].FileName;



            try
            {
                // TODO: Add insert logic here
                datas.sertifikalars.Add(srf);

                datas.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
           
        }
  

        // GET: Files/Edit/5
        public ActionResult Edit(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            sertifikalar co = datas.sertifikalars.Where(t => t.id == id).FirstOrDefault();
            return View(co);
        }

        // POST: Files/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm)
        {
            sertifikalar srf = datas.sertifikalars.Where(a=>a.id==id).FirstOrDefault();


            srf.name = frm["name"].ToString();
            
            if (Request.Files.Count > 0)
            {
                string path = Server.MapPath("/");
               
               
                if (!string.IsNullOrEmpty(Request.Files["pic"].FileName))
                {
                    Request.Files["pic"].SaveAs(path + "Belgeler/" + Request.Files["pic"].FileName);
                }

                if (string.IsNullOrEmpty(Request.Files["pic"].FileName) == false)
                {
                    srf.folder = "Belgeler/" + Request.Files["pic"].FileName;

                }
            }
            

            try
            {
                // TODO: Add insert logic here
                

                datas.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: Files/Delete/5
        public ActionResult Delete(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                datas.sertifikalars.Remove(datas.sertifikalars.Where(a => a.id == id).FirstOrDefault());
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
