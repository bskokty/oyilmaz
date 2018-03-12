using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oylmWeb.Controllers
{
    public class BenKimimController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        // GET: BenKimim
        public ActionResult Index()
        {
          
            return View();
        }

        // GET: BenKimim/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BenKimim/Create
        public ActionResult menu()
        {
            List<sertifikalar> srf = datas.sertifikalars.ToList();
            return PartialView(srf);
        }
        public ActionResult detay(int id)
        {
            sertifikalar al = datas.sertifikalars.Where(a => a.id == id).FirstOrDefault();

            return View(al);
        }
        // POST: BenKimim/Create
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

        // GET: BenKimim/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BenKimim/Edit/5
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

        // GET: BenKimim/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BenKimim/Delete/5
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
