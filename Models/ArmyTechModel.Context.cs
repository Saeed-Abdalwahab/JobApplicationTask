﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ArmyTechApplicantEntities1 : DbContext
    {
        public ArmyTechApplicantEntities1()
            : base("name=ArmyTechApplicantEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Applicant> Applicants { get; set; }
        public virtual DbSet<ApplicantApplicationsField> ApplicantApplicationsFields { get; set; }
        public virtual DbSet<ApplicantQualification> ApplicantQualifications { get; set; }
        public virtual DbSet<ApplicationsField> ApplicationsFields { get; set; }
        public virtual DbSet<CertificationSpecific> CertificationSpecifics { get; set; }
        public virtual DbSet<CertificationType> CertificationTypes { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
    }
}
