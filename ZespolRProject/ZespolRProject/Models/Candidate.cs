//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZespolRProject.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Candidate
    {
        public int ca_id { get; set; }
        public string ca_name { get; set; }
        public string ca_surname { get; set; }
        public Nullable<long> ca_phone { get; set; }
        public Nullable<int> ca_def_lng { get; set; }
        public string ca_password { get; set; }
    
        public virtual Language Language { get; set; }
        public virtual TestTake TestTake { get; set; }
    }
}
