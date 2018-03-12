using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using oylmData.Data;

namespace admin.CommonOparation
{
    public class General
    {
        public static User checkToken()
        {
            HttpCookie cok = HttpContext.Current.Request.Cookies["tk"];



            if (cok == null)
            {
                return null;

            }

            if (HttpContext.Current.Session["user"] != null)
            {

                return (User)HttpContext.Current.Session["user"];
            }


            oylmzEntities db = new oylmzEntities();


            Token token = db.Tokens.Where(t => t.tokentext == cok.Value && t.enddate > DateTime.Now).FirstOrDefault();


            if (token == null)
            {

                HttpCookie ck = new HttpCookie("tk");
                ck.Expires = DateTime.Now.AddDays(-1);
                HttpContext.Current.Response.Cookies.Add(ck);

                HttpContext.Current.Session["user"] = token.User;
                return null;

            }

            return token.User;


        }


    }
}