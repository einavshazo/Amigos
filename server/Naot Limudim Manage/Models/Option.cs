using System;
using System.ComponentModel.DataAnnotations;

namespace Naot_Lemida_Manage_V2.Models
{
    public class Option
    {
        public int ID { get; set; }
        [Display(Name = "מ-")]
        public DateTime Start { get; set; }
        [Display(Name = "עד-")]
        public DateTime End { get; set; }
        [Display(Name = "תלמיד")]
        public int ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}