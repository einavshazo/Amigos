using System;
using System.ComponentModel.DataAnnotations;


namespace Naot_Limudim_Manage.Models
{
    public class TeacherOption
    {
        public int ID { get; set; }
        [Display(Name="מ-")]
        public DateTime Start { get; set; }
        [Display(Name = "עד-")]
        public DateTime End { get; set; }
        [Display(Name ="מורה")]
        public int TeacherID { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
