﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace projetBiblio.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BiblioEntities : DbContext
    {
        public BiblioEntities()
            : base("name=BiblioEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AUTEUR> AUTEUR { get; set; }
        public virtual DbSet<COURANT> COURANT { get; set; }
        public virtual DbSet<EDITEUR> EDITEUR { get; set; }
        public virtual DbSet<GENRE> GENRE { get; set; }
        public virtual DbSet<LIVRE> LIVRE { get; set; }
    }
}
