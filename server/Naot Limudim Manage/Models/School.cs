using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Lemida_Manage_V2.Models
{
    public class School
    {
        public int ID { get; set; }
        [Display(Name = "שם המוסד")]
        public String Name { get; set; }
        [Display(Name = "רחוב")]
        public String Street { get; set; }
        [Display(Name = "מספר")]
        public int Number { get; set; }
        [Display(Name = "עיר")]
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}