using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace oylmWeb.Controllers
{
    public class KocController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        // GET: Koc
        public ActionResult Index()
        {
            return View();
        }

        // GET: Koc/Details/5
        public ActionResult detay(int id)
        {
            alcontent al = datas.alcontents.Where(a => a.id == id).FirstOrDefault();

            return View(al);
        }

        // GET: Koc/Create
        public ActionResult menu()
        {
            List<alcontent> al = datas.alcontents.Where(a=>a.status==1).ToList();

            return PartialView(al);
        }

        // POST: Koc/Create
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

        // GET: Koc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Koc/Edit/5
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

        // GET: Koc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Koc/Delete/5
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
