﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Uppgift4.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class tvtablaEntities2 : DbContext
    {
        public tvtablaEntities2()
            : base("name=tvtablaEntities2")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<channel> channel { get; set; }
        public virtual DbSet<program> program { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<user_channel> user_channel { get; set; }
    }
}
