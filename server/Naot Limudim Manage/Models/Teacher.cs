using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Limudim_Manage.Models
{
    public class Teacher
    {
        public int ID { get; set; }
        [Display(Name="שם")]
        public String Name { get; set; }
        [Display(Name = "שם משפחה")]
        public String LastName { get; set; }
        [Display(Name = "נייד")]
        public String Phone { get; set; }
        [Display(Name = "מייל")]
        public String Email { get; set; }
        [Display(Name = "מוסד")]
        public int SchoolID { get; set; }
        public virtual School School  { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<TeacherOption> TeacherOptions { get; set; }

    }
}