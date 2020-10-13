using MyHospital.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyHospital.ViewModels
{
    public class HomePageViewModel
    {
        public List<Patient> patients { get; set; }
        public List<Doctor> doctors { get; set; }
        public List<Branch> branches { get; set; }
        public List<Appointment> appointments { get; set; }

    }
}