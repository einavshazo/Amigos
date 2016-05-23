using System;
using System.ComponentModel.DataAnnotations;

namespace Naot_Limudim_Manage.Models
{
    public class YearOfStudy
    {
        public int ID { get; set; }
        [Display(Name="כיתה")]
        public String Year { get; set; }
    }
}
