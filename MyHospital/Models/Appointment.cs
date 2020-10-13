using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyHospital.Models
{
    [Table("Appointment")]
    public class Appointment 
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int No { get; set; }
        [Required]
        public int date { get; set; }
        [Required]
        public string time { get; set; }
        [Required]
        public string PatientName { get; set; }
        [Required]
        public string DrName { get; set; }
        //public int drID { get; set; }
        public virtual Doctor dr { get; set; }
        public virtual Patient pt { get; set; }
    }
    
}