//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace oylmData.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Content
    {
        public int ID { get; set; }
        public string contenttext { get; set; }
        public int pageId { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual Page Page { get; set; }
        public virtual Status Status1 { get; set; }
    }
}
