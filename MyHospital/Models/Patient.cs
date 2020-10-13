using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyHospital.Models
{
    [Table("Patient")]
    public class Patient
    {
        [Key] //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public int TC { get; set; }

        [StringLength(35), Required]
        public string Name { get; set; }

        [StringLength(20), Required]
        public string Surname { get; set; }

        [Required] //[StringLength(50), Required] stringti
        public int disease { get; set; }


        public int branch { get; set; }

        /*[ForeignKey("ID")]
        public int drID { get; set; }
        */
        public virtual Doctor dr { get; set; }
        public virtual List<Appointment> ap { get; set; }

    }
}