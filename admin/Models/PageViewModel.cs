using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace admin.Models
{
    public class PageViewModel
    {
        public int ID { get; set; }
        public string name { get; set; }
        public string Contents { get; set; }


        public  List<Page> pge { get; set; }
        public string contenttext{ get; set; }
        public int pageId { get; set; }
        public int? status { get; set; }

    }
}