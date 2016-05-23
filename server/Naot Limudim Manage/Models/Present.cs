using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Limudim_Manage.Models
{
    public class Present
    {
        public int ID { get; set; }
        [Display(Name="נוכח")]
        public bool IsPresent { get; set; }
        public int ClassID { get; set; }
        public virtual Class CLass { get; set; }
        public int PupilID { get; set; }
        public virtual Pupil Pupil { get; set; }
    }
}
