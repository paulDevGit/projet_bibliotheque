//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class COURANT
    {
        public int ID_COURANT { get; set; }
        public string NOM_COURANT { get; set; }
        public Nullable<System.DateTime> DATE_SAISIE { get; set; }
        public Nullable<int> ID_GENRE { get; set; }
    
        public virtual GENRE GENRE { get; set; }
    }
}
