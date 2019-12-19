using ArmyTech_Task_SaeedAbdalWahab.Models.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ArmyTech_Task_SaeedAbdalWahab.Models;
using System.Data.Entity;

namespace ArmyTech_Task_SaeedAbdalWahab.Controllers
{
    public class HomeController : Controller
    {

        ArmyTechApplicantEntities1 Db = new ArmyTechApplicantEntities1();
        public ActionResult Index()
        {
            ApplicantPersonalinfoVM applicantPersonalinfoVM = new ApplicantPersonalinfoVM();
           
            ViewBag.Gender = new SelectList( Db.Genders,"ID","Name");
            ViewBag.Certification = new SelectList( Db.CertificationSpecifics,"ID","Name");
            ViewBag.Jobs = Db.ApplicationsFields.ToList();
            return View(applicantPersonalinfoVM);
        }
        [HttpPost]
        public ActionResult Index(ApplicantPersonalinfoVM applicantVM)
        {
            try { 
            if(ModelState.IsValid)
            {
                
                //Frist Must Save Applicant Data To Generat Id for this applicant
                Db.Applicants.Add(applicantVM.Applicant);
                Db.Entry(applicantVM.Applicant).State = EntityState.Added;
                Db.SaveChanges();
                //fill Applicant Qualifacations Detils Based On Applicant ID
                applicantVM.ApplicantQualification.ApplicantId = applicantVM.Applicant.ID;
                // Determin certification Type From  specification
                
                applicantVM.ApplicantQualification.CertificationTypeId = Db.CertificationSpecifics.FirstOrDefault(x => x.ID == applicantVM.ApplicantQualification.CertificationSpecificId).ID;
                
                Db.ApplicantQualifications.Add(applicantVM.ApplicantQualification);
                Db.SaveChanges();
                if (applicantVM.SelectedFields.Count > 0)
                {

                foreach (var item in applicantVM.SelectedFields)
                {
                    ApplicantApplicationsField applicantApplicationsField = new ApplicantApplicationsField();
                    applicantApplicationsField.ApplicantId = applicantVM.Applicant.ID;
                    applicantApplicationsField.ApplicationsFieldId = Db.ApplicationsFields.FirstOrDefault(x => x.ID == item).ID;
                    Db.ApplicantApplicationsFields.Add(applicantApplicationsField);
                    Db.SaveChanges();
                }
                }

                TempData["Msg"] = "تم التقديم بنجاح";

            }
               return RedirectToAction("index");
            }
            catch 
            { 
            TempData["Msg"] = "تعزر استقبال طلبك";
            return RedirectToAction("index");
            }
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}