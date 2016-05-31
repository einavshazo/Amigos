using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Lemida_Manage_V2.Models
{
    public class Subject
    {
        public int ID { get; set; }
        [Display(Name = "מקצוע")]
        public String Name { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}