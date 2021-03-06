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
    
    public partial class Job
    {
        public long JobId { get; set; }
        public string JobLocation { get; set; }
        public string JobTitle { get; set; }
        public string JobDescription { get; set; }
        public System.DateTime JobPostingDate { get; set; }
        public string JobDegreeRequirements { get; set; }
        public string SocialMediaProfile { get; set; }
        public long AdvisorID { get; set; }
        public long RecruiterID { get; set; }
        public long CompanyID { get; set; }
        public System.DateTime PostingDate { get; set; }
        public string DegreeField { get; set; }
        public string Status { get; set; }
    
        public virtual Advisor Advisor { get; set; }
        public virtual Company Company { get; set; }
        public virtual Recruiter Recruiter { get; set; }
    }
}
