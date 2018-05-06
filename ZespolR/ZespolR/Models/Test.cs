//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZespolR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Test
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Test()
        {
            this.TestVersion = new HashSet<TestVersion>();
        }
    
        public int t_id { get; set; }
        public string t_name { get; set; }
        public string t_desc { get; set; }
        public Nullable<int> t_po { get; set; }
        public Nullable<int> t_def_lng { get; set; }
        public Nullable<int> t_ed { get; set; }
        public Nullable<System.DateTime> t_start { get; set; }
        public Nullable<System.DateTime> t_end { get; set; }
        public Nullable<bool> t_is_published { get; set; }
        public Nullable<int> t_tt_limit { get; set; }
        public Nullable<decimal> t_pass_limit { get; set; }
        public Nullable<System.TimeSpan> t_time_limit { get; set; }
    
        public virtual Editor Editor { get; set; }
        public virtual Language Language { get; set; }
        public virtual Position Position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TestVersion> TestVersion { get; set; }
    }
}
