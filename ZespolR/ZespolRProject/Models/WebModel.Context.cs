﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ZespolRProject.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ZespolREntities : DbContext
    {
        public ZespolREntities()
            : base("name=ZespolREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Editor> Editor { get; set; }
        public virtual DbSet<Moderator> Moderator { get; set; }
        public virtual DbSet<Position> Position { get; set; }
        public virtual DbSet<Question> Question { get; set; }
        public virtual DbSet<QuestionType> QuestionType { get; set; }
        public virtual DbSet<Test> Test { get; set; }
        public virtual DbSet<TestVersion> TestVersion { get; set; }
        public virtual DbSet<Candidate> Candidate { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<TestTake> TestTake { get; set; }
        public virtual DbSet<TestTakeStatus> TestTakeStatus { get; set; }
        public virtual DbSet<tt_a_assoc> tt_a_assoc { get; set; }
        public virtual DbSet<Answ> Answ { get; set; }
        public virtual DbSet<Users> Users { get; set; }
    }
}
