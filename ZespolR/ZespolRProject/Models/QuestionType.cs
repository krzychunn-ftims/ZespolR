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
    
    public partial class QuestionType
    {
        public int qt_id { get; set; }
        public string qt_name { get; set; }
        public Nullable<bool> qt_is_answer_def { get; set; }
        public Nullable<bool> qt_is_multiselect { get; set; }
    }
}
