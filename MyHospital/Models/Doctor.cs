using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyHospital.Models
{
    [Table("Doctor")]
    public class Doctor
    {
        [Key]
        public int ID { get; set; }   

        [StringLength(35),Required]
        public string Name { get; set; }

        [StringLength(20),Required]
        public string Surname { get; set; }

        public int profession { get; set; }

        public virtual Branch branc { get; set; }

        public virtual List<Appointment> ap { get; set; }


    }
}