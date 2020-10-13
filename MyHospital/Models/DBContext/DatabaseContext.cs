using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyHospital.Models.DBContext
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new DBGEnerator());
        }

    }
    public class DBGEnerator : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            List<Branch> branches = new List<Branch>()
            {   new Branch(){ID=1,Name="Ear, Nose & Throat" },
                new Branch(){ID=2,Name="Eye Health & Diseases" },
                new Branch(){ID=3,Name="Microbiology" },
                new Branch(){ID=4,Name="Internal Diseases" },
                new Branch(){ID=5,Name="Chest Diseases" },
                new Branch(){ID=6,Name="Cardiology" },
                new Branch(){ID=7,Name="Dermatology" },
                new Branch(){ID=8,Name="Medical Oncology" },
                new Branch(){ID=9,Name="Nephrology" },
                new Branch(){ID=10,Name="Aesthetic, Plastic & Reconstructive Surgery" },
                new Branch(){ID=11,Name="Neurology" },
                new Branch(){ID=12,Name="Neurosurgery" },
                new Branch(){ID=13,Name="Nuclear Medicine" },
                new Branch(){ID=14,Name="Obstetrics and Gynecology" },
                new Branch(){ID=15,Name="Orthopedics and Traumatology" },
                new Branch(){ID=16,Name="Pediatric Health and Diseases" },
                new Branch(){ID=17,Name="Pediatric Surgery" },
                new Branch(){ID=18,Name="Physical Therapy and Rehabilitation" },
                new Branch(){ID=19,Name="Radiology" },
                new Branch(){ID=20,Name="Rheumatology" },
                new Branch(){ID=21,Name="Urology" },
                new Branch(){ID=22,Name="Anesthesiology and Reanimation" },

            };
            foreach (Branch bra in branches)
            {
                context.Branches.Add(bra);

            };

            //////////////////////////
           /* List<Doctor> d = new List<Doctor>() {
            new Doctor(){Name="",Surname="",profession=, }, };
            */
            context.SaveChanges();
            List<Doctor> doctors = context.Doctors.ToList();
            //PATIENT
            foreach (Doctor dc in doctors)
            {
                Patient pat = new Patient()
                {
                    Name = FakeData.NameData.GetFirstName(),
                    Surname = FakeData.NameData.GetSurname(),
                    TC = FakeData.NumberData.GetNumber(),
                    //disease = FakeData.NetworkData.GetEmail(),
                    ID = FakeData.NumberData.GetNumber(1, 4),
                    //drID = FakeData.NumberData.GetNumber(1, 4)
                    dr = dc

                };
                context.Patients.Add(pat);
                Appointment app = new Appointment()
                {
                    date = 0,
                    pt = pat,
                    dr = dc,
                    PatientName = pat.Name,
                    DrName = dc.Name
                };
                context.Appointments.Add(app);


            }; context.SaveChanges();



        }
    }
}

