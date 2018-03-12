using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace admin.Controllers
{
    public class ContactController : Controller
    {
        oylmzEntities datas = new oylmzEntities();
        User user = CommonOparation.General.checkToken();
        // GET: Contact
        public ActionResult Index()
        {
            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }

            List<Contact> cont = datas.Contacts.ToList();
            ViewBag.mesaj = "-";
            return View(cont);

        }


        // GET: Contact/Create
        public ActionResult Create()
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection frm)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            if (Convert.ToInt32(frm["statussec"])==1)
            {
                foreach (var item in datas.Contacts.ToList())
                {
                    item.status = 2;
                }
            }
            Contact cnt = new Contact();
            cnt.adress = frm["adress"].ToString();
            cnt.email = frm["email"].ToString();
            cnt.phone = frm["phone"].ToString();
            cnt.status = Convert.ToInt32(frm["statussec"]);


            try
            {
                // TODO: Add insert logic here
                datas.Contacts.Add(cnt);
                datas.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            Contact cnt = datas.Contacts.Where(t => t.Id == id).FirstOrDefault();
            return View(cnt);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection frm)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            if (Convert.ToInt32(frm["statussec"]) == 1)
            {
                foreach (var item in datas.Contacts.ToList())
                {
                    item.status = 2;
                }
            }
            try
            {
                // TODO: Add update logic here
                Contact cnd = datas.Contacts.Where(t => t.Id == id).FirstOrDefault();
                cnd.adress = frm["adress"].ToString();
                cnd.email = frm["email"].ToString();
                cnd.phone = frm["phone"].ToString();
                cnd.status = Convert.ToInt32(frm["statussec"]);
                datas.SaveChanges();
         
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {

            if (user == null)
            {
                return RedirectToAction("Login", "Account");

            }
            try
            {
                datas.Contacts.Remove(datas.Contacts.Where(a => a.Id == id).FirstOrDefault());
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
