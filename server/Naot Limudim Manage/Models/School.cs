using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Limudim_Manage.Models
{
    public class School
    {
        public int ID { get; set; }
        [Display(Name="שם המוסד")]
        public String Name { get; set; }
        [Display(Name="רחוב")]
        public String Street { get; set; }
        [Display(Name="מספר")]
        public int Number { get; set; }
        [Display(Name="עיר")]
        public int CityID { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
        public virtual ICollection<Pupil> Pupils { get; set; }
        public virtual ICollection<Coordinator> Coordinators { get; set; }
    }
}