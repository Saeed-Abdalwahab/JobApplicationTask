//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ArmyTech_Task_SaeedAbdalWahab.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class ApplicantQualification
    {
        public int ID { get; set; }
        public Nullable<int> ApplicantId { get; set; }
        [Required]
        public Nullable<int> CertificationTypeId { get; set; }
        public Nullable<int> CertificationSpecificId { get; set; }
        public string Description { get; set; }
    
        public virtual Applicant Applicant { get; set; }
        public virtual CertificationSpecific CertificationSpecific { get; set; }
        public virtual CertificationType CertificationType { get; set; }
    }
}
