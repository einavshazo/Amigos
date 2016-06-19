using System;
using System.ComponentModel.DataAnnotations;

namespace Naot_Lemida_Manage_V2.Models
{
    public class Option
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "הזן תאריך ושעת התחלה בבקשה.")]
        [Display(Name = "מ-")]
        public DateTime Start { get; set; }
        [Required(ErrorMessage = "הזן תאריך ושעת סיום בבקשה.")]
        [Display(Name = "עד-")]
        public DateTime End { get; set; }
        [Display(Name = "תלמיד")]
        public int ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}