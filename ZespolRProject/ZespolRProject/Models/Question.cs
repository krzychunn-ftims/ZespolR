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
    
    public partial class Question
    {
        public Question()
        {
            this.Answer = new HashSet<Answer>();
        }
    
        public int q_id { get; set; }
        public string q_head { get; set; }
        public string q_body { get; set; }
        public Nullable<int> q_qt { get; set; }
        public Nullable<bool> q_is_neg { get; set; }
        public Nullable<decimal> q_max_score { get; set; }
        public Nullable<int> q_tv { get; set; }
    
        public virtual ICollection<Answer> Answer { get; set; }
        public virtual QuestionType QuestionType { get; set; }
    }
}
