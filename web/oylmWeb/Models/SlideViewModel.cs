using oylmData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace oylmWeb.Models
{
    public class SlideViewModel
    {
        public int ID { get; set; }
        public string sliderContent { get; set; }
        public string buyuk { get; set; }
        public string orta { get; set; }
        public string kucuk { get; set; }

        public List<BlogYazi> blgyzi = new List<BlogYazi>();
        public int? byaziid { get; set; }
        public int status { get; set; }

    }
}