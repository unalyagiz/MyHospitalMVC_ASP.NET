using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyHospital.Models
{
    public class Branch
    {
        [Key]
        public int ID { get; set; }
        [Required,StringLength(60)]
        public string Name { get; set; }

        public virtual List<Doctor> d{ get; set; }

    }
}