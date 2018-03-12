using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;

namespace oylmWeb.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contact/Details/5
        public ActionResult send(FormCollection frm)
        {

            MailMessage mail = new MailMessage();

            //mesaj sınıfından mail nesnesi oluşturuyoruz. 

            mail.To.Add("ozlemyilmazdemirci@gmail.com");

            //gönderilecek olan mail adresi

            mail.From = new MailAddress(frm["mail"].ToString());

            //kimden gönderilecek. 

            mail.Subject = "Web siteniz üzerinden... Adı: " + frm["name"].ToString();

            //mailin konusu... txtad adlı texboxtan da ismini aldırdım. kaldırabilirsiniz... 
     

            mail.Body = frm["comment"].ToString();

            //mailin içeriği. txtmesaj ve txteposta textboxları kullandım. 

            mail.IsBodyHtml = true;

            //html kodlarına izin verilsin. 

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);

            //gmail smtp adresi tanımlaması

            client.EnableSsl = true;

            // Gmail için sslin aktif olması gerekiyor. 

            NetworkCredential credentials = new NetworkCredential("bskokty@gmail.com", "Bobmarley1..");

            //gmail kullanıcı adı ve şifre... Şifre bölümünü değiştirin(***)

            client.Credentials = credentials;

            try

            {

                client.Send(mail);


         
                ViewBag.mesaj = "Mailiniz Başarılı Bir Şekilde Gönderilmiştir.";
                
            }

            catch (Exception hata)

            {

                return View("Index");

            }
            return View("Index");
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
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

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contact/Edit/5
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

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
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
