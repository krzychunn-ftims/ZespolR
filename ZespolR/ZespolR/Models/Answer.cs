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
    
    public partial class Answer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Answer()
        {
            this.tt_a_assoc = new HashSet<tt_a_assoc>();
        }
    
        public int a_id { get; set; }
        public Nullable<int> a_q { get; set; }
        public string a_body { get; set; }
        public Nullable<decimal> a_score { get; set; }
        public Nullable<bool> a_is_user { get; set; }
    
        public virtual Question Question { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tt_a_assoc> tt_a_assoc { get; set; }
    }
}
