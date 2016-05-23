using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Limudim_Manage.Models
{
    public class City
    {
        public int ID { get; set; }
        [Display(Name="עיר")]
        public String Name { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }
}
