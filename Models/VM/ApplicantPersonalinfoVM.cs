using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ArmyTech_Task_SaeedAbdalWahab.Models.VM
{
    public class ApplicantPersonalinfoVM
    {

        public Applicant Applicant { get; set; }

        public ApplicantQualification   ApplicantQualification { get; set; }
        public IList<int> SelectedFields { get; set; }

        
        public ApplicantPersonalinfoVM()
        {
            Applicant = new Applicant();
            ApplicantQualification = new ApplicantQualification();
            SelectedFields = new List<int>();
        }


    }
}