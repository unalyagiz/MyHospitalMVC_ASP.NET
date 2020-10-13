using MyHospital.Models;
using MyHospital.Models.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHospital.Controllers
{
    public class DoctorController : Controller
    {   // GET: Doctor
        DatabaseContext db = new DatabaseContext();

        public ActionResult New()
        {

            List<Branch> bra = db.Branches.ToList();
            TempData["bra"] = new SelectList(bra, "ID", "Name");
            ViewBag.bra = new SelectList(bra, "ID", "Name");
            return View();
        }
        public ActionResult Edit(int? id)
        {
            List<Branch> bra = db.Branches.ToList();
            TempData["bra"] = new SelectList(bra, "ID", "Name");
            ViewBag.bra = new SelectList(bra, "ID", "Name");
            Doctor dc = null;
            if (id != null)
            {
                dc = db.Doctors.Where(x => x.ID == id).FirstOrDefault();
            }
            return View(dc);
        }

        [HttpPost]
        public ActionResult New(Doctor doctor)
        {
            if (ModelState.IsValid == true)
            {
                doctor.branc = db.Branches.Where(x => x.ID == doctor.profession).FirstOrDefault();
                db.Doctors.Add(doctor);

                int result = db.SaveChanges();
                if (result > 0)
                {
                    ViewBag.Result = "Doctor is added ";
                    ViewBag.Status = "success";
                }
                else
                {
                    ViewBag.Result = "Doctor is not added ";
                    ViewBag.Status = "danger";
                }

                ViewBag.branch = TempData["bra"];
            }
            else
            {
                ViewBag.branch = TempData["bra"];
                ViewBag.Result = "Doctor is not added ";
                ViewBag.Status = "danger";
            }   
            ViewBag.bra = TempData["bra"];           
            return View();
        }



        [HttpPost]
        public ActionResult Edit(Doctor doctor)
        {
            Doctor dc = db.Doctors.Where(x => x.ID == doctor.ID).FirstOrDefault();

            if(dc != null)
            {
                dc.Name = doctor.Name;
                dc.Surname = doctor.Surname;
                dc.profession = doctor.profession;
                dc.branc = db.Branches.Where(x => x.ID == doctor.profession).FirstOrDefault();


                db.SaveChanges(); 
            }
            ViewBag.bra = TempData["bra"];

            return View();
        }

         public JsonResult Delete(int ID)
        {
            Doctor doc = db.Doctors.SingleOrDefault(x => x.ID==ID);
            bool result = false;
            if(doc != null) {

            result = true;
            db.Doctors.Remove(doc);
            db.SaveChanges();
            }          
            return Json(result,JsonRequestBehavior.AllowGet);
        }
     
    }

}
