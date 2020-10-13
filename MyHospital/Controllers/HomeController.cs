using MyHospital.Models;
using MyHospital.Models.DBContext;
using MyHospital.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHospital.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();
        // GET: Home
        public ActionResult homepage()
        {

            HomePageViewModel model = new HomePageViewModel();
            model.doctors = db.Doctors.ToList();
            model.patients = db.Patients.ToList();
            model.branches = db.Branches.ToList();
            model.appointments = db.Appointments.ToList();

            return View(model); 
        }


    }
}