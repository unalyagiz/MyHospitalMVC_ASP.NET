using MyHospital.Models;
using MyHospital.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace MyHospital.Controllers
{
    public class PatientController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Patient
        public ActionResult New()
        {
            List<Branch> bra = db.Branches.ToList();
            TempData["bra"] = new SelectList(bra, "ID", "Name");
            ViewBag.bra = new SelectList(bra, "ID", "Name");
            return View();
        }

        public JsonResult GetDoctor(int disease)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Doctor> BranchList = db.Doctors.Where(x=>x.profession == disease).ToList();           
            return Json(BranchList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult New(Patient patient)
        {
            //Patient pat = db.Patients.Where(x => x.dr.ID == patient.dr.ID).FirstOrDefault();
           
            if (ModelState.IsValid == true)
            {
                
                patient.dr = db.Doctors.Where(x => x.ID == patient.branch).FirstOrDefault();
                db.Patients.Add(patient);
                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Redirecting to appointment selection...";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Appointment failed ";
                    ViewBag.Status = "danger";
                }
            }

            else
            {
                ViewBag.branch = TempData["bra"];
                ViewBag.Result = "Appointment failed ";
                ViewBag.Status = "danger";
            }
            
            ViewBag.branch = TempData["bra"];
            ViewBag.bra = TempData["bra"];
            return View();

        }

        public ActionResult ShowCalender()
        {
            List<SelectListItem> items = new List<SelectListItem>();            
            DateTime a = DateTime.Today;           
            int count = 7;
            for (int i = 0; i < count; i++)
            {
                string date = a.ToString("dd/MM/yyyy");
                string day = a.ToString("dddd");

                if (day == "Cumartesi" || day == "Pazar")
                {
                    a = a.AddDays(1);
                    count++;
                }
                else
                {
                    items.Add(new SelectListItem() { Text = date+" "+day, Value = Regex.Replace(date, @"[^a-zA-Z0-9\-]", "") });
                    a = a.AddDays(1);

                }

            }              ViewBag.dates = items;          
            ViewBag.hours = new List<string>() {"09:00","09:15","09:30","09:45","10:00","10:15","10:30","10:45",
                "11:00","11:15","11:30","11:45","12:00","12:15","12:30","12:45","13:00","13:15","13:30","13:45",
                "14:00","14:15","14:30","14:45","15:00","15:15","15:30","15:45","16:00","16:15",
                "16:30","16:45"
               };
            return PartialView("Appointment_PartialPage1");
        }

        public ActionResult Image()
        {
            string ImagePath = Server.MapPath("~/images/a.jpg");
            WebImage image = new WebImage(ImagePath);

            ViewBag.im= image;
            return PartialView("Doctor_Images");
        }

        public JsonResult GetDate(int dates)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Appointment> ap = db.Appointments.Where(x => x.date == dates).ToList();

            

            return Json(ap,JsonRequestBehavior.AllowGet);
        }
     
    }
}
