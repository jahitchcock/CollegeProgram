//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CollegeProgram.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Term
    {
        public Term()
        {
            this.Sections = new HashSet<Section>();
        }
    
        public int TermID { get; set; }
        public string Year { get; set; }
        public string Description { get; set; }
    
        public virtual ICollection<Section> Sections { get; set; }
    }
}