using oylmData.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace oylmWeb.Models
{
    public class BlogViewMoldels
    {

        [Required(ErrorMessage = "Bu alan gereklidir.")]
        [EmailAddress(ErrorMessage = "Hatalı e-mail fromatı.")]
        public string mail { get; set; }
        public string content { get; set; }
        public Nullable<int> satutus { get; set; }
        public Nullable<int> blogid { get; set; }

        public string aylar { get; set; }
        public List<yorumlar> yrms;
        public List<string> msk = new List<string>();
        public List<BlogYazi> byzi;
        public int id { get; set; }
        public string Baslik { get; set; }
        public string Content { get; set; }
        public Nullable<System.DateTime> tarih { get; set; }
        public Nullable<int> aySira { get; set; }
        public string tanitimYazi { get; set; }
        public string folder { get; set; }
        public string path { get; set; }



    }
}