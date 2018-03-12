using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.Controllers
{
   
    public class InfController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: ınf
        public ActionResult Index()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            List<KoclukNedir> kn = datas.KoclukNedirs.ToList();
     
            return View(kn);

        
        }
        
        public ActionResult altbaslikContentekle()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<altbaslik> kn = datas.altbasliks.ToList();
            return View(kn);
        }

        public ActionResult altbaslikIndex()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            
            List<altbaslik> kn = datas.altbasliks.ToList();
  
            return View(kn);
        }
        public ActionResult altbaslik()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            return View();
        }
        
        public PartialViewResult siralapar()
        {


          
            List<altbaslik> co = datas.altbasliks.ToList();
           
            return PartialView(co);
           

        }
        public PartialViewResult siralaa(int id)
        {
            if (id == -1)
            {
                List<alcontent> blgi = datas.alcontents.ToList();
                return PartialView(blgi);

            }
            List<alcontent> blg = datas.alcontents.Where(t => t.baslikid == id).ToList();
            return PartialView(blg);
        }

        [HttpPost]
        public ActionResult altbaslik(FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                altbaslik alt = new altbaslik();
                alt.adi = frm["adi"].ToString();
                datas.altbasliks.Add(alt);
                               
                datas.SaveChanges();

                return RedirectToAction("altbaslikIndex");
            }
            catch
            {
                return View();
            }
        }
    
        [ValidateInput(false)]
        public PartialViewResult createCont(int pageID, string cont, int aktif)
        {


            //try
     
                //int a = Convert.ToInt32(collection[0]);
                List<alcontent> co = datas.alcontents.Where(t => t.baslikid == pageID).ToList();
                foreach (var item in co)
                {
                    item.status = 2;
                }
                alcontent  conte = new alcontent
                {
                    baslikid = pageID,
                    content = cont,
                    status = 1

                };
                datas.alcontents.Add(conte);
                datas.SaveChanges();

                List<alcontent> contig = datas.alcontents.ToList();
                return PartialView("createCont", contig);
            //}
            //catch
            //{
            //    return PartialView("createCont");
            //}
           
        }
        public ActionResult alticerikindex()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            List<alcontent> kn = datas.alcontents.ToList();
            return View(kn);
        }

        public ActionResult Create()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            return View();
        }

        // POST: ınf/Create
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                // TODO: Add insert logic here

                if (Convert.ToInt32(frm["statussec"]) == 1)
                {
                    foreach (var item in datas.KoclukNedirs.ToList())
                    {
                        item.status = 2;
                    }
                }
                KoclukNedir kn = new KoclukNedir();


                kn.Kocluk = frm["editor1"].ToString();
                kn.status = Convert.ToInt32(frm["statussec"]);

                datas.KoclukNedirs.Add(kn);
                datas.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Editalt(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            altbaslik kn = datas.altbasliks.Where(t => t.id == id).FirstOrDefault();

            return View(kn);
        }



        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Editalt(int id, FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            if (Convert.ToInt32(frm["statussec"]) == 1)
            {
                foreach (var item in datas.alcontents.ToList())
                {
                    item.status = 2;
                }
            }
            try
            {
                // TODO: Add update logic here
                altbaslik knd = datas.altbasliks.Where(t => t.id == id).FirstOrDefault();
                knd.adi = frm["adi"].ToString();
              
                datas.SaveChanges();
                return RedirectToAction("altbaslikIndex");
            }
            catch
            {
                return View();
            }
        }


        // GET: ınf/Edit/5
        public ActionResult Editcontent(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            alcontent kn = datas.alcontents.Where(t => t.id == id).FirstOrDefault();

            return View(kn);
        }


        
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Editcontent(int id, FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            if (Convert.ToInt32(frm["statussec"]) == 1)
            {
                foreach (var item in datas.alcontents.Where(t => t.id == id).ToList())
                {
                    item.status = 2;
                }
            }
            try
            {
                // TODO: Add update logic here
                alcontent knd = datas.alcontents.Where(t => t.id == id).FirstOrDefault();
                knd.content = frm["editor1"].ToString();
                knd.status = Convert.ToInt32(frm["statussec"]);
                datas.SaveChanges();
                return RedirectToAction("alticerikindex");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            KoclukNedir kn = datas.KoclukNedirs.Where(t => t.id == id).FirstOrDefault();

            return View(kn);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm)
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            if (Convert.ToInt32(frm["statussec"]) == 1)
            {
                foreach (var item in datas.KoclukNedirs.ToList())
                {
                    item.status = 2;
                }
            }
            try
            {
                // TODO: Add update logic here
                KoclukNedir knd = datas.KoclukNedirs.Where(t => t.id == id).FirstOrDefault();
                knd.Kocluk = frm["editor1"].ToString();
                knd.status = Convert.ToInt32(frm["statussec"]);
                datas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

     
        public ActionResult Delete(int id)
        {
            try
            {
                datas.KoclukNedirs.Remove(datas.KoclukNedirs.Where(a => a.id == id).FirstOrDefault());
                datas.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Deletealticerik(int id)
        {
            try
            {

                
                datas.alcontents.Remove(datas.alcontents.Where(a => a.id == id).FirstOrDefault());
                datas.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("alticerikindex");
        }

        public ActionResult Deletealtbaslik(int id)
        {
            try
            {
                
                    if (datas.alcontents.Where(a => a.baslikid == id).FirstOrDefault() != null)
                    {
                        foreach (var item in datas.alcontents.Where(a => a.baslikid == id).ToList())
                        {
                            datas.alcontents.Remove(datas.alcontents.Where(a => a.baslikid == id).FirstOrDefault());
                        }
                        datas.SaveChanges();

                    }
                    datas.altbasliks.Remove(datas.altbasliks.Where(a => a.id == id).FirstOrDefault());
                datas.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }

            return RedirectToAction("altbaslikIndex");
        }

    }
}
