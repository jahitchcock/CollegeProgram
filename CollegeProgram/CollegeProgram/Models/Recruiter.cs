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
    
    public partial class Recruiter
    {
        public Recruiter()
        {
            this.CareerFairs = new HashSet<CareerFair>();
            this.Jobs = new HashSet<Job>();
        }
    
        public long RecruiterID { get; set; }
        public string Firstname { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    
        public virtual ICollection<CareerFair> CareerFairs { get; set; }
        public virtual ICollection<Job> Jobs { get; set; }
    }
}
