using System;
using System.ComponentModel.DataAnnotations;

namespace Naot_Limudim_Manage.Models
{
    public class Coordinator
    {
        public int ID { get; set; }
        [Display(Name = "שם")]
        public String Name { get; set; }
        [Display(Name = "שם משפחה")]
        public String LastName { get; set; }
        [Display(Name = "נייד")]
        public String Phone { get; set; }
        [Display(Name = "מוסד")]
        public int SchoolID { get; set; }
        public virtual School School { get; set; }
    }
}
