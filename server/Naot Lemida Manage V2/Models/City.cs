using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Naot_Lemida_Manage_V2.Models
{
    public class City
    {
        public int ID { get; set; }
        [Required(ErrorMessage ="בבקשה הזן שם של העיר.")]
        [Display(Name = "עיר")]
        public String Name { get; set; }
        public virtual ICollection<School> Schools { get; set; }
    }
}