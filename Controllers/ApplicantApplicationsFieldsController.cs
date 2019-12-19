using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ArmyTech_Task_SaeedAbdalWahab.Models;

namespace ArmyTech_Task_SaeedAbdalWahab.Controllers
{
    public class ApplicantApplicationsFieldsController : Controller
    {
        private ArmyTechApplicantEntities1 db = new ArmyTechApplicantEntities1();

        // GET: ApplicantApplicationsFields
        public ActionResult Index()
        {
            var applicantApplicationsFields = db.ApplicantApplicationsFields.Include(a => a.Applicant).Include(a => a.ApplicationsField);
            return View(applicantApplicationsFields.ToList());
        }

        // GET: ApplicantApplicationsFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsFields.Find(id);
            if (applicantApplicationsField == null)
            {
                return HttpNotFound();
            }
            return View(applicantApplicationsField);
        }

        // GET: ApplicantApplicationsFields/Create
        public ActionResult Create()
        {
            ViewBag.ApplicantId = new SelectList(db.Applicants, "ID", "Name");
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsFields, "ID", "Name");
            return View();
        }

        // POST: ApplicantApplicationsFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ApplicantId,ApplicationsFieldId")] ApplicantApplicationsField applicantApplicationsField)
        {
            if (ModelState.IsValid)
            {
                db.ApplicantApplicationsFields.Add(applicantApplicationsField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApplicantId = new SelectList(db.Applicants, "ID", "Name", applicantApplicationsField.ApplicantId);
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsFields, "ID", "Name", applicantApplicationsField.ApplicationsFieldId);
            return View(applicantApplicationsField);
        }

        // GET: ApplicantApplicationsFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsFields.Find(id);
            if (applicantApplicationsField == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApplicantId = new SelectList(db.Applicants, "ID", "Name", applicantApplicationsField.ApplicantId);
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsFields, "ID", "Name", applicantApplicationsField.ApplicationsFieldId);
            return View(applicantApplicationsField);
        }

        // POST: ApplicantApplicationsFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ApplicantId,ApplicationsFieldId")] ApplicantApplicationsField applicantApplicationsField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicantApplicationsField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApplicantId = new SelectList(db.Applicants, "ID", "Name", applicantApplicationsField.ApplicantId);
            ViewBag.ApplicationsFieldId = new SelectList(db.ApplicationsFields, "ID", "Name", applicantApplicationsField.ApplicationsFieldId);
            return View(applicantApplicationsField);
        }

        // GET: ApplicantApplicationsFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsFields.Find(id);
            if (applicantApplicationsField == null)
            {
                return HttpNotFound();
            }
            return View(applicantApplicationsField);
        }

        // POST: ApplicantApplicationsFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ApplicantApplicationsField applicantApplicationsField = db.ApplicantApplicationsFields.Find(id);
            db.ApplicantApplicationsFields.Remove(applicantApplicationsField);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
